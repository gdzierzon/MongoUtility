using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MongoUtility.Common.Interfaces.Dto;
using MongoUtility.Common.Interfaces.Log;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Mongo;
using MongoUtility.Common.SharpZip;

namespace MongoUtility.UI.Win.Controllers
{
    public class BackupController
    {
        private MongoUtility.Common.Rx.EventAggregator EventAggregator => MongoUtility.Common.Rx.EventAggregator.Aggregator;
        private readonly IList<IDisposable> subscriptions = new List<IDisposable>();

        #region singleton construction

        private static BackupController backupController;
        public static BackupController Controller => backupController ?? (backupController = new BackupController());

        private BackupController()
        {

            subscriptions.Add(EventAggregator.GetEvent<Message<BackupInformation>>()
                .Where(msg => msg.MessageType == MessageTypes.Backup && msg.Body.Status == ProcessStatuses.NotStarted)
                .Subscribe(msg => Backup(msg.Body)));
        }

        #endregion

        public void Backup(BackupInformation backup)
        {
            try
            {
                //var dump = new MongoDump(backup);
                //dump.BackupDatabase();
                backup.Status = ProcessStatuses.Started;
                backup.Log("Backup started");
                backup.MongoServer.BackupDatabase(backup);

                if (backup.Compress)
                {
                    Compression.Zip(backup);
                    Directory.Delete(backup.Directory, true);
                }

                if (backup.DropDatabase)
                {
                    backup.MongoServer.DropDatabase(backup.DatabaseName);
                }

                backup.Log("Backup completed");
            }
            catch(Exception ex)
            {
                 backup.Log(ex.Message, LogLevel.Error);
            }
        }
    }
}