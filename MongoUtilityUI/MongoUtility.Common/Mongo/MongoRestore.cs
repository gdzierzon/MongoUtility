using System;
using System.Diagnostics;
using System.Threading;
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
                        UseShellExecute = true,
                        RedirectStandardOutput = false,
                        RedirectStandardError = false,
                        CreateNoWindow = true,
                        //WindowStyle = ProcessWindowStyle.Hidden
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
                while (!process.HasExited)
                {
                    Thread.Sleep(500);

                    //EventAggregator.Publish(new MongoMessage()
                    //{
                    //    Body = $"restoring {DatabaseName} ...",
                    //    Action = ActionTypes.Restore,
                    //    MessageType = MessageTypes.Information,
                    //    Status = ProcessStatuses.ProgressUpdate
                    //});
                }

                process.Dispose();
            }
            catch (Exception e)
            {
                EventAggregator.Publish(new MongoMessage()
                {
                    Body = $"An error has occurred. {DatabaseName} could not be restored.",
                    Action = ActionTypes.Restore,
                    MessageType = MessageTypes.Error,
                    Status = ProcessStatuses.Error
                });
            }
        }
    }
}