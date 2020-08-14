namespace WindowsFormsApp3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Close = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWallpaperDir = new System.Windows.Forms.Button();
            this.setNewWallpaperButton = new System.Windows.Forms.Button();
            this.autoSet = new System.Windows.Forms.CheckBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "自动设置锁屏为壁纸";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Close});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // Close
            // 
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(100, 22);
            this.Close.Text = "关闭";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // OpenWallpaperDir
            // 
            this.OpenWallpaperDir.Location = new System.Drawing.Point(12, 12);
            this.OpenWallpaperDir.Name = "OpenWallpaperDir";
            this.OpenWallpaperDir.Size = new System.Drawing.Size(100, 23);
            this.OpenWallpaperDir.TabIndex = 1;
            this.OpenWallpaperDir.Text = "打开壁纸文件夹";
            this.OpenWallpaperDir.UseVisualStyleBackColor = true;
            this.OpenWallpaperDir.Click += new System.EventHandler(this.OpenWallpaperDir_Click);
            // 
            // setNewWallpaperButton
            // 
            this.setNewWallpaperButton.Location = new System.Drawing.Point(12, 41);
            this.setNewWallpaperButton.Name = "setNewWallpaperButton";
            this.setNewWallpaperButton.Size = new System.Drawing.Size(100, 23);
            this.setNewWallpaperButton.TabIndex = 2;
            this.setNewWallpaperButton.Text = "手动设置新壁纸";
            this.setNewWallpaperButton.UseVisualStyleBackColor = true;
            this.setNewWallpaperButton.Click += new System.EventHandler(this.setNewWallpaperButton_Click);
            // 
            // autoSet
            // 
            this.autoSet.AutoSize = true;
            this.autoSet.Location = new System.Drawing.Point(12, 92);
            this.autoSet.Name = "autoSet";
            this.autoSet.Size = new System.Drawing.Size(204, 16);
            this.autoSet.TabIndex = 3;
            this.autoSet.Text = "有新的锁屏壁纸时自动设置为桌面";
            this.autoSet.UseVisualStyleBackColor = true;
            this.autoSet.CheckedChanged += new System.EventHandler(this.autoSetWallpaper_CheckedChanged);
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new System.Drawing.Point(12, 70);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(96, 16);
            this.autoStart.TabIndex = 4;
            this.autoStart.Text = "开机自动运行";
            this.autoStart.UseVisualStyleBackColor = true;
            this.autoStart.CheckedChanged += new System.EventHandler(this.autoStart_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(128, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox1_PreviewKeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 126);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.autoSet);
            this.Controls.Add(this.setNewWallpaperButton);
            this.Controls.Add(this.OpenWallpaperDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "win10置锁屏为壁纸";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button OpenWallpaperDir;
        private System.Windows.Forms.Button setNewWallpaperButton;
        private System.Windows.Forms.CheckBox autoSet;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.CheckBox autoStart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Close;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

