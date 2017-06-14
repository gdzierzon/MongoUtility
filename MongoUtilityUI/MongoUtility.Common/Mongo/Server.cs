using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoUtility.Common.Mongo
{
    public class Server
    {
        private IMongoClient Client { get; set; }

        public string ServerName { get; set; }

        public List<string> DatabaseList { get; set; } = new List<string>();

        public Server(string serverName)
        {
            ServerName = serverName;

            var connectionString = $"mongodb://{serverName}";
            Client = new MongoClient(connectionString);

            var databases = Client.ListDatabases().ToListAsync().Result;

            foreach (var database in databases)
            {
                DatabaseList.Add(database["name"].AsString);
            }
        }

        public void DropDatabase(string databaseName)
        {
            Client.DropDatabase(databaseName);
        }
    }
}