using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.SharpZip;

namespace MongoUtility.Common.Mongo
{
    public class MongoDump
    {
        private MongoUtility.Common.Rx.EventAggregator EventAggregator => MongoUtility.Common.Rx.EventAggregator.Aggregator;
        private const string Executable = "mongodump.exe";

        public string Database { get; set; }
        public string BackupLocation { get; set; }
        public string ZipFile { get; set; }

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

                process.Exited += Process_Exited;

                process.Start();
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    EventAggregator.Publish(new MongoMessage()
                    {
                        Body = line,
                        Action = ActionTypes.Backup,
                        MessageType = MessageTypes.Information,
                        Status = ProcessStatuses.ProgressUpdate
                    });
                }
                while (!process.StandardError.EndOfStream)
                {
                    var line = process.StandardError.ReadLine();
                    EventAggregator.Publish(new MongoMessage()
                    {
                        Body = line,
                        Action = ActionTypes.Backup,
                        MessageType = MessageTypes.Error,
                        Status = ProcessStatuses.ProgressUpdate
                    });
                }

                //process.OutputDataReceived += (sender, args) =>
                //{
                //    EventAggregator.Publish(new MongoMessage()
                //    {
                //        Body = args.Data,
                //        Action = ActionTypes.Backup,
                //        MessageType = MessageTypes.Information,
                //        Status = ProcessStatuses.ProgressUpdate
                //    });
                //};

                //process.ErrorDataReceived += (sender, args) =>
                //{
                //    EventAggregator.Publish(new MongoMessage()
                //    {
                //        Body = args.Data,
                //        Action = ActionTypes.Backup,
                //        MessageType = MessageTypes.Error,
                //        Status = ProcessStatuses.ProgressUpdate
                //    });
                //};

                //process.WaitForExit();
                while (!process.HasExited)
                {
                    Thread.Sleep(500);
                }

                process.Dispose();


                EventAggregator.Publish(new MongoMessage()
                {
                    Body = $"MongoDump export of {Database} has completed.",
                    Action = ActionTypes.Backup,
                    MessageType = MessageTypes.Information,
                    Status = ProcessStatuses.ProgressUpdate
                });

                Compression.Zip(BackupLocation, ZipFile);

                //clean directory
                Directory.Delete(BackupLocation, true);

                //EventAggregator.Publish(new MongoMessage()
                //{
                //    Body = $"{Database} has been compressed",
                //    Action = ActionTypes.Backup,
                //    MessageType = MessageTypes.Information,
                //    Status = ProcessStatuses.Completed
                //});
            }
            catch (Exception e)
            {
                EventAggregator.Publish(new MongoMessage()
                {
                    Body = $"An error has occurred. {Database} could not be backed up.",
                    Action = ActionTypes.Backup,
                    MessageType = MessageTypes.Error,
                    Status = ProcessStatuses.Error
                });
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {


        }
    }
}