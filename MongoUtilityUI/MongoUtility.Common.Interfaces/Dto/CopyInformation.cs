using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Interfaces.Mongo;
using MongoUtility.Common.Interfaces.Rx;

namespace MongoUtility.Common.Interfaces.Dto
{
    public class CopyInformation:DatabaseInformation
    {
        public string NewDatabaseName { get; set; }
        public CopyInformation(string databaseName,string newDatabase, IEventAggregator eventAggregator, IServer mongoServer) : base(databaseName, eventAggregator, mongoServer)
        {
            NewDatabaseName = newDatabase;
        }

        protected override void Publish()
        {
            EventAggregator.Publish(new Message<CopyInformation>(this));
        }
    }
}