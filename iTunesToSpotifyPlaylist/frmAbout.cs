using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTunesToSpotifyPlaylist
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

            //Position window in centre of owner window
            this.Top = Owner.Top + (Owner.Height - this.Height) / 2;
            this.Left = Owner.Left + (Owner.Width - this.Width) / 2;

            lblVersion.Text = "Version " + this.ProductVersion;
        }
    }
}
