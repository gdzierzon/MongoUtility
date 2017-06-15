namespace MongoUtility.Common.Interfaces.Messaging
{
    public interface IMessage
    {
        MessageTypes MessageType { get; }
    }

    public interface IMessage<T> : IMessage
    {
        T Body { get; }
    }
}