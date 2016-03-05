namespace iTunesToSpotifyPlaylist
{
    partial class frmMain
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
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.panelPlaylists = new System.Windows.Forms.Panel();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.cmdGetSpotifyPlaylist = new System.Windows.Forms.Button();
            this.dataPlaylistGridView = new System.Windows.Forms.DataGridView();
            this.comboPlaylists = new System.Windows.Forms.ComboBox();
            this.bwGetITunesPlaylist = new System.ComponentModel.BackgroundWorker();
            this.panelSpotifyPlaylist = new System.Windows.Forms.Panel();
            this.cmdConvertAnother = new System.Windows.Forms.Button();
            this.cmdCopyPlaylistString = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.bwGetSpotifyIds = new System.ComponentModel.BackgroundWorker();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPlaylistString = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panelPlaylists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlaylistGridView)).BeginInit();
            this.panelSpotifyPlaylist.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn6});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "Song Name";
            this.dataColumn1.ColumnName = "Song Name";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Artist";
            this.dataColumn2.ColumnName = "Artist";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Spotify ID";
            // 
            // panelPlaylists
            // 
            this.panelPlaylists.Controls.Add(this.progress);
            this.panelPlaylists.Controls.Add(this.cmdGetSpotifyPlaylist);
            this.panelPlaylists.Controls.Add(this.dataPlaylistGridView);
            this.panelPlaylists.Controls.Add(this.comboPlaylists);
            this.panelPlaylists.Location = new System.Drawing.Point(62, 46);
            this.panelPlaylists.Name = "panelPlaylists";
            this.panelPlaylists.Size = new System.Drawing.Size(639, 316);
            this.panelPlaylists.TabIndex = 4;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(4, 261);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(632, 23);
            this.progress.TabIndex = 3;
            this.progress.Visible = false;
            // 
            // cmdGetSpotifyPlaylist
            // 
            this.cmdGetSpotifyPlaylist.Location = new System.Drawing.Point(4, 290);
            this.cmdGetSpotifyPlaylist.Name = "cmdGetSpotifyPlaylist";
            this.cmdGetSpotifyPlaylist.Size = new System.Drawing.Size(632, 23);
            this.cmdGetSpotifyPlaylist.TabIndex = 2;
            this.cmdGetSpotifyPlaylist.Text = "Get Spotify Playlist";
            this.cmdGetSpotifyPlaylist.UseVisualStyleBackColor = true;
            this.cmdGetSpotifyPlaylist.Click += new System.EventHandler(this.cmdGetSpotifyPlaylist_Click);
            // 
            // dataPlaylistGridView
            // 
            this.dataPlaylistGridView.AllowUserToAddRows = false;
            this.dataPlaylistGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataPlaylistGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPlaylistGridView.Location = new System.Drawing.Point(4, 30);
            this.dataPlaylistGridView.Name = "dataPlaylistGridView";
            this.dataPlaylistGridView.Size = new System.Drawing.Size(632, 226);
            this.dataPlaylistGridView.TabIndex = 1;
            // 
            // comboPlaylists
            // 
            this.comboPlaylists.FormattingEnabled = true;
            this.comboPlaylists.Location = new System.Drawing.Point(3, 3);
            this.comboPlaylists.Name = "comboPlaylists";
            this.comboPlaylists.Size = new System.Drawing.Size(633, 21);
            this.comboPlaylists.TabIndex = 0;
            this.comboPlaylists.Text = "Playlists";
            this.comboPlaylists.SelectedIndexChanged += new System.EventHandler(this.comboPlaylists_SelectedIndexChanged);
            // 
            // bwGetITunesPlaylist
            // 
            this.bwGetITunesPlaylist.WorkerReportsProgress = true;
            this.bwGetITunesPlaylist.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetITunesPlaylist_DoWork);
            this.bwGetITunesPlaylist.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGetITunesPlaylist_ProgressChanged);
            this.bwGetITunesPlaylist.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetITunesPlaylist_RunWorkerCompleted);
            // 
            // panelSpotifyPlaylist
            // 
            this.panelSpotifyPlaylist.Controls.Add(this.txtPlaylistString);
            this.panelSpotifyPlaylist.Controls.Add(this.cmdConvertAnother);
            this.panelSpotifyPlaylist.Controls.Add(this.cmdCopyPlaylistString);
            this.panelSpotifyPlaylist.Controls.Add(this.lblInstructions);
            this.panelSpotifyPlaylist.Controls.Add(this.lblStatus);
            this.panelSpotifyPlaylist.Location = new System.Drawing.Point(23, 30);
            this.panelSpotifyPlaylist.Name = "panelSpotifyPlaylist";
            this.panelSpotifyPlaylist.Size = new System.Drawing.Size(599, 257);
            this.panelSpotifyPlaylist.TabIndex = 5;
            this.panelSpotifyPlaylist.Visible = false;
            // 
            // cmdConvertAnother
            // 
            this.cmdConvertAnother.Location = new System.Drawing.Point(4, 228);
            this.cmdConvertAnother.Name = "cmdConvertAnother";
            this.cmdConvertAnother.Size = new System.Drawing.Size(582, 23);
            this.cmdConvertAnother.TabIndex = 4;
            this.cmdConvertAnother.Text = "Convert Another Playlist";
            this.cmdConvertAnother.UseVisualStyleBackColor = true;
            this.cmdConvertAnother.Click += new System.EventHandler(this.cmdConvertAnother_Click);
            // 
            // cmdCopyPlaylistString
            // 
            this.cmdCopyPlaylistString.Location = new System.Drawing.Point(7, 46);
            this.cmdCopyPlaylistString.Name = "cmdCopyPlaylistString";
            this.cmdCopyPlaylistString.Size = new System.Drawing.Size(579, 23);
            this.cmdCopyPlaylistString.TabIndex = 3;
            this.cmdCopyPlaylistString.Text = "Copy Playlist String";
            this.cmdCopyPlaylistString.UseVisualStyleBackColor = true;
            this.cmdCopyPlaylistString.Click += new System.EventHandler(this.cmdCopyPlaylistString_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(4, 72);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(383, 108);
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = "To add playlist to spotify:\r\n1. Copy playlist string.\r\n2. Create a new playlist i" +
    "n Spotify and give it a name.\r\n3. Press CTRL+V when in the new empty playlist.";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(4, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "STATUS";
            // 
            // bwGetSpotifyIds
            // 
            this.bwGetSpotifyIds.WorkerReportsProgress = true;
            this.bwGetSpotifyIds.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetSpotifyIds_DoWork);
            this.bwGetSpotifyIds.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwGetSpotifyIds_ProgressChanged);
            this.bwGetSpotifyIds.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetSpotifyIds_RunWorkerCompleted);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(713, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txtPlaylistString
            // 
            this.txtPlaylistString.Location = new System.Drawing.Point(7, 21);
            this.txtPlaylistString.Name = "txtPlaylistString";
            this.txtPlaylistString.Size = new System.Drawing.Size(579, 20);
            this.txtPlaylistString.TabIndex = 5;
            this.txtPlaylistString.Text = "";
            this.txtPlaylistString.Click += new System.EventHandler(this.txtPlaylistString_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 380);
            this.Controls.Add(this.panelSpotifyPlaylist);
            this.Controls.Add(this.panelPlaylists);
            this.Controls.Add(this.menuStrip);
            this.Name = "frmMain";
            this.Text = "iTunes to Spotify Playlist";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panelPlaylists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPlaylistGridView)).EndInit();
            this.panelSpotifyPlaylist.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.Panel panelPlaylists;
        private System.Windows.Forms.DataGridView dataPlaylistGridView;
        private System.Windows.Forms.ComboBox comboPlaylists;
        private System.Windows.Forms.Button cmdGetSpotifyPlaylist;
        private System.ComponentModel.BackgroundWorker bwGetITunesPlaylist;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.Panel panelSpotifyPlaylist;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button cmdCopyPlaylistString;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button cmdConvertAnother;
        private System.Windows.Forms.ProgressBar progress;
        private System.ComponentModel.BackgroundWorker bwGetSpotifyIds;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtPlaylistString;
    }
}

