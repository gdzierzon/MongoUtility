using System;
using System.Diagnostics;
using MongoUtility.Common.Interfaces.Messaging;

namespace MongoUtility.Common.Mongo
{
    public class MongoDump
    {
        private MongoUtility.Common.Rx.EventAggregator EventAggregator => MongoUtility.Common.Rx.EventAggregator.Aggregator;
        private const string Executable = "mongodump.exe";

        public string Database { get; set; }
        public string BackupLocation { get; set; }

        public void BackupDatabase()
        {

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = Executable,
                        Arguments = $"/db:{Database} /out:\"{BackupLocation}\"",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };
                process.Start();

                process.OutputDataReceived += (sender, args) =>
                {
                    EventAggregator.Publish(new BackupMessage()
                    {
                        Body = args.Data,
                        MessageType = MessageTypes.Information,
                        Status = ProcessStatuses.ProgressUpdate
                    });
                };

                process.ErrorDataReceived += (sender, args) =>
                {
                    EventAggregator.Publish(new BackupMessage()
                    {
                        Body = args.Data,
                        MessageType = MessageTypes.Error,
                        Status = ProcessStatuses.ProgressUpdate
                    });
                };

                process.WaitForExit();

                EventAggregator.Publish(new BackupMessage()
                {
                    Body = $"MongoDump export of {Database} has completed.",
                    MessageType = MessageTypes.Information,
                    Status = ProcessStatuses.Completed
                });
            }
            catch (Exception e)
            {
                EventAggregator.Publish(new BackupMessage()
                {
                    Body = $"An error has occurred. {Database} could not be backed up.",
                    MessageType = MessageTypes.Error,
                    Status = ProcessStatuses.Error
                });
            }
        }
    }
}