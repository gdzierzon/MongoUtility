using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoUtility.Common.Interfaces.Dto;
using MongoUtility.Common.Interfaces.Mongo;
using MongoUtility.Common.Mongo.Extensions;

namespace MongoUtility.Common.Mongo
{
    public class Server: IServer
    {
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

        public void DropDatabase(string databaseName)
        {
            Client.DropDatabase(databaseName);
        }

        public void DesieralizeFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            
            BsonReader bsonReader = new BsonBinaryReader(sr.BaseStream);
            //var bsonBytes = bsonReader.ToBson();
            int count = 0;
            while (!bsonReader.IsAtEndOfFile())
            {
                count++;
                try
                {
                    var bson = BsonSerializer.Deserialize<BsonDocument>(bsonReader);
                    var test = bson.ToJson();
                }
                catch (Exception)
                {
                    
                }
            }

            var counter = count;

        }
    }
}