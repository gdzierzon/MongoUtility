namespace MongoUtility.Common.Interfaces.Messaging
{
    public class RestoreMessage: Message<string>
    {
        public ProcessStatuses Status { get; set; }
    }
}