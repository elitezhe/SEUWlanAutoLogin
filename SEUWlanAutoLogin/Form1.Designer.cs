namespace SEUWlanAutoLogin
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxStuID = new System.Windows.Forms.TextBox();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonRefreshNetStates = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.DisConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.ToolStripMenuItem();
            this.MainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxAutoLogin = new System.Windows.Forms.CheckBox();
            this.checkBoxSavePwd = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxStuID
            // 
            this.textBoxStuID.Location = new System.Drawing.Point(97, 175);
            this.textBoxStuID.Name = "textBoxStuID";
            this.textBoxStuID.Size = new System.Drawing.Size(155, 21);
            this.textBoxStuID.TabIndex = 1;
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(97, 214);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.PasswordChar = '#';
            this.textBoxPwd.Size = new System.Drawing.Size(155, 21);
            this.textBoxPwd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "一卡通:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码:";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(37, 258);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Text = "连接";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(125, 258);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 8;
            this.buttonLogout.Text = "断开";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // buttonRefreshNetStates
            // 
            this.buttonRefreshNetStates.Location = new System.Drawing.Point(219, 258);
            this.buttonRefreshNetStates.Name = "buttonRefreshNetStates";
            this.buttonRefreshNetStates.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshNetStates.TabIndex = 12;
            this.buttonRefreshNetStates.Text = "刷新";
            this.buttonRefreshNetStates.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "东南大学校园网快捷管理工具";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Connect,
            this.DisConnect,
            this.Status,
            this.MainWindow});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 92);
            // 
            // Connect
            // 
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(112, 22);
            this.Connect.Text = "连接";
            // 
            // DisConnect
            // 
            this.DisConnect.Name = "DisConnect";
            this.DisConnect.Size = new System.Drawing.Size(112, 22);
            this.DisConnect.Text = "断开";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(112, 22);
            this.Status.Text = "状态";
            // 
            // MainWindow
            // 
            this.MainWindow.Name = "MainWindow";
            this.MainWindow.Size = new System.Drawing.Size(112, 22);
            this.MainWindow.Text = "主窗口";
            this.MainWindow.Click += new System.EventHandler(this.MainWindow_Click);
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(180, 241);
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoLogin.TabIndex = 13;
            this.checkBoxAutoLogin.Text = "自动登录";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = true;
            // 
            // checkBoxSavePwd
            // 
            this.checkBoxSavePwd.AutoSize = true;
            this.checkBoxSavePwd.Location = new System.Drawing.Point(97, 241);
            this.checkBoxSavePwd.Name = "checkBoxSavePwd";
            this.checkBoxSavePwd.Size = new System.Drawing.Size(72, 16);
            this.checkBoxSavePwd.TabIndex = 14;
            this.checkBoxSavePwd.Text = "保存密码";
            this.checkBoxSavePwd.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 330);
            this.Controls.Add(this.checkBoxSavePwd);
            this.Controls.Add(this.checkBoxAutoLogin);
            this.Controls.Add(this.buttonRefreshNetStates);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.textBoxStuID);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "东南大学校园网登录系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStuID;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonRefreshNetStates;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Connect;
        private System.Windows.Forms.ToolStripMenuItem DisConnect;
        private System.Windows.Forms.ToolStripMenuItem MainWindow;
        private System.Windows.Forms.ToolStripMenuItem Status;
        private System.Windows.Forms.CheckBox checkBoxAutoLogin;
        private System.Windows.Forms.CheckBox checkBoxSavePwd;
    }
}

