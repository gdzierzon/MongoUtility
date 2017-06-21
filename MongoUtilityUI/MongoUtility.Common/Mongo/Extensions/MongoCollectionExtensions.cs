using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoUtility.Common.Mongo.Extensions
{
    public static class MongoCollectionExtensions
    {
        public static void DumpData<T>(this IMongoCollection<T> collection, string backupLocation, string collectionName)
        {
            var items = collection.FindAsync(new BsonDocument()).Result.ToListAsync().Result;
            StreamWriter sw = new StreamWriter($"{backupLocation}\\{collectionName}.bson");
            BsonWriter writer = new BsonBinaryWriter(sw.BaseStream);
            foreach (var item in items)
            {
                BsonSerializer.Serialize(writer, item);
            }
            sw.Close();
        }

        public static void DumpInformation<T>(this IMongoCollection<T> collection, string backupLocation, string collectionName)
        {
            var indexes = collection.Indexes.ListAsync().Result.ToList();
            var options = new BsonDocument().ToJson();
            var indexList = new List<string>();

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"options\":{},\"indexes\":[");
            indexes.ForEach(i =>
            {
                var keys = i.Names.ToList();
                var kvps = new List<string>();

                
                keys.ForEach(key =>
                {
                    switch (key)
                    {
                        case "v":
                        case "unique":
                            kvps.Add($"\"{key}\":{i[key]}");
                            break;
                        case "key":
                            var doc = i[key].AsBsonDocument;
                            var docKeys = doc.Names.ToList();
                            var indexKeys = new List<string>();

                            docKeys.ForEach(docKey => indexKeys.Add($"\"{docKey}\":{doc[docKey]}"));
                            kvps.Add("\"key\":{"+ string.Join(",",indexKeys)+ "}");

                            break;
                        default:
                            kvps.Add($"\"{key}\":\"{i[key]}\"");
                            break;
                    }
                });
                var indexLineItem = string.Join(",", kvps);
                indexList.Add("{"+indexLineItem+"}");
            });
            sb.Append(string.Join(",", indexList));
            sb.Append("]}");
            
            
            StreamWriter sw = new StreamWriter($"{backupLocation}\\{collectionName}.metadata.json");
            sw.Write(sb.ToString());

            sw.Close();
        }
    }
}