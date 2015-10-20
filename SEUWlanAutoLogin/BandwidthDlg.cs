using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEUWlanAutoLogin
{
    public partial class BandwidthDlg : Form
    {
        NICHttpClient nicClient = new NICHttpClient();
        public SEUUser seuUser;
        public BandwidthDlg()
        {
            InitializeComponent();
        }

        private async void BandwidthDlg_Load(object sender, EventArgs e)
        {
            await nicClient.CampusLogin(seuUser);
            await nicClient.CampusNetUsage();
        }
    }
}
