namespace MongoUtility.Common.Interfaces.Messaging
{
    public class Message: IMessage
    {
        public MessageTypes MessageType { get; set; }
    }

    public class Message<T> : Message, IMessage<T>
    {
        public T Body { get; set; }

        public Message(T body)
        {
            Body = body;
        }

        public Message()
        {
            
        }
    }
}