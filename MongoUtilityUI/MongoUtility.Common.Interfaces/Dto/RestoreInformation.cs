using System.IO;
using System.Linq;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Interfaces.Mongo;
using MongoUtility.Common.Interfaces.Rx;

namespace MongoUtility.Common.Interfaces.Dto
{
    public class RestoreInformation: BackupInformation
    {
        public RestoreInformation(string databaseName, string fileName, IEventAggregator eventAggregator, IServer mongoServer) : base(databaseName, fileName, eventAggregator, mongoServer)
        {
        }

        public string DatabaseRestoreName
        {
            get
            {
                var directory = System.IO.Directory.GetDirectories(Directory).First();
                var fi = new FileInfo(directory);

                return fi.Name;
            }
        }


        protected override void Publish()
        {
            EventAggregator.Publish(new Message<RestoreInformation>(this));
        }
    }
}