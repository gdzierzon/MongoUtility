using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Common.Interfaces.Mongo;

namespace MongoUtility.Common.Mongo
{
    public class Server
    {
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
                var isSystem = name == "local";

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

        public void DropDatabase(string databaseName)
        {
            Client.DropDatabase(databaseName);
        }
    }
}