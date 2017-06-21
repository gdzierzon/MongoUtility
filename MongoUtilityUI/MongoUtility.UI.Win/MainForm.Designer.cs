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
            this.mongoImagesList = new System.Windows.Forms.ImageList(this.components);
            this.backupLocationDialog = new System.Windows.Forms.SaveFileDialog();
            this.restoreFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultBackupDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mongoTree = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mongoServerLabel = new System.Windows.Forms.Label();
            this.progressList = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backupPage = new System.Windows.Forms.TabPage();
            this.dropDatabaseCheck = new System.Windows.Forms.CheckBox();
            this.backupButton = new System.Windows.Forms.Button();
            this.backupLocationButton = new System.Windows.Forms.Button();
            this.backupLocationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseBackupTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.restorePage = new System.Windows.Forms.TabPage();
            this.importDatabaseButton = new System.Windows.Forms.Button();
            this.importFileLocationButton = new System.Windows.Forms.Button();
            this.importFileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.restoreDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clonePage = new System.Windows.Forms.TabPage();
            this.renameDatabaseButton = new System.Windows.Forms.Button();
            this.renameNewDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.renameCurrentDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.databaseContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dropDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.backupPage.SuspendLayout();
            this.restorePage.SuspendLayout();
            this.clonePage.SuspendLayout();
            this.databaseContextMenu.SuspendLayout();
            this.serverContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mongoImagesList
            // 
            this.mongoImagesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mongoImagesList.ImageStream")));
            this.mongoImagesList.TransparentColor = System.Drawing.Color.Transparent;
            this.mongoImagesList.Images.SetKeyName(0, "server");
            this.mongoImagesList.Images.SetKeyName(1, "database");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1053, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultBackupDirectoryToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            // 
            // defaultBackupDirectoryToolStripMenuItem
            // 
            this.defaultBackupDirectoryToolStripMenuItem.Name = "defaultBackupDirectoryToolStripMenuItem";
            this.defaultBackupDirectoryToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.defaultBackupDirectoryToolStripMenuItem.Text = "Default &Backup Directory";
            this.defaultBackupDirectoryToolStripMenuItem.Click += new System.EventHandler(this.defaultBackupDirectoryToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 468);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1053, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mongoTree);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressList);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1053, 444);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // mongoTree
            // 
            this.mongoTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mongoTree.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mongoTree.ImageIndex = 0;
            this.mongoTree.ImageList = this.mongoImagesList;
            this.mongoTree.Location = new System.Drawing.Point(0, 37);
            this.mongoTree.Margin = new System.Windows.Forms.Padding(4);
            this.mongoTree.Name = "mongoTree";
            this.mongoTree.SelectedImageIndex = 0;
            this.mongoTree.Size = new System.Drawing.Size(257, 407);
            this.mongoTree.TabIndex = 2;
            this.mongoTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mongoTree_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.mongoServerLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 37);
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
            // progressList
            // 
            this.progressList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressList.ForeColor = System.Drawing.Color.White;
            this.progressList.FormattingEnabled = true;
            this.progressList.ItemHeight = 19;
            this.progressList.Location = new System.Drawing.Point(0, 163);
            this.progressList.Name = "progressList";
            this.progressList.Size = new System.Drawing.Size(790, 281);
            this.progressList.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.backupPage);
            this.tabControl1.Controls.Add(this.restorePage);
            this.tabControl1.Controls.Add(this.clonePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 163);
            this.tabControl1.TabIndex = 0;
            // 
            // backupPage
            // 
            this.backupPage.Controls.Add(this.dropDatabaseCheck);
            this.backupPage.Controls.Add(this.backupButton);
            this.backupPage.Controls.Add(this.backupLocationButton);
            this.backupPage.Controls.Add(this.backupLocationTextBox);
            this.backupPage.Controls.Add(this.label2);
            this.backupPage.Controls.Add(this.databaseBackupTextBox);
            this.backupPage.Controls.Add(this.label1);
            this.backupPage.Location = new System.Drawing.Point(4, 28);
            this.backupPage.Margin = new System.Windows.Forms.Padding(4);
            this.backupPage.Name = "backupPage";
            this.backupPage.Padding = new System.Windows.Forms.Padding(4);
            this.backupPage.Size = new System.Drawing.Size(782, 131);
            this.backupPage.TabIndex = 0;
            this.backupPage.Text = "Backup";
            this.backupPage.UseVisualStyleBackColor = true;
            // 
            // dropDatabaseCheck
            // 
            this.dropDatabaseCheck.AutoSize = true;
            this.dropDatabaseCheck.Location = new System.Drawing.Point(90, 90);
            this.dropDatabaseCheck.Name = "dropDatabaseCheck";
            this.dropDatabaseCheck.Size = new System.Drawing.Size(129, 23);
            this.dropDatabaseCheck.TabIndex = 6;
            this.dropDatabaseCheck.Text = "Drop Database";
            this.dropDatabaseCheck.UseVisualStyleBackColor = true;
            // 
            // backupButton
            // 
            this.backupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backupButton.Location = new System.Drawing.Point(687, 90);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(86, 33);
            this.backupButton.TabIndex = 5;
            this.backupButton.Text = "Backup";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // backupLocationButton
            // 
            this.backupLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backupLocationButton.Location = new System.Drawing.Point(732, 52);
            this.backupLocationButton.Name = "backupLocationButton";
            this.backupLocationButton.Size = new System.Drawing.Size(41, 27);
            this.backupLocationButton.TabIndex = 4;
            this.backupLocationButton.Text = "...";
            this.backupLocationButton.UseVisualStyleBackColor = true;
            this.backupLocationButton.Click += new System.EventHandler(this.backupLocationButton_Click);
            // 
            // backupLocationTextBox
            // 
            this.backupLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backupLocationTextBox.Location = new System.Drawing.Point(90, 52);
            this.backupLocationTextBox.Name = "backupLocationTextBox";
            this.backupLocationTextBox.Size = new System.Drawing.Size(636, 27);
            this.backupLocationTextBox.TabIndex = 3;
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
            // databaseBackupTextBox
            // 
            this.databaseBackupTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseBackupTextBox.Location = new System.Drawing.Point(90, 10);
            this.databaseBackupTextBox.Name = "databaseBackupTextBox";
            this.databaseBackupTextBox.Size = new System.Drawing.Size(683, 27);
            this.databaseBackupTextBox.TabIndex = 1;
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
            // restorePage
            // 
            this.restorePage.Controls.Add(this.importDatabaseButton);
            this.restorePage.Controls.Add(this.importFileLocationButton);
            this.restorePage.Controls.Add(this.importFileTextBox);
            this.restorePage.Controls.Add(this.label3);
            this.restorePage.Controls.Add(this.restoreDatabaseTextBox);
            this.restorePage.Controls.Add(this.label4);
            this.restorePage.Location = new System.Drawing.Point(4, 28);
            this.restorePage.Margin = new System.Windows.Forms.Padding(4);
            this.restorePage.Name = "restorePage";
            this.restorePage.Padding = new System.Windows.Forms.Padding(4);
            this.restorePage.Size = new System.Drawing.Size(782, 131);
            this.restorePage.TabIndex = 1;
            this.restorePage.Text = "Restore";
            this.restorePage.UseVisualStyleBackColor = true;
            // 
            // importDatabaseButton
            // 
            this.importDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importDatabaseButton.Location = new System.Drawing.Point(687, 90);
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
            this.importFileLocationButton.Location = new System.Drawing.Point(732, 52);
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
            this.importFileTextBox.Location = new System.Drawing.Point(146, 52);
            this.importFileTextBox.Name = "importFileTextBox";
            this.importFileTextBox.Size = new System.Drawing.Size(580, 27);
            this.importFileTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
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
            this.restoreDatabaseTextBox.Location = new System.Drawing.Point(146, 10);
            this.restoreDatabaseTextBox.Name = "restoreDatabaseTextBox";
            this.restoreDatabaseTextBox.Size = new System.Drawing.Size(627, 27);
            this.restoreDatabaseTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Restore Database:";
            // 
            // clonePage
            // 
            this.clonePage.Controls.Add(this.renameDatabaseButton);
            this.clonePage.Controls.Add(this.renameNewDatabaseTextBox);
            this.clonePage.Controls.Add(this.label6);
            this.clonePage.Controls.Add(this.renameCurrentDatabaseTextBox);
            this.clonePage.Controls.Add(this.label5);
            this.clonePage.Location = new System.Drawing.Point(4, 28);
            this.clonePage.Name = "clonePage";
            this.clonePage.Size = new System.Drawing.Size(782, 131);
            this.clonePage.TabIndex = 2;
            this.clonePage.Text = "Clone";
            this.clonePage.UseVisualStyleBackColor = true;
            // 
            // renameDatabaseButton
            // 
            this.renameDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renameDatabaseButton.Location = new System.Drawing.Point(687, 90);
            this.renameDatabaseButton.Name = "renameDatabaseButton";
            this.renameDatabaseButton.Size = new System.Drawing.Size(86, 33);
            this.renameDatabaseButton.TabIndex = 6;
            this.renameDatabaseButton.Text = "Rename";
            this.renameDatabaseButton.UseVisualStyleBackColor = true;
            this.renameDatabaseButton.Click += new System.EventHandler(this.renameDatabaseButton_Click);
            // 
            // renameNewDatabaseTextBox
            // 
            this.renameNewDatabaseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renameNewDatabaseTextBox.Location = new System.Drawing.Point(101, 53);
            this.renameNewDatabaseTextBox.Name = "renameNewDatabaseTextBox";
            this.renameNewDatabaseTextBox.Size = new System.Drawing.Size(672, 27);
            this.renameNewDatabaseTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "New Name:";
            // 
            // renameCurrentDatabaseTextBox
            // 
            this.renameCurrentDatabaseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renameCurrentDatabaseTextBox.Location = new System.Drawing.Point(101, 10);
            this.renameCurrentDatabaseTextBox.Name = "renameCurrentDatabaseTextBox";
            this.renameCurrentDatabaseTextBox.Size = new System.Drawing.Size(672, 27);
            this.renameCurrentDatabaseTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Database:";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select default backup location";
            // 
            // databaseContextMenu
            // 
            this.databaseContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1,
            this.dropDatabaseToolStripMenuItem});
            this.databaseContextMenu.Name = "databaseContextMenu";
            this.databaseContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // dropDatabaseToolStripMenuItem
            // 
            this.dropDatabaseToolStripMenuItem.Name = "dropDatabaseToolStripMenuItem";
            this.dropDatabaseToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.dropDatabaseToolStripMenuItem.Text = "&Drop Database";
            this.dropDatabaseToolStripMenuItem.Click += new System.EventHandler(this.dropDatabaseToolStripMenuItem_Click);
            // 
            // serverContextMenu
            // 
            this.serverContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.serverContextMenu.Name = "serverContextMenu";
            this.serverContextMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem1.Text = "&Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 490);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Mongo Database Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
            this.clonePage.ResumeLayout(false);
            this.clonePage.PerformLayout();
            this.databaseContextMenu.ResumeLayout(false);
            this.serverContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList mongoImagesList;
        private System.Windows.Forms.SaveFileDialog backupLocationDialog;
        private System.Windows.Forms.OpenFileDialog restoreFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView mongoTree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label mongoServerLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage backupPage;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.Button backupLocationButton;
        private System.Windows.Forms.TextBox backupLocationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox databaseBackupTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage restorePage;
        private System.Windows.Forms.Button importDatabaseButton;
        private System.Windows.Forms.Button importFileLocationButton;
        private System.Windows.Forms.TextBox importFileTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox restoreDatabaseTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem defaultBackupDirectoryToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabPage clonePage;
        private System.Windows.Forms.Button renameDatabaseButton;
        private System.Windows.Forms.TextBox renameNewDatabaseTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox renameCurrentDatabaseTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox dropDatabaseCheck;
        private System.Windows.Forms.ContextMenuStrip databaseContextMenu;
        private System.Windows.Forms.ToolStripMenuItem dropDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ListBox progressList;
        private System.Windows.Forms.ContextMenuStrip serverContextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
    }
}

