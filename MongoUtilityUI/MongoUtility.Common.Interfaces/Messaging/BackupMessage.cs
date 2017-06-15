namespace MongoUtility.Common.Interfaces.Messaging
{
    public class BackupMessage: Message<string>
    {
        public ProcessStatuses Status { get; set; }
    }
}