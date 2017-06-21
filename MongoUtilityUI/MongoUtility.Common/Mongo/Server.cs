using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoUtility.Common.Interfaces.Dto;
using MongoUtility.Common.Interfaces.Mongo;
using MongoUtility.Common.Mongo.Extensions;
//using Newtonsoft.Json;

namespace MongoUtility.Common.Mongo
{
    public class Server: IServer
    {
        //private JsonSerializer JsonSerializer = new JsonSerializer();
        private MongoUtility.Common.Rx.EventAggregator EventAggregator => MongoUtility.Common.Rx.EventAggregator.Aggregator;

        private IMongoClient Client { get; set; }

        public string ServerName { get; set; }

        public List<Database> DatabaseList { get; set; } = new List<Database>();

        public Server(string serverName)
        {
            ServerName = serverName;

            var connectionString = $"mongodb://{serverName}";
            Client = new MongoClient(connectionString);

            var databases = Client.ListDatabases().ToListAsync().Result;

            foreach (var database in databases)
            {
                var name = database["name"].AsString;
                var size = database["sizeOnDisk"].AsDouble;
                var isSystem = name == "local" || name =="admin";

                var db = new Database
                {
                    Name = name,
                    SizeOnDisk = size,
                    IsSystem = isSystem
                };
                DatabaseList.Add(db);
            }
        }

        public void CopyDatabase(string databaseName, string newDatabaseName)
        {
            var currentDB = Client.GetDatabase(databaseName);
            var newDatabase = Client.GetDatabase(newDatabaseName);

            foreach (var item in currentDB.ListCollections().ToListAsync().Result)
            {
                try
                {
                    var collectionName = item["name"].AsString;
                    var collection = currentDB.GetCollection<BsonDocument>(collectionName);
                    newDatabase.CreateCollection(collectionName);
                    var newCollection = newDatabase.GetCollection<BsonDocument>(collectionName);

                    var items = collection.FindAsync(new BsonDocument()).Result.ToListAsync().Result;

                    newCollection.InsertMany(items);
                }
                catch (Exception ex)
                {
                    var message = ex.ToString();
                }
            }
        }

        public void BackupDatabase(BackupInformation backup)
        {

            var currentDB = Client.GetDatabase(backup.DatabaseName);
            var collections = currentDB.ListCollections().ToListAsync().Result;

            if (!Directory.Exists(backup.Directory))
            {
                Directory.CreateDirectory(backup.Directory);
            }
            if (!Directory.Exists(backup.DatabaseDirectory))
            {
                Directory.CreateDirectory(backup.DatabaseDirectory);
            }

            collections.ForEach(c =>
            {
                var name = c["name"].AsString;
                var collection = currentDB.GetCollection<BsonDocument>(c["name"].AsString);
                collection.DumpData(backup.DatabaseDirectory, name);
                collection.DumpInformation(backup.DatabaseDirectory, name);
                backup.Log($"{name} has been backed up");
            });



        }

        public void RestoreDatabase(RestoreInformation restore)
        {
            restore.Status = ProcessStatuses.InProgress;
            restore.Log($"Restore of {restore.DatabaseRestoreName} started.");

            try
            {
                Client.DropDatabase(restore.DatabaseName);

                var db = Client.GetDatabase(restore.DatabaseName);

                var files = Directory.GetFiles(restore.DatabaseDirectory).Where(f => f.EndsWith(".bson")).ToList();

                files.ForEach(f =>
                {
                    FileInfo fileInfo = new FileInfo(f);
                    try
                    {
                        RestoreCollectionData(fileInfo, db);
                        restore.Log($"{fileInfo.Name} restored.");
                    }
                    catch (Exception ex)
                    {
                        restore.Log($"Error restoring {fileInfo.Name}.");
                    }
                });

                restore.Log($"Restore complete.");
            }
            catch (Exception ex)
            {
                restore.Log($"Error restoring {ex.Message}.");
            }

        }

        public void DropDatabase(string databaseName)
        {
            Client.DropDatabase(databaseName);
        }

        public void RestoreCollectionStructure(FileInfo fileInfo, IMongoDatabase database)
        {
            string collectionName = fileInfo.Name.Replace(".bson", "");
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var items = new List<BsonDocument>();

            StreamReader sr = new StreamReader(fileInfo.FullName);
            
            var line = sr.ReadToEnd();
            var jsonReader = new JsonReader(line);
            var bson = BsonSerializer.Deserialize<BsonDocument>(jsonReader);
            
        }

        public void RestoreCollectionData(FileInfo fileInfo, IMongoDatabase database)
        {
            string collectionName = fileInfo.Name.Replace(".bson", "");
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var items = new List<BsonDocument>();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(fileInfo.FullName);
                BsonReader bsonReader = new BsonBinaryReader(sr.BaseStream);
                while (!bsonReader.IsAtEndOfFile())
                {
                    var bson = BsonSerializer.Deserialize<BsonDocument>(bsonReader);
                    items.Add(bson);
                }

                if (items.Any())
                {
                    collection.InsertMany(items);
                }
                else
                {
                    //this is a hack to force creation of the collection
                    var doc = new BsonDocument();
                    collection.InsertOne(doc);
                    collection.DeleteMany(doc);
                }
            }
            finally
            {
                sr?.Close();
            }

        }
    }
}