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
    public partial class Form1 : Form
    {
        const int BaloonDelayTime = 1111;

        SEUHttpClient myClient = new SEUHttpClient();
        SEUUser seuUser = new SEUUser();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            labelAddr.Text = "";
            labelIP.Text = "";
            labelSuccess.Text = "";

            this.notifyIcon1.Icon = Properties.Resources.IconNotConnected;
            this.Icon = Properties.Resources.IconConnected;

            SEUConfig newConfig = new SEUConfig();
            newConfig.ReadConfig();
            checkBoxAutoLogin.Checked = newConfig.bAutoLog;
            checkBoxSavePwd.Checked = newConfig.bSavePwd;
            textBoxStuID.Text = newConfig.StuID;
            seuUser.StuID = newConfig.StuID;
            textBoxPwd.Text = newConfig.Pwd;
            seuUser.Pwd = newConfig.Pwd;

            
            if (newConfig.bAutoLog)
            {

                await SEUFooLogin(seuUser);
            }
            if (newConfig.StuID == "0")//
            {
                this.WindowState = FormWindowState.Normal;
            }
            else 
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }

        }

        private void MainWindow_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private async Task<SEUAuthJson> SEUFooLogin(SEUUser seuUser)
        {
            var netStatus = await myClient.CampusNetIsLogin();
            if(netStatus.StuID != "0" )
            {
                string baloonText = "当前已登录\r\n一卡通：" + netStatus.StuID + "，IP：" + netStatus.IpAddr +"，地点：" + netStatus.Location;
                notifyIcon1.ShowBalloonTip(BaloonDelayTime, "无需重复连接", baloonText, System.Windows.Forms.ToolTipIcon.Info);

                labelIP.Text = "IP：" + netStatus.IpAddr;
                labelAddr.Text = "地点：" + netStatus.Location;
                labelSuccess.Text = "当前已登录";

                return new SEUAuthJson();
            }
            else
            {
                var loginResponse = await myClient.CampusNetLogin(seuUser);
                if(loginResponse.error == null)
                {
                    string baloonText = "一卡通：" + loginResponse.login_username + "，IP：" + loginResponse.login_ip + "，地点：" + loginResponse.login_location;
                    notifyIcon1.ShowBalloonTip(BaloonDelayTime, "连接成功", baloonText, System.Windows.Forms.ToolTipIcon.Info);

                    labelIP.Text = "IP：" + netStatus.IpAddr;
                    labelAddr.Text = "地点：" + netStatus.Location;
                    labelSuccess.Text = "登录成功";

                    notifyIcon1.Icon = Properties.Resources.IconConnected;
                }
                else
                {
                    labelSuccess.Text = "登录失败！";
                    labelIP.Text = "请检查网络连接，核对用户名和密码。";
                    labelAddr.Text = "";
                    notifyIcon1.ShowBalloonTip(BaloonDelayTime, "登录失败！", "请检查网络连接，核对用户名和密码。", System.Windows.Forms.ToolTipIcon.Error);
                }
                

                return loginResponse;
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            bool bSavePwd = checkBoxSavePwd.Checked;
            bool bAutoLogin = checkBoxAutoLogin.Checked;
            seuUser = new SEUUser(textBoxStuID.Text, textBoxPwd.Text);
            SEUConfig newConfig = new SEUConfig();
            newConfig.StuID = seuUser.StuID;
            newConfig.Pwd = seuUser.Pwd;
            newConfig.bSavePwd = bSavePwd;
            newConfig.bAutoLog = bAutoLogin;
            
            var netStatus = await SEUFooLogin(seuUser);
            if(netStatus.error == null)
            {
                newConfig.SaveToJson();//登录成功，帐号密码，配置参数保存到磁盘
            }
        }

        private async void Connect_Click(object sender, EventArgs e)
        {
            seuUser = new SEUUser(textBoxStuID.Text, textBoxPwd.Text);
            await SEUFooLogin(seuUser);
        }

        private async Task<bool> SEUFooLogout()
        {
            var netStatus = await myClient.CampusNetIsLogin();
            if (netStatus.StuID != "0") //已连接
            {
                var s = await myClient.CampusNetLogout();                
                notifyIcon1.ShowBalloonTip(BaloonDelayTime, "断开成功", "校园网断开成功！", System.Windows.Forms.ToolTipIcon.Info);

                labelIP.Text = "IP：" + netStatus.IpAddr;
                labelAddr.Text = "地点：" + netStatus.Location;
                labelSuccess.Text = "断开成功";

                notifyIcon1.Icon = Properties.Resources.IconNotConnected;

                return true;
            }
            else
            {
                notifyIcon1.ShowBalloonTip(BaloonDelayTime, "当前未连接", "无需断开！", System.Windows.Forms.ToolTipIcon.Info);

                labelIP.Text = "IP：" + netStatus.IpAddr;
                labelAddr.Text = "地点：" + netStatus.Location;
                labelSuccess.Text = "当前未连接";

                return false;
            }

        }

        private async void buttonLogout_Click(object sender, EventArgs e)
        {
            await SEUFooLogout();
        }

        private async void DisConnect_Click(object sender, EventArgs e)
        {
            await SEUFooLogout();
        }

        private async Task SEUFooStatus()
        {
            var netStatus = await myClient.CampusNetIsLogin();

            labelIP.Text = "IP：" + netStatus.IpAddr;
            labelAddr.Text = "地点：" + netStatus.Location;

            if (netStatus.StuID != "0") //已连接
            {
                string baloonText = "当前已登录\r\n一卡通：" + netStatus.StuID + "，IP：" + netStatus.IpAddr + "，地点：" + netStatus.Location;
                notifyIcon1.ShowBalloonTip(BaloonDelayTime, "当前已连接", baloonText, System.Windows.Forms.ToolTipIcon.Info);
                labelSuccess.Text = "当前已连接";
            }
            else
            {
                string baloonText = "未连接！\r\n当前IP：" + netStatus.IpAddr + "，地点：" + netStatus.Location;
                notifyIcon1.ShowBalloonTip(BaloonDelayTime, "当前未连接", baloonText, System.Windows.Forms.ToolTipIcon.Info);
                labelSuccess.Text = "当前未连接";
            }
        }

        private async void buttonRefreshNetStates_Click(object sender, EventArgs e)
        {
            await SEUFooStatus();
        }

        private async void Status_Click(object sender, EventArgs e)
        {
            await SEUFooStatus();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            var netStatus = await myClient.CampusNetIsLogin();
            if (netStatus.StuID != "0") //已连接
            {
                notifyIcon1.Icon = Properties.Resources.IconConnected;
            }
            else
            {
                notifyIcon1.Icon = Properties.Resources.IconNotConnected;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainWindow_Click(null, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
