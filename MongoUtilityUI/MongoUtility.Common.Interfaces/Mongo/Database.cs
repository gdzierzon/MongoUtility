namespace MongoUtility.Common.Interfaces.Mongo
{
    public class Database
    {
        public string Name { get; set; }
        public double SizeOnDisk { get; set; }
        public bool IsSystem { get; set; }
    }
}
