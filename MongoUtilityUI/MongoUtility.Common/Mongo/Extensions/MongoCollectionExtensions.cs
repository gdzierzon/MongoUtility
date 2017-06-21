using System.Collections.Generic;
using System.IO;
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

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"options\":{},\"indexes\":[");
            indexes.ForEach(i =>
            {
                var _v = i["v"].AsInt32;
                var _key = i["key"].AsBsonDocument;
                var _id = _key["_id"].AsInt32;
                var _name = i["name"].AsString;
                var _ns = i["ns"].AsString;


                sb.Append("{");
                sb.AppendFormat("\"v\":{0},", _v);
                sb.Append("\"key\":{");
                sb.AppendFormat("\"_id\":{0}", _id);
                sb.Append("},");
                sb.AppendFormat("\"name\":\"{0}\",", _name);
                sb.AppendFormat("\"ns\":\"{0}\"", _ns);
                sb.Append("}");
            });
            sb.Append("]}");
            
            
            StreamWriter sw = new StreamWriter($"{backupLocation}\\{collectionName}.metadata.json");
            sw.Write(sb.ToString());

            sw.Close();
        }
    }
}