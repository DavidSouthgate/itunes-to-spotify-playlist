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

namespace iTunesToSpotifyPlaylist
{
    public partial class frmMain : Form
    {
        iTunesApp itunes = new iTunesLib.iTunesApp();

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
            IITLibraryPlaylist mainLibrary = itunes.LibraryPlaylist;

            //Display the entire library
            GetTracks(mainLibrary);

            //Tells the datagrid where to get data from
            dataGridView1.DataSource = dataTable1;
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
    }
}
