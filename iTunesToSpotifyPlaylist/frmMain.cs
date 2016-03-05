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
        iTunesApp itunes;

        //============================================================
        // Classes used to store the spotify api response
        //============================================================

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

        //============================================================
        // Form events and form initialisation
        //============================================================

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
            comboPlaylists.Enabled = false;
            cmdGetSpotifyPlaylist.Enabled = false;
            progress.Visible = true;

            //Rearrange ui elements on the form using the current form size
            ui();
        }

        /// <summary>
        /// Runs when the form has been shown
        /// </summary>
        private void frmMain_Shown(object sender, EventArgs e)
        {
            bwLoadITunes.RunWorkerAsync();
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

        //============================================================
        // Background worker to load itunes and combobox
        //============================================================

        private void bwLoadITunes_DoWork(object sender, DoWorkEventArgs e)
        {

            //Report initial progress
            bwLoadITunes.ReportProgress(20);

            //Load iTunes
            itunes = new iTunesLib.iTunesApp();

            //Report progress
            bwLoadITunes.ReportProgress(40);

            //List to store playlists
            List <string> playlists = new List<string>();

            //Integer use for calculating progress
            int i = 1;

            //For each playlist in iTunes
            foreach (IITPlaylist playlist in itunes.LibrarySource.Playlists)
            {

                //Report progress
                bwLoadITunes.ReportProgress(50 + (int)(((50.0 / itunes.LibrarySource.Playlists.Count) * i)));

                //Add playlist to list
                playlists.Add(playlist.Name);

                //Add one to  integer used to calculate progress
                i = i + 1;
            }

            //Pass playlists to background worker result
            e.Result = playlists;
        }

        private void bwLoadITunes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //Set progress bar value
            progress.Value = e.ProgressPercentage;
        }

        private void bwLoadITunes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            //List to store playlists
            List<string> playlists = (List<string>)e.Result;
            
            //For each playlist in playlists
            foreach (string playlist in playlists)
            {

                //Add playlist to combo box
                comboPlaylists.Items.Add(playlist);
            }

            //Tells the datagrid where to get data from
            dataPlaylistGridView.DataSource = dataTable1;

            //Disable and enable different UI elements
            comboPlaylists.Enabled = true;
            cmdGetSpotifyPlaylist.Enabled = true;
            progress.Visible = false;

            //Rearrange ui elements on the form using the current form size
            ui();
        }

        //============================================================
        // Functions to communicate with iTunes and Spotify
        //============================================================

        /// <summary>
        /// Gets the ID of the given song on Spotify
        /// </summary>
        /// <param name="song">The song title</param>
        /// <param name="artist">The song artist</param>
        /// <returns>The ID of the song on Spotify</returns>
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

        //============================================================
        // iTunes playlist object events
        //============================================================

        /// <summary>
        /// Runs when the 'Get Spotify Playlist' button is clicked
        /// </summary>
        private void cmdGetSpotifyPlaylist_Click(object sender, EventArgs e)
        {

            //Display the progress bar
            progress.Visible = true;

            //Disable the playlists combo box
            comboPlaylists.Enabled = false;

            //Disable the 'Get Spotify Playlist' button
            cmdGetSpotifyPlaylist.Enabled = false;

            //Rearrange ui elements on the form using the current form size
            ui();

            //Run background worker to get Spotify IDs
            bwGetSpotifyIds.RunWorkerAsync();
        }

        /// <summary>
        /// Runs when the playlists combo box has been changed
        /// </summary>
        private void comboPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Get name of selected playlist
            string playlist = comboPlaylists.SelectedItem.ToString();

            //Attempt to select playlist
            try
            {

                //For each playlist in iTunes library
                foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
                {

                    //If playlist name is equal to the selected playlist name
                    if (pl.Name == playlist)
                    {
                        //Clear the playlist data table
                        dataTable1.Rows.Clear();

                        //Disable the playlisst combo box
                        comboPlaylists.Enabled = false;

                        //Display progress bar
                        progress.Visible = true;

                        //Disable the 'Get Spotify Playlist' Button
                        cmdGetSpotifyPlaylist.Enabled = false;

                        //Run background worker to get iTunes playlist
                        bwGetITunesPlaylist.RunWorkerAsync(pl);

                        //Rearrange ui elements on the form using the current form size
                        ui();

                        //Break out of for loop
                        break;
                    }
                }
            }

            //If error selecting playlist, display error
            catch
            {
                MessageBox.Show("Error selecting playlist! Did you close iTunes?",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        //============================================================
        // Spotify playlist object events
        //============================================================

        /// <summary>
        /// Runs when the 'Copy Playlist String' button is pressed. Copies playlist
        /// string to clipboard.
        /// </summary>
        private void cmdCopyPlaylistString_Click(object sender, EventArgs e)
        {

            //If string is not empty
            if (txtPlaylistString.Text != "")
            {

                //Copy playlist string to clipboard
                Clipboard.SetText(txtPlaylistString.Text);
            }
        }

        /// <summary>
        /// When the mouse clicks the playlist string text box, Select All.
        /// </summary>
        private void txtPlaylistString_Click(object sender, EventArgs e)
        {
            txtPlaylistString.SelectAll();
            txtPlaylistString.Focus();
        }

        private void cmdConvertAnother_Click(object sender, EventArgs e)
        {
            panelPlaylists.Visible = true;
            panelSpotifyPlaylist.Visible = false;
        }

        //============================================================
        // Background Worker involved in getting Spotify IDs
        //============================================================

        /// <summary>
        /// Class used for returning result in Spotify IDs background worker
        /// </summary>
        public class bwGetSpotifyIdsResult
        {
            public int success_count { get; set; }
            public int failure_count { get; set; }
            public string playlist_string { get; set; }
            public bool success { get; set; }
        }

        /// <summary>
        /// Background worker to get Spotify IDs
        /// </summary>
        private void bwGetSpotifyIds_DoWork(object sender, DoWorkEventArgs e)
        {
            //DateTime to store last success by background worker
            DateTime dateTimeLastSuccess = DateTime.Now;

            //Declare success and failure count as 0
            int success_count = 0;
            int failure_count = 0;

            //Boolean flag to store success
            bool success = true;

            //Declare empty playlist string
            string playlist_string = "";

            //Declare index as 0
            int i = 0;

            //For every row in the data tab;e
            foreach (DataRow row in dataTable1.Rows)
            {
                
                //Report progress
                bwGetSpotifyIds.ReportProgress((int)(((100.0 / dataTable1.Rows.Count) * i)));

                //Get the track ID
                string spotify_track_id;

                //If the column is null or error
                if(row.IsNull("Spotify ID") || row["Spotify ID"] == "Not Found" || row["Spotify ID"] == "Web Error")
                {

                    //Get the track ID
                    spotify_track_id = get_spotify_track_id(row["song name"].ToString(), row["artist"].ToString());
                }

                //Otherwise, get track id from row
                else
                {
                    spotify_track_id = row["Spotify ID"].ToString();
                }

                //Add Spotify ID to data table
                row["Spotify ID"] = spotify_track_id;

                //If error geting Spotify track ID
                if (spotify_track_id == "Not Found" || spotify_track_id == "Web Error")
                {

                    //If nothing has been successful in 30 seconds
                    if(dateTimeLastSuccess.AddSeconds(30) <= DateTime.Now)
                    {

                        //Show error message
                        MessageBox.Show("There seems to be a problem getting Spotify IDs. Do you have an internet connection?");
                        success = false;
                        break;
                    }

                    //Add one to failure count
                    failure_count++;
                }

                //Otherwise, got Spotify track ID successful
                else
                {

                    //Add track to playlist string
                    playlist_string = playlist_string + "spotify:track:" + spotify_track_id + " ";

                    //Update last success DateTime
                    dateTimeLastSuccess = DateTime.Now;

                    //Add one to success count
                    success_count++;
                }

                //Add one to index
                i = i + 1;
            }

            bwGetSpotifyIdsResult result = new bwGetSpotifyIdsResult()
            {
                failure_count = failure_count,
                success_count = success_count,
                playlist_string = playlist_string,
                success = success,
            };
            e.Result = result;
        }

        /// <summary>
        /// Runs when the Background worker to get Spotify IDs changes progress.
        /// </summary>
        private void bwGetSpotifyIds_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //Set progress bar value
            progress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Runs when the Background worker to get Spotify IDs is complete.
        /// </summary>
        private void bwGetSpotifyIds_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //Get result
            bwGetSpotifyIdsResult result = (bwGetSpotifyIdsResult)e.Result;

            //Display statis
            lblStatus.Text = result.success_count + " tracks were converted to a spotify playlist, " + result.failure_count + " failed";

            //Display playlist string
            txtPlaylistString.Text = result.playlist_string;

            //Show spotify playlists panel if successful
            if(result.success == true)
            {

                //Hide playlists panel and show spotify playlists panel
                panelPlaylists.Visible = false;
                panelSpotifyPlaylist.Visible = true;
            }

            //Hide progress bar, show playlists combo boc and show 'Get Spotify Playlist' button
            progress.Visible = false;
            comboPlaylists.Enabled = true;
            cmdGetSpotifyPlaylist.Enabled = true;

            //Rearrange ui elements on the form using the current form size
            ui();
        }

        //============================================================
        // Background Worker involved in getting playlist from iTunes
        //============================================================

        /// <summary>
        /// Background worker to get iTunes playlist
        /// </summary>
        private void bwGetITunesPlaylist_DoWork(object sender, DoWorkEventArgs e)
        {

            //The argument passed is a playlist
            IITPlaylist playlist = (IITPlaylist)e.Argument;

            //Put the playlist tracks in a variable
            IITTrackCollection tracks = playlist.Tracks;

            //Loop for every track in the playlist
            for (int currTrackIndex = 1; currTrackIndex <= tracks.Count; currTrackIndex++)
            {

                //Report progress
                bwGetITunesPlaylist.ReportProgress((int)(((100.0 / tracks.Count) * currTrackIndex)));

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
        /// Runs when the Background worker to get itunes playlist changes progress.
        /// </summary>
        private void bwGetITunesPlaylist_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //Set progress bar value
            progress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Runs when the Background worker to get itunes playlist is complete.
        /// </summary>
        private void bwGetITunesPlaylist_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //Refresh contents of the data playlist grid view
            dataPlaylistGridView.Refresh();

            //Show the playlists combo box, hide the progress bar and enable Get Spotify Playlist button
            comboPlaylists.Enabled = true;
            progress.Visible = false;
            cmdGetSpotifyPlaylist.Enabled = true;

            //Rearrange ui elements on the form using the current form size
            ui();
        }

        //============================================================
        // Menu strip events
        //============================================================

        /// <summary>
        /// Runs when Menu Strip Item (File>Exit) is clicked
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Closes the program
            this.Close();
        }

        /// <summary>
        /// Runs when Menu Strip Item (Help>About) is clicked
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Display about form
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog(this);
        }
    }
}
