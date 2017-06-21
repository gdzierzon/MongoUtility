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
    public class DatabaseInformation
    {
        public string DatabaseName { get; set; }
        public bool DropDatabase { get; set; }
        public ProcessStatuses Status { get; set; }
        public IServer MongoServer { get; set; }
        public Exception Exception { get; set; }
        public List<LogInformation> Logs { get; } = new List<LogInformation>();
        protected IEventAggregator EventAggregator { get; set; }


        public DatabaseInformation(string databaseName, IEventAggregator eventAggregator, IServer mongoServer)
        {
            EventAggregator = eventAggregator;
            MongoServer = mongoServer;
            DatabaseName = databaseName;
            Status = ProcessStatuses.NotStarted;

            Logs.Add(new LogInformation()
            {
                LogLevel = LogLevel.Information,
                Message = "Initiate request."
            });
        }

        public void Log(string message, LogLevel level = LogLevel.Information)
        {
            Logs.Add(new LogInformation()
            {
                Message = message
            });
            Publish();
        }

        protected virtual void Publish()
        {
            EventAggregator.Publish(new Message<DatabaseInformation>(this));
        }

        public override string ToString()
        {
            var log = Logs.Last();
            return $"{log.DateTime}       {DatabaseName}       {log.Message}";
        }
    }
}