/* The MIT License (MIT)
 *
 * Copyright (c) 2016 David Southgate
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTunesLib;
using Newtonsoft.Json;
using System.Net;

namespace iTunesToSpotifyPlaylist
{
    public partial class frmMain : Form
    {
        iTunesApp itunes = new iTunesLib.iTunesApp();

        //========================================================
        // Classes used to store the spotify api response
        //========================================================

        public class spotify_api
        {
            public spotify_api_tracks tracks { get; set; }
        }

        public class spotify_api_tracks
        {
            public List<spotify_api_tracks_items> items { get; set; }
        }

        public class spotify_api_tracks_items
        {
            public string id { get; set; }
        }

        //========================================================
        // Form events and form initialisation
        //========================================================

        public frmMain()
        {
            InitializeComponent();

            //Set the minimum size that the form can be
            this.MinimumSize = new Size(300, 300);
        }

        /// <summary>
        /// Runs when the form has been loaded
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            //For each playlist in iTunes
            foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
            {

                //Add playlist name to combo box
                comboPlaylists.Items.Add(pl.Name);
            }

            //Tells the datagrid where to get data from
            dataPlaylistGridView.DataSource = dataTable1;

            //Rearrange ui elements on the form using the current form size
            ui();
        }

        /// <summary>
        /// Runs when the form has been resized
        /// </summary>
        private void frmMain_Resize(object sender, EventArgs e)
        {

            //Rearrange ui elements on the form using the current form size
            ui();
        }

        /// <summary>
        /// Rearrange ui elements on the form using the current form size
        /// </summary>
        private void ui()
        {
            //
            //panelPlaylists
            //
            panelPlaylists.Top = menuStrip.Height;
            panelPlaylists.Left = 0;
            panelPlaylists.Width = this.ClientSize.Width;
            panelPlaylists.Height = this.ClientSize.Height;
            //
            //comboPlaylists
            //
            comboPlaylists.Top = 6;
            comboPlaylists.Left = 14;
            comboPlaylists.Width = panelPlaylists.Width - 14 - 14;

            if (progress.Visible == true)
            {
                //
                //dataPlaylistGridView
                //
                dataPlaylistGridView.Top = comboPlaylists.Top + comboPlaylists.Height + 6;
                dataPlaylistGridView.Left = 14;
                dataPlaylistGridView.Width = panelPlaylists.Width - 14 - 14;
                dataPlaylistGridView.Height = this.ClientSize.Height - dataPlaylistGridView.Top - 6 - progress.Height - 6 - cmdGetSpotifyPlaylist.Height - 14 - menuStrip.Height;
                //
                //progress
                //
                progress.Top = dataPlaylistGridView.Top + dataPlaylistGridView.Height + 6;
                progress.Left = 14;
                progress.Width = panelPlaylists.Width - 14 - 14;
                //
                //cmdGetSpotifyPlaylist
                //
                cmdGetSpotifyPlaylist.Top = progress.Top + progress.Height + 6;
                cmdGetSpotifyPlaylist.Left = 14;
                cmdGetSpotifyPlaylist.Width = panelPlaylists.Width - 14 - 14;
            }
            else
            {
                //
                //dataPlaylistGridView
                //
                dataPlaylistGridView.Top = comboPlaylists.Top + comboPlaylists.Height + 6;
                dataPlaylistGridView.Left = 14;
                dataPlaylistGridView.Width = panelPlaylists.Width - 14 - 14;
                dataPlaylistGridView.Height = this.ClientSize.Height - dataPlaylistGridView.Top - 6 - cmdGetSpotifyPlaylist.Height - 14 - menuStrip.Height;
                //
                //cmdGetSpotifyPlaylist
                //
                cmdGetSpotifyPlaylist.Top = dataPlaylistGridView.Top + dataPlaylistGridView.Height + 6;
                cmdGetSpotifyPlaylist.Left = 14;
                cmdGetSpotifyPlaylist.Width = panelPlaylists.Width - 14 - 14;
            }

            //
            //panelSpotifyPlaylist
            //
            panelSpotifyPlaylist.Top = menuStrip.Height;
            panelSpotifyPlaylist.Left = 0;
            panelSpotifyPlaylist.Width = this.ClientSize.Width;
            panelSpotifyPlaylist.Height = this.ClientSize.Height;
            //
            //lblStatus
            //
            lblStatus.Top = 6;
            lblStatus.Left = 14;
            lblStatus.Width = this.ClientSize.Width - 14 - 14;
            using (Graphics cg = CreateGraphics())
            {
                //Measure the size of the text on the button
                SizeF size = cg.MeasureString(lblStatus.Text, lblStatus.Font, lblStatus.Width);
                //Set the button height to the height of the text
                lblStatus.Height = (int)size.Height;
            }
            //
            //txtPlaylistString
            //
            txtPlaylistString.Top = lblStatus.Top + lblStatus.Height + 6;
            txtPlaylistString.Left = 14;
            txtPlaylistString.Width = this.ClientSize.Width - 14 - 14;
            //
            //cmdCopyPlaylistString
            //
            cmdCopyPlaylistString.Top = txtPlaylistString.Top + txtPlaylistString.Height + 6;
            cmdCopyPlaylistString.Left = 14;
            cmdCopyPlaylistString.Width = this.ClientSize.Width - 14 - 14;
            //
            //lblInstructions
            //
            lblInstructions.Top = cmdCopyPlaylistString.Top + cmdCopyPlaylistString.Height + 6;
            lblInstructions.Left = 14;
            lblInstructions.Width = this.ClientSize.Width - 14 - 14;
            lblInstructions.Height = this.ClientSize.Height - lblInstructions.Top;
            //
            //cmdGetSpotifyPlaylist
            //
            cmdConvertAnother.Top = ClientSize.Height - cmdConvertAnother.Height - 14 - menuStrip.Height;
            cmdConvertAnother.Left = 14;
            cmdConvertAnother.Width = this.ClientSize.Width - 14 - 14;
        }

        //========================================================
        // Functions to communicate with iTunes and Spotify
        //========================================================

        /// <summary>
        /// Display playlist items in datagrid
        /// </summary>
        /// <param name="playlist">The playlist to display</param>
        private void GetTracks(IITPlaylist playlist)
        {

            //Clear the playlist data table
            dataTable1.Rows.Clear();

            //Put the playlist tracks in a variable
            IITTrackCollection tracks = playlist.Tracks;

            //Loop for every track in the playlist
            for (int currTrackIndex = 1; currTrackIndex <= tracks.Count; currTrackIndex++)
            {

                //Declare variable for new row
                DataRow drnew = dataTable1.NewRow();

                //Get details of current track
                IITTrack currTrack = tracks[currTrackIndex];

                //Set artist and song name in new row
                drnew["artist"] = currTrack.Artist;
                drnew["song name"] = currTrack.Name;

                //Add bew row to the data table
                dataTable1.Rows.Add(drnew);
            }
        }

        /// <summary>
        /// Gets the ID of the given song on Spotify
        /// </summary>
        /// <param name="song">The song title</param>
        /// <param name="artist">The song artist</param>
        /// <returns></returns>
        private string get_spotify_track_id(string song, string artist)
        {

            //Generate a safe query to use with the spotify api
            string query = WebUtility.UrlEncode(artist + " " + song);

            //Create a new web client to contact spotify api
            WebClient client = new WebClient();

            //Declare api json as empty string
            string api_json = "";

            //Attempt to get the json response from the spotify api
            try
            {
                //Get json response from spotify api
                api_json = client.DownloadString("https://api.spotify.com/v1/search?q=" + query + "&type=track&limit=1");
            }

            //If error getting json response
            catch
            {

                //Declare the datetime that this point was reached
                DateTime start = DateTime.Now;

                //BOOLEAN flag changed when valid responce given
                bool success = false;

                //Loop for 10 seconds
                while (start.AddSeconds(10) >= DateTime.Now && success == false)
                {

                    //Attempt to get the json response from the spotify api
                    try
                    {
                        //Get json response from spotify api
                        api_json = client.DownloadString("https://api.spotify.com/v1/search?q=" + query + "&type=track&limit=1");

                        //Set boolean success flag to true
                        success = true;
                    }

                    //If error getting json response, do nothing
                    catch { }
                }

                //If no sucess, return web error
                if(success == false)
                {
                    return "Web Error";
                }
            }

            //Attempt to deserialize json to object
            try
            {

                //Deserialize json to object
                spotify_api api = JsonConvert.DeserializeObject<spotify_api>(api_json);

                //Return Spotify track ID
                return api.tracks.items[0].id;
            }

            //If error deserializing json to object
            catch
            {

                //Return not found error
                return "Not Found";
            }
        }

        //========================================================
        // iTunes playlist object events
        //========================================================

        private void cmdGetSpotifyPlaylist_Click(object sender, EventArgs e)
        {
            progress.Visible = true;
            comboPlaylists.Enabled = false;
            cmdGetSpotifyPlaylist.Enabled = false;
            ui();
            bwGetSpotifyIds.RunWorkerAsync();
        }

        private void comboPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            string playlist = comboPlaylists.SelectedItem.ToString();
            foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
            {
                if (pl.Name == playlist)
                {
                    GetTracks(pl);
                    break;
                }
            }
        }

        //========================================================
        // Spotify playlist object events
        //========================================================

        private void cmdCopyPlaylistString_Click(object sender, EventArgs e)
        {
            if (txtPlaylistString.Text != "")
            {
                Clipboard.SetText(txtPlaylistString.Text);
            }
        }

        private void txtPlaylistString_MouseClick(object sender, MouseEventArgs e)
        {
            txtPlaylistString.SelectAll();
            txtPlaylistString.Focus();
        }

        private void cmdConvertAnother_Click(object sender, EventArgs e)
        {
            panelPlaylists.Visible = true;
            panelSpotifyPlaylist.Visible = false;
        }

        //========================================================
        // Background Worker involved in getting Spotify IDs
        //========================================================

        public class bwGetSpotifyIdsResult
        {
            public int success_count { get; set; }
            public int failure_count { get; set; }
            public string playlist_string { get; set; }
        }

        private void bwGetSpotifyIds_DoWork(object sender, DoWorkEventArgs e)
        {
            int success_count = 0;
            int failure_count = 0;
            string playlist_string = "";
            int i = 0;

            foreach (DataRow row in dataTable1.Rows)
            {
                int progress = (int)(((100.0 / dataTable1.Rows.Count) * i));
                bwGetSpotifyIds.ReportProgress(progress);
                string spotify_track_id = get_spotify_track_id(row["song name"].ToString(), row["artist"].ToString());
                playlist_string = playlist_string + "spotify:track:" + spotify_track_id + " ";
                row["Spotify ID"] = spotify_track_id;
                i = i + 1;

                if(spotify_track_id == "Not Found" || spotify_track_id == "Web Error")
                {
                    failure_count++;
                }

                else
                {
                    success_count++;
                }
            }

            bwGetSpotifyIdsResult result = new bwGetSpotifyIdsResult()
            {
                failure_count = failure_count,
                success_count = success_count,
                playlist_string = playlist_string,
            };
            e.Result = result;
        }

        private void bwGetSpotifyIds_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void bwGetSpotifyIds_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwGetSpotifyIdsResult result = (bwGetSpotifyIdsResult)e.Result;

            lblStatus.Text = result.success_count + " tracks were converted to a spotify playlist, " + result.failure_count + " failed";

            txtPlaylistString.Text = result.playlist_string;

            panelPlaylists.Visible = false;
            panelSpotifyPlaylist.Visible = true;

            progress.Visible = false;
            comboPlaylists.Enabled = true;
            cmdGetSpotifyPlaylist.Enabled = true;

            //Rearrange ui elements on the form using the current form size
            ui();
        }

        //========================================================
        // Menu strip events
        //========================================================

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog(this);
        }
    }
}
