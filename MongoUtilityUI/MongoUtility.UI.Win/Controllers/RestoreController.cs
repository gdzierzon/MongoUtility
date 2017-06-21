using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using MongoUtility.Common.Interfaces.Dto;
using MongoUtility.Common.Interfaces.Log;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Mongo;
using MongoUtility.Common.SharpZip;

namespace MongoUtility.UI.Win.Controllers
{
    public class RestoreController
    {

        private MongoUtility.Common.Rx.EventAggregator EventAggregator => MongoUtility.Common.Rx.EventAggregator.Aggregator;
        private readonly IList<IDisposable> subscriptions = new List<IDisposable>();

        #region singleton construction

        private static RestoreController restoreController;
        public static RestoreController Controller => restoreController ?? (restoreController = new RestoreController());

        private RestoreController()
        {

            subscriptions.Add(EventAggregator.GetEvent<Message<RestoreInformation>>()
                .Where(msg => msg.MessageType == MessageTypes.Restore && msg.Body.Status == ProcessStatuses.NotStarted)
                .Subscribe(msg => Restore(msg.Body)));
        }

        #endregion

        private void Restore(RestoreInformation restore)
        {
            try
            {
                restore.Status = ProcessStatuses.Started;
                restore.Log("Beginning restore process.");
                
                Compression.UnZip(restore);

                restore.Log("Unzip complete");

                //var mongoRestore = new MongoRestore(restore);
                //mongoRestore.RestoreDatabase();

                restore.MongoServer.RestoreDatabase(restore);

                restore.Status = ProcessStatuses.Completed;
                restore.Log("Database restore complete.");

                Directory.Delete(restore.Directory, true);
                
            }
            catch (Exception ex)
            {
                restore.Log(ex.Message,LogLevel.Error);
            }
        }
    }
}