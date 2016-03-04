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
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.panelPlaylists = new System.Windows.Forms.Panel();
            this.cmdGetSpotifyPlaylist = new System.Windows.Forms.Button();
            this.dataPlaylistGridView = new System.Windows.Forms.DataGridView();
            this.comboPlaylists = new System.Windows.Forms.ComboBox();
            this.bwGetITunesPlaylist = new System.ComponentModel.BackgroundWorker();
            this.dataColumn6 = new System.Data.DataColumn();
            this.panelSpotifyPlaylist = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panelPlaylists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlaylistGridView)).BeginInit();
            this.panelSpotifyPlaylist.SuspendLayout();
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
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
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
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Album";
            this.dataColumn3.ColumnName = "Album";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Genre";
            this.dataColumn4.ColumnName = "Genre";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "FileLocation";
            // 
            // panelPlaylists
            // 
            this.panelPlaylists.Controls.Add(this.cmdGetSpotifyPlaylist);
            this.panelPlaylists.Controls.Add(this.dataPlaylistGridView);
            this.panelPlaylists.Controls.Add(this.comboPlaylists);
            this.panelPlaylists.Location = new System.Drawing.Point(62, 46);
            this.panelPlaylists.Name = "panelPlaylists";
            this.panelPlaylists.Size = new System.Drawing.Size(639, 316);
            this.panelPlaylists.TabIndex = 4;
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
            this.dataPlaylistGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPlaylistGridView.Location = new System.Drawing.Point(4, 30);
            this.dataPlaylistGridView.Name = "dataPlaylistGridView";
            this.dataPlaylistGridView.Size = new System.Drawing.Size(632, 254);
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
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Spotify ID";
            // 
            // panelSpotifyPlaylist
            // 
            this.panelSpotifyPlaylist.Controls.Add(this.lblStatus);
            this.panelSpotifyPlaylist.Controls.Add(this.textBox1);
            this.panelSpotifyPlaylist.Location = new System.Drawing.Point(12, 12);
            this.panelSpotifyPlaylist.Name = "panelSpotifyPlaylist";
            this.panelSpotifyPlaylist.Size = new System.Drawing.Size(599, 257);
            this.panelSpotifyPlaylist.TabIndex = 5;
            this.panelSpotifyPlaylist.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(4, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "lblStatus";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 380);
            this.Controls.Add(this.panelSpotifyPlaylist);
            this.Controls.Add(this.panelPlaylists);
            this.Name = "frmMain";
            this.Text = "iTunes to Spotify Playlist";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panelPlaylists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPlaylistGridView)).EndInit();
            this.panelSpotifyPlaylist.ResumeLayout(false);
            this.panelSpotifyPlaylist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.Panel panelPlaylists;
        private System.Windows.Forms.DataGridView dataPlaylistGridView;
        private System.Windows.Forms.ComboBox comboPlaylists;
        private System.Windows.Forms.Button cmdGetSpotifyPlaylist;
        private System.ComponentModel.BackgroundWorker bwGetITunesPlaylist;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.Panel panelSpotifyPlaylist;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblStatus;
    }
}

