using System;
using System.Diagnostics;
using System.Threading;
using MongoUtility.Common.Interfaces.Dto;
using MongoUtility.Common.Interfaces.Log;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Interfaces.Mongo;
using MongoUtility.Common.Rx;

namespace MongoUtility.Common.Mongo
{
    public class MongoRestore
    {
        private const string Executable = "mongorestore.exe";

        private RestoreInformation restore { get; set; }

        public MongoRestore(RestoreInformation restore)
        {
            this.restore = restore;
        }

        public void RestoreDatabase()
        {

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = Executable,
                        Arguments = $"/db:{restore.DatabaseRestoreName} /dir:\"{restore.DatabaseDirectory}\"",
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
                }

                process.Dispose();
            }
            catch (Exception e)
            {
                restore.Log(e.Message, LogLevel.Error);
            }
        }
    }
}