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
            InitializeDialogs();
            LoadMongoTree();
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
            renameCurrentDatabaseTextBox.Text = node.Name;
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
            EnableButtons(false);

            var databaseName = databaseBackupTextBox.Text;
            var backupFile = backupLocationTextBox.Text;
            FileInfo fi = new FileInfo(backupFile);
            string fileName = fi.Name.Replace(fi.Extension, "");
            var backupLocation = $"{fi.Directory}\\{fileName}";

            try
            {

                BackupDatabase(databaseName, backupLocation);

                Compression.Zip(backupLocation, backupFile);

                if (dropDatabaseCheck.Checked)
                {
                    MongoServer.DropDatabase(databaseName);
                    LoadMongoTree();
                }

                MessageBox.Show($"{databaseName} has been successfully backed up.");
            }
            catch
            {
                MessageBox.Show($"There was an error backing up {databaseName}.");
            }
            finally
            {
                EnableButtons(true);
            }
        }

        private void EnableButtons(bool enabled)
        {
            backupButton.Enabled = enabled;
            importDatabaseButton.Enabled = enabled;
            renameDatabaseButton.Enabled = enabled;
        }

        private void BackupDatabase(string databaseName, string backupLocation)
        {

            var process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "mongodump.exe",
                    Arguments = $"/db:{databaseName} /out:\"{backupLocation}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
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
            EnableButtons(false);

            var fileName = importFileTextBox.Text;
            FileInfo fi = new FileInfo(fileName);
            var guid = Guid.NewGuid();
            var unZipFolder = $"{fi.Directory}\\temp{guid}";
            var newDatabaseName = restoreDatabaseTextBox.Text;

            try
            {

                Compression.UnZip(fileName, unZipFolder);

                var di = new DirectoryInfo(unZipFolder);
                var backupDatabaseName = di.GetDirectories()[0].Name;
                var restoreDatabaseLocation = $"{unZipFolder}\\{backupDatabaseName}";

                RestoreDatabase(newDatabaseName, restoreDatabaseLocation);

                di.Delete(true);

                LoadMongoTree();

                MessageBox.Show($"{newDatabaseName} has been successfully restored.");
            }
            catch
            {
                MessageBox.Show($"There was an error restoring {newDatabaseName}.");
            }
            finally
            {
                EnableButtons(true);
            }
        }

        private void RestoreDatabase(string newDatabaseName, string restoreDatabaseLocation)
        {

            var process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "mongorestore.exe",
                    Arguments = $"/db:{newDatabaseName} /dir:\"{restoreDatabaseLocation}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
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
            EnableButtons(false);

            var currentDatabase = renameCurrentDatabaseTextBox.Text;
            var guid = Guid.NewGuid();
            var tempFolder = $"{DefaultDirectory}\\temp{guid}";

            try
            {

                var newDatabase = renameNewDatabaseTextBox.Text;
                var restoreLocation = $"{tempFolder}\\{currentDatabase}";

                BackupDatabase(currentDatabase, tempFolder);
                RestoreDatabase(newDatabase, restoreLocation);

                MongoServer.DropDatabase(currentDatabase);

                Directory.Delete(tempFolder, true);

                LoadMongoTree();

                MessageBox.Show($"{currentDatabase} has been successfully renamed to {newDatabase}.");
            }
            catch
            {
                MessageBox.Show($"There was an error renaming {currentDatabase}.");
            }
            finally
            {
                EnableButtons(true);
            }
        }
    }
}
