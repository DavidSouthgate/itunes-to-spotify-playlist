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
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace iTunesToSpotifyPlaylist
{
    public partial class frmMain : Form
    {
        iTunesApp itunes = new iTunesLib.iTunesApp();

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

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            //For each playlist in iTunes
            foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
            {

                //Add playlist name to combo box
                comboPlaylists.Items.Add(pl.Name);
            }
            
            //Load entire library playlist into variable
            //IITLibraryPlaylist mainLibrary = itunes.LibraryPlaylist;

            //Display the entire library
            //GetTracks(mainLibrary);

            //Tells the datagrid where to get data from
            dataPlaylistGridView.DataSource = dataTable1;

            //Position UI elements
            ui();
        }

        private void GetTracks(IITPlaylist playlist)
        {
            long totalfilesize = 0;
            dataTable1.Rows.Clear();
            IITTrackCollection tracks = playlist.Tracks;
            int numTracks = tracks.Count;
            for (int currTrackIndex = 1; currTrackIndex <= numTracks; currTrackIndex++)
            {
                DataRow drnew = dataTable1.NewRow();
                IITTrack currTrack = tracks[currTrackIndex];
                drnew["artist"] = currTrack.Artist;
                drnew["song name"] = currTrack.Name;
                drnew["album"] = currTrack.Album;
                drnew["genre"] = currTrack.Genre;

                if (currTrack.Kind == ITTrackKind.ITTrackKindFile)
                {
                    IITFileOrCDTrack file = (IITFileOrCDTrack)currTrack;
                    if (file.Location != null)
                    {
                        FileInfo fi = new FileInfo(file.Location);
                        if (fi.Exists)
                        {
                            drnew["FileLocation"] = file.Location;
                            totalfilesize += fi.Length;
                        }
                        else
                            drnew["FileLocation"] = "not found " + file.Location;
                    }
                }

                dataTable1.Rows.Add(drnew);
            }
            //lbl_numsongs.Text = "number of songs: " + dataTable1.Rows.Count.ToString() + ", total file size: " + (totalfilesize / 1024.00 / 1024.00).ToString("#,### mb");
        }






        private string get_spotify_track_id(string song, string artist)
        {

            //Generate a safe query to use with the spotify api
            string query = WebUtility.UrlEncode(artist + " " + song);

            //Create a new web client to contact spotify api
            WebClient client = new WebClient();

            //Get json response from spotify api
            string api_json = client.DownloadString("https://api.spotify.com/v1/search?q=" + query + "&type=track&limit=1");

            spotify_api api = JsonConvert.DeserializeObject<spotify_api>(api_json);

            return api.tracks.items[0].id;
        }




        private void ui()
        {
            //
            //panelPlaylists
            //
            panelPlaylists.Top = 0;
            panelPlaylists.Left = 0;
            panelPlaylists.Width = this.ClientSize.Width;
            panelPlaylists.Height = this.ClientSize.Height;
            //
            //comboPlaylists
            //
            comboPlaylists.Top = 14;
            comboPlaylists.Left = 14;
            comboPlaylists.Width = panelPlaylists.Width - 14 - 14;
            //
            //dataPlaylistGridView
            //
            dataPlaylistGridView.Top = comboPlaylists.Top + comboPlaylists.Height + 6;
            dataPlaylistGridView.Left = 14;
            dataPlaylistGridView.Width = panelPlaylists.Width - 14 - 14;
            dataPlaylistGridView.Height = this.ClientSize.Height - dataPlaylistGridView.Top - 14 - cmdGetSpotifyPlaylist.Height;
            //
            //cmdGetSpotifyPlaylist
            //
            cmdGetSpotifyPlaylist.Top = dataPlaylistGridView.Top + dataPlaylistGridView.Height + 6;
            cmdGetSpotifyPlaylist.Left = 14;
            cmdGetSpotifyPlaylist.Width = panelPlaylists.Width - 14 - 14;

            //
            //panelSpotifyPlaylist
            //
            panelSpotifyPlaylist.Top = 0;
            panelSpotifyPlaylist.Left = 0;
            panelSpotifyPlaylist.Width = this.ClientSize.Width;
            panelSpotifyPlaylist.Height = this.ClientSize.Height;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            ui();
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

        private void cmdGetSpotifyPlaylist_Click(object sender, EventArgs e)
        {

            int success_count = 0;
            int failure_count = 0;
            string playlist_text = "";

            foreach (DataRow row in dataTable1.Rows)
            {
                try
                {
                    playlist_text = playlist_text + "spotify:track:" + get_spotify_track_id(row["song name"].ToString(), row["artist"].ToString()) + " ";
                    success_count++;
                }
                 catch
                {
                    failure_count++;
                }
            }

            lblStatus.Text = success_count + " tracks were converted to a spotify playlist, " + failure_count + " failed";

            if(playlist_text != "")
            {
                Clipboard.SetText(playlist_text);
            }

            panelPlaylists.Visible = false;
            panelSpotifyPlaylist.Visible = true;
        }
    }
}
