namespace MongoUtility.UI.Win
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mongoServerLabel = new System.Windows.Forms.Label();
            this.mongoTree = new System.Windows.Forms.TreeView();
            this.mongoImagesList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backupPage = new System.Windows.Forms.TabPage();
            this.restorePage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.databaseBackupTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backupLocationTextBox = new System.Windows.Forms.TextBox();
            this.backupLocationButton = new System.Windows.Forms.Button();
            this.backupLocationDialog = new System.Windows.Forms.SaveFileDialog();
            this.backupButton = new System.Windows.Forms.Button();
            this.restoreFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.importDatabaseButton = new System.Windows.Forms.Button();
            this.importFileLocationButton = new System.Windows.Forms.Button();
            this.importFileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.restoreDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.backupPage.SuspendLayout();
            this.restorePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mongoTree);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 427);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.mongoServerLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 36);
            this.panel1.TabIndex = 0;
            // 
            // mongoServerLabel
            // 
            this.mongoServerLabel.AutoSize = true;
            this.mongoServerLabel.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mongoServerLabel.Location = new System.Drawing.Point(9, 7);
            this.mongoServerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mongoServerLabel.Name = "mongoServerLabel";
            this.mongoServerLabel.Size = new System.Drawing.Size(127, 23);
            this.mongoServerLabel.TabIndex = 0;
            this.mongoServerLabel.Text = "Mongo Server";
            // 
            // mongoTree
            // 
            this.mongoTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mongoTree.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mongoTree.ImageIndex = 0;
            this.mongoTree.ImageList = this.mongoImagesList;
            this.mongoTree.Location = new System.Drawing.Point(0, 36);
            this.mongoTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mongoTree.Name = "mongoTree";
            this.mongoTree.SelectedImageIndex = 0;
            this.mongoTree.Size = new System.Drawing.Size(241, 391);
            this.mongoTree.TabIndex = 1;
            this.mongoTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mongoTree_NodeMouseClick);
            // 
            // mongoImagesList
            // 
            this.mongoImagesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mongoImagesList.ImageStream")));
            this.mongoImagesList.TransparentColor = System.Drawing.Color.Transparent;
            this.mongoImagesList.Images.SetKeyName(0, "server");
            this.mongoImagesList.Images.SetKeyName(1, "database");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.backupPage);
            this.tabControl1.Controls.Add(this.restorePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // backupPage
            // 
            this.backupPage.Controls.Add(this.backupButton);
            this.backupPage.Controls.Add(this.backupLocationButton);
            this.backupPage.Controls.Add(this.backupLocationTextBox);
            this.backupPage.Controls.Add(this.label2);
            this.backupPage.Controls.Add(this.databaseBackupTextBox);
            this.backupPage.Controls.Add(this.label1);
            this.backupPage.Location = new System.Drawing.Point(4, 28);
            this.backupPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backupPage.Name = "backupPage";
            this.backupPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backupPage.Size = new System.Drawing.Size(660, 395);
            this.backupPage.TabIndex = 0;
            this.backupPage.Text = "Backup";
            this.backupPage.UseVisualStyleBackColor = true;
            // 
            // restorePage
            // 
            this.restorePage.Controls.Add(this.importDatabaseButton);
            this.restorePage.Controls.Add(this.importFileLocationButton);
            this.restorePage.Controls.Add(this.importFileTextBox);
            this.restorePage.Controls.Add(this.label3);
            this.restorePage.Controls.Add(this.restoreDatabaseTextBox);
            this.restorePage.Controls.Add(this.label4);
            this.restorePage.Location = new System.Drawing.Point(4, 28);
            this.restorePage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.restorePage.Name = "restorePage";
            this.restorePage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.restorePage.Size = new System.Drawing.Size(660, 395);
            this.restorePage.TabIndex = 1;
            this.restorePage.Text = "Restore";
            this.restorePage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database:";
            // 
            // databaseBackupTextBox
            // 
            this.databaseBackupTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseBackupTextBox.Location = new System.Drawing.Point(90, 10);
            this.databaseBackupTextBox.Name = "databaseBackupTextBox";
            this.databaseBackupTextBox.Size = new System.Drawing.Size(561, 27);
            this.databaseBackupTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Backup:";
            // 
            // backupLocationTextBox
            // 
            this.backupLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backupLocationTextBox.Location = new System.Drawing.Point(90, 52);
            this.backupLocationTextBox.Name = "backupLocationTextBox";
            this.backupLocationTextBox.Size = new System.Drawing.Size(514, 27);
            this.backupLocationTextBox.TabIndex = 3;
            // 
            // backupLocationButton
            // 
            this.backupLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backupLocationButton.Location = new System.Drawing.Point(610, 52);
            this.backupLocationButton.Name = "backupLocationButton";
            this.backupLocationButton.Size = new System.Drawing.Size(41, 27);
            this.backupLocationButton.TabIndex = 4;
            this.backupLocationButton.Text = "...";
            this.backupLocationButton.UseVisualStyleBackColor = true;
            this.backupLocationButton.Click += new System.EventHandler(this.backupLocationButton_Click);
            // 
            // backupLocationDialog
            // 
            this.backupLocationDialog.Filter = "All Files | *.* | Zip | *.zip | GZip | *.gzip | Bak | *.bak";
            this.backupLocationDialog.InitialDirectory = "E:\\backups\\mongo";
            // 
            // backupButton
            // 
            this.backupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backupButton.Location = new System.Drawing.Point(565, 354);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(86, 33);
            this.backupButton.TabIndex = 5;
            this.backupButton.Text = "Backup";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // restoreFileDialog
            // 
            this.restoreFileDialog.Filter = "All Files | *.* | Zip | *.zip | GZip | *.gzip | Bak | *.bak";
            this.restoreFileDialog.InitialDirectory = "E:\\backups\\mongo";
            // 
            // importDatabaseButton
            // 
            this.importDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importDatabaseButton.Location = new System.Drawing.Point(566, 353);
            this.importDatabaseButton.Name = "importDatabaseButton";
            this.importDatabaseButton.Size = new System.Drawing.Size(86, 33);
            this.importDatabaseButton.TabIndex = 11;
            this.importDatabaseButton.Text = "Restore";
            this.importDatabaseButton.UseVisualStyleBackColor = true;
            this.importDatabaseButton.Click += new System.EventHandler(this.importDatabaseButton_Click);
            // 
            // importFileLocationButton
            // 
            this.importFileLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importFileLocationButton.Location = new System.Drawing.Point(611, 51);
            this.importFileLocationButton.Name = "importFileLocationButton";
            this.importFileLocationButton.Size = new System.Drawing.Size(41, 27);
            this.importFileLocationButton.TabIndex = 10;
            this.importFileLocationButton.Text = "...";
            this.importFileLocationButton.UseVisualStyleBackColor = true;
            this.importFileLocationButton.Click += new System.EventHandler(this.importFileLocationButton_Click);
            // 
            // importFileTextBox
            // 
            this.importFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importFileTextBox.Location = new System.Drawing.Point(147, 51);
            this.importFileTextBox.Name = "importFileTextBox";
            this.importFileTextBox.Size = new System.Drawing.Size(458, 27);
            this.importFileTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Backup File:";
            // 
            // restoreDatabaseTextBox
            // 
            this.restoreDatabaseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreDatabaseTextBox.Location = new System.Drawing.Point(147, 9);
            this.restoreDatabaseTextBox.Name = "restoreDatabaseTextBox";
            this.restoreDatabaseTextBox.Size = new System.Drawing.Size(505, 27);
            this.restoreDatabaseTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Restore Database:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 427);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Mongo Database Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.backupPage.ResumeLayout(false);
            this.backupPage.PerformLayout();
            this.restorePage.ResumeLayout(false);
            this.restorePage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView mongoTree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label mongoServerLabel;
        private System.Windows.Forms.ImageList mongoImagesList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage backupPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage restorePage;
        private System.Windows.Forms.TextBox databaseBackupTextBox;
        private System.Windows.Forms.Button backupLocationButton;
        private System.Windows.Forms.TextBox backupLocationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog backupLocationDialog;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.OpenFileDialog restoreFileDialog;
        private System.Windows.Forms.Button importDatabaseButton;
        private System.Windows.Forms.Button importFileLocationButton;
        private System.Windows.Forms.TextBox importFileTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox restoreDatabaseTextBox;
        private System.Windows.Forms.Label label4;
    }
}

