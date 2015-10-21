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
        List<List<string>> netUsageList;
        int deviceNums;

        public BandwidthDlg()
        {
            InitializeComponent();
        }

        private async void BandwidthDlg_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            await nicClient.CampusLogin(seuUser);
            netUsageList = await nicClient.CampusNetUsage();
            if (netUsageList.Count>0)
            {
	            deviceNums = netUsageList.Count - 1;
	            labelUsedBd.Text = netUsageList.ElementAt(netUsageList.Count - 1).ElementAt(1);
	
	            const int lineSpace = 20;
	            for(int i =0; i<deviceNums; i++)
	            {
	                Label col1 = new Label();
	                col1.Text = netUsageList.ElementAt(i).ElementAt(0);
	                col1.Location = new Point(10, 80 + lineSpace * i);
	                col1.AutoSize = true; 
	                this.panel1.Controls.Add(col1);
                    
	
	                Label col2 = new Label();
	                col2.Text = netUsageList.ElementAt(i).ElementAt(1);
	                col2.Location = new Point(100, 80 + lineSpace * i);
	                col2.AutoSize = true; 
	                this.panel1.Controls.Add(col2);
	
	                Label col3 = new Label();
	                col3.Text = netUsageList.ElementAt(i).ElementAt(2);
	                col3.Location = new Point(200, 80 + lineSpace * i);
	                col3.AutoSize = true; 
	                this.panel1.Controls.Add(col3);
	
	                Button button = new Button();
	                button.Location = new Point(300, 80 + lineSpace * i -5);
	                button.Size = new Size(50, 20);
	                button.Text = "下线";
	                button.Tag = netUsageList.ElementAt(i); //IP作为tag数据
	                button.Click += new System.EventHandler(this.buttonLogoutClick);
	                this.panel1.Controls.Add(button);
	            }
            }
            else
            { MessageBox.Show("无已登录终端！"); }

        }
        private async void buttonLogoutClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var OfflineInfo = button.Tag as List<string>;
            string ipToKick = OfflineInfo.ElementAt(1);
            string sessionId = OfflineInfo.ElementAt(4);
            string nasIp = OfflineInfo.ElementAt(5);

            await nicClient.CampusKickIP(ipToKick, sessionId, nasIp);
            

            BandwidthDlg_Load(null, null);

        }
        
    }
}
