using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoUtility.Common.Mongo;
using MongoUtility.Common.SharpZip;

namespace MongoUtility.UI.Win
{
    public partial class MainForm : Form
    {
        private Process BackupProcess;
        public string BackupFile { get; set; }
        public string BackupFolder { get; set; }
        public Server MongoServer { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MongoServer = new Server("localhost");


            var serverNode = new TreeNode(MongoServer.ServerName)
            {
                ImageIndex = 0,
                SelectedImageIndex = 0,
                Name = ""
            };

            foreach (var database in MongoServer.DatabaseList)
            {
                var databaseNode = new TreeNode(database)
                {
                    ImageIndex = 1,
                    SelectedImageIndex = 1,
                    Name = database
                };
                serverNode.Nodes.Add(databaseNode);
            }

            mongoTree.Nodes.Add(serverNode);
            serverNode.ExpandAll();
        }

        private void mongoTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            databaseBackupTextBox.Text = node.Name;
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

            BackupFile = backupLocationTextBox.Text;
            FileInfo fi = new FileInfo(BackupFile);
            string fileName = fi.Name.Replace(fi.Extension, "");
            BackupFolder = $"{fi.Directory}\\{fileName}";


            BackupProcess = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "mongodump.exe",
                    Arguments = $"/db:{databaseBackupTextBox.Text} /out:\"{BackupFolder}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            BackupProcess.Start();
            string output = BackupProcess.StandardOutput.ReadToEnd();
            string error = BackupProcess.StandardError.ReadToEnd();
            BackupProcess.WaitForExit();

            Compression.Zip(BackupFolder, BackupFile);
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
            var fileName = importFileTextBox.Text;
            FileInfo fi = new FileInfo(fileName);
            var guid = Guid.NewGuid();
            var unZipFolder = $"{fi.Directory}\\temp{guid}";
            var newDatabaseName = restoreDatabaseTextBox.Text;

            Compression.UnZip(fileName, unZipFolder);

            var di = new DirectoryInfo(unZipFolder);
            var backupDatabaseName = di.GetDirectories()[0].Name;
            var restoreDataBaseLocation = $"{unZipFolder}\\{backupDatabaseName}";
            
            var process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "mongorestore.exe",
                    Arguments = $"/db:{newDatabaseName} /dir:\"{restoreDataBaseLocation}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false
                }
            };
            process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            di.Delete(true);
        }
    }
}
