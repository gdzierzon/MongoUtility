using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoUtility.Common.Interfaces.Log;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Interfaces.Mongo;
using MongoUtility.Common.Interfaces.Rx;

namespace MongoUtility.Common.Interfaces.Dto
{
    public class BackupInformation:DatabaseInformation
    {
        private Guid TempGuid { get; } = Guid.NewGuid();
        private FileInfo FileInfo { get; set; }

        public string Directory
        {
            get
            {
                var directory = FileInfo.DirectoryName;
                return $"{directory}\\temp_{TempGuid}";
            }
        }

        public virtual string DatabaseDirectory => $"{Directory}\\{DatabaseName}";

        public string File { get; set; }

        public string Extension
        {
            get { return FileInfo.Extension; }
        }
        public bool Compress { get; set; }

        public BackupInformation(string databaseName, string fileName, IEventAggregator eventAggregator, IServer mongoServer) : base(databaseName,eventAggregator,mongoServer)
        {
            File = fileName;
            FileInfo = new FileInfo(File);
        }

        protected override void Publish()
        {
            EventAggregator.Publish(new Message<BackupInformation>(this));
        }
    }
}