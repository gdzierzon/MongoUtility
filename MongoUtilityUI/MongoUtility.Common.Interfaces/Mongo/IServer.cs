using MongoUtility.Common.Interfaces.Dto;

namespace MongoUtility.Common.Interfaces.Mongo
{
    public interface IServer
    {
        void CopyDatabase(string databaseName, string newDatabaseName);
        void DropDatabase(string databaseName);
        void BackupDatabase(BackupInformation backup);
    }
}