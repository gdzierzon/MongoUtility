namespace MongoUtility.Common.Interfaces.Messaging
{
    public class MongoMessage: Message<string>
    {
        public ActionTypes Action { get; set; }
        public ProcessStatuses Status { get; set; }

        public override string ToString()
        {
            return $"{Action}: {Body}";
        }
    }
}