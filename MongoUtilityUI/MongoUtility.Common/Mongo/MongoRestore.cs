using System;
using System.Diagnostics;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Interfaces.Mongo;
using MongoUtility.Common.Rx;

namespace MongoUtility.Common.Mongo
{
    public class MongoRestore
    {
        private MongoUtility.Common.Rx.EventAggregator EventAggregator => MongoUtility.Common.Rx.EventAggregator.Aggregator;
        private const string Executable = "mongorestore.exe";

        public string DatabaseName { get; set; }
        public string BackupLocation { get; set; }

        public void RestoreDatabase()
        {

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = Executable,
                        Arguments = $"/db:{DatabaseName} /dir:\"{BackupLocation}\"",
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        RedirectStandardError = false,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };
                process.Start();

                //process.OutputDataReceived += (sender, args) =>
                //{
                //    EventAggregator.Publish(new RestoreMessage()
                //    {
                //        Body = args.Data,
                //        MessageType = MessageTypes.Information,
                //        Status = ProcessStatuses.ProgressUpdate
                //    });
                //};

                //process.ErrorDataReceived += (sender, args) =>
                //{
                //    EventAggregator.Publish(new RestoreMessage()
                //    {
                //        Body = args.Data,
                //        MessageType = MessageTypes.Error,
                //        Status = ProcessStatuses.ProgressUpdate
                //    });
                //};
                
                process.WaitForExit();

                EventAggregator.Publish(new RestoreMessage()
                {
                    Body = $"MongoRestore of {DatabaseName} has completed.",
                    MessageType = MessageTypes.Information,
                    Status = ProcessStatuses.Completed
                });
            }
            catch (Exception e)
            {
                EventAggregator.Publish(new RestoreMessage()
                {
                    Body = $"An error has occurred. {DatabaseName} could not be restored.",
                    MessageType = MessageTypes.Error,
                    Status = ProcessStatuses.Error
                });
            }
        }
    }
}