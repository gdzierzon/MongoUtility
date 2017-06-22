using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoUtility.Common.Interfaces.Dto;
using MongoUtility.Common.Interfaces.Messaging;
using MongoUtility.Common.Mongo;
using MongoUtility.Common.SharpZip;
using MongoUtility.UI.Win.Controllers;

namespace MongoUtility.UI.Win
{
    public delegate void AddItemInvoker(object item);
    public partial class MainForm : Form
    {
        private MongoUtility.Common.Rx.EventAggregator EventAggregator => MongoUtility.Common.Rx.EventAggregator.Aggregator;
        private readonly IList<IDisposable> subscriptions = new List<IDisposable>();

        public BackupController BackupController { get; } = BackupController.Controller;
        public RestoreController RestoreController { get; } = RestoreController.Controller;

        #region backup variables

        public string BackupDatabaseName => databaseBackupTextBox.Text;

        public string BackupFile => backupLocationTextBox.Text;

        #endregion

        #region restore variables
        
        public string RestoreFileName => importFileTextBox.Text;

        private string RestoreDatabaseName => restoreDatabaseTextBox.Text;

        #endregion

        public string SelectedDatabase { get; set; }

        public string DefaultDirectory {
            get { return Properties.Settings.Default.BackupLocation; }
            set
            {
                Properties.Settings.Default.BackupLocation = value;
                Properties.Settings.Default.Save();
            }
        }
        
        public Server MongoServer { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupSubscriptions();
            InitializeDialogs();
            LoadMongoTree();
        }
  

        private void SetupSubscriptions()
        {
            //backup subscriptions
            subscriptions.Add(EventAggregator.GetEvent<Message<BackupInformation>>()
                .Subscribe(msg => UpdateProgress(msg.Body)));

            subscriptions.Add(EventAggregator.GetEvent<Message<RestoreInformation>>()
                .Subscribe(msg => UpdateProgress(msg.Body)));

        }

        private void UpdateProgress(object item)
        {
            if (progressList.InvokeRequired)
            {
                var ai = new AddItemInvoker(UpdateProgress);
                this.Invoke(ai, item);
            }
            else
            {
                progressList.Items.Add(item);
                int visibleItems = progressList.ClientSize.Height / progressList.ItemHeight;
                progressList.TopIndex = Math.Max(progressList.Items.Count - visibleItems + 1, 0);

                var message = item as BackupInformation;
                if(message != null && message.Status == ProcessStatuses.Completed)
                {
                    LoadMongoTree();
                }
            }

        }

        private void InitializeDialogs()
        {
            if (DefaultDirectory.Trim() == string.Empty)
            {
                SetDefaultDirectory();
            }

            backupLocationDialog.InitialDirectory = DefaultDirectory;
            restoreFileDialog.InitialDirectory = DefaultDirectory;

            //var fileExtensions = "Zip Files (*.zip, *.gzip) | *.zip;*.gzip | Backup Files (*.bak) | *.bak | All Files | *.* ";
            //backupLocationDialog.Filter = fileExtensions;
            //restoreFileDialog.Filter = fileExtensions;
        }

        private void LoadMongoTree()
        {
            mongoTree.Nodes.Clear();

            MongoServer = new Server("localhost");

            var serverNode = new TreeNode(MongoServer.ServerName)
            {
                ImageIndex = 0,
                SelectedImageIndex = 0,
                Name = ""
            };

            foreach (var database in MongoServer.DatabaseList)
            {
                if (!database.IsSystem)
                {
                    var databaseNode = new TreeNode(database.Name)
                    {
                        ImageIndex = 1,
                        SelectedImageIndex = 1,
                        Name = database.Name
                    };
                    databaseNode.Tag = "database";
                    databaseNode.ContextMenuStrip = databaseContextMenu;
                    serverNode.Nodes.Add(databaseNode);
                }
            }

            mongoTree.Nodes.Add(serverNode);
            serverNode.ContextMenuStrip = serverContextMenu;
            serverNode.ExpandAll();
        }

        private void mongoTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            SelectedDatabase = node.Name;

            if (e.Button == MouseButtons.Left)
            {
                databaseBackupTextBox.Text = SelectedDatabase;
                renameCurrentDatabaseTextBox.Text = SelectedDatabase;
            }
            else if (e.Button == MouseButtons.Right && e.Node.Tag.ToString() == "database")
            {
                databaseContextMenu.Show();
            }
        }

        private void backupLocationButton_Click(object sender, EventArgs e)
        {
            var result = backupLocationDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                backupLocationTextBox.Text = backupLocationDialog.FileName;
            }
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            var backupInfo = new BackupInformation(BackupDatabaseName, BackupFile, EventAggregator, MongoServer)
            {
                Compress = true,
                DropDatabase = dropDatabaseCheck.Checked
            };

            EventAggregator.Publish(new Message<BackupInformation>(backupInfo)
            { MessageType = MessageTypes.Backup });
        }

        private void importFileLocationButton_Click(object sender, EventArgs e)
        {
            var result = restoreFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                importFileTextBox.Text = restoreFileDialog.FileName;
            }
        }

        private void importDatabaseButton_Click(object sender, EventArgs e)
        {

            var restoreInfo = new RestoreInformation(RestoreDatabaseName, RestoreFileName, EventAggregator, MongoServer);

            EventAggregator.Publish(new Message<RestoreInformation>(restoreInfo)
            {
                MessageType = MessageTypes.Restore
            });

        }


        private void defaultBackupDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDefaultDirectory();
        }

        private void SetDefaultDirectory()
        {
            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                DefaultDirectory = folderBrowserDialog.SelectedPath;
                backupLocationDialog.InitialDirectory = DefaultDirectory;
                restoreFileDialog.InitialDirectory = DefaultDirectory;
            }
        }

        private void renameDatabaseButton_Click(object sender, EventArgs e)
        {
            var currentDatabase = renameCurrentDatabaseTextBox.Text;
            var guid = Guid.NewGuid();
            var tempFolder = $"{DefaultDirectory}\\temp{guid}";
            var newDatabase = renameNewDatabaseTextBox.Text;


            try
            {
                MongoServer.CopyDatabase(currentDatabase, newDatabase);

                LoadMongoTree();

                toolStripStatusLabel.Text = $"{currentDatabase} has been successfully renamed to {newDatabase}.";
            }
            catch
            {
                toolStripStatusLabel.Text = $"There was an error renaming {currentDatabase}.";
            }
        }

        private void dropDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoServer.DropDatabase(SelectedDatabase);

            LoadMongoTree();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMongoTree();
        }
    }
}
