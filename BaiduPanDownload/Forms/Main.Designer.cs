namespace BaiduPanDownload.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Used_Lab = new System.Windows.Forms.Label();
            this.FilelistView = new System.Windows.Forms.ListView();
            this.InfoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制下载地址ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加到下载列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.Info_Lab = new System.Windows.Forms.Label();
            this.Path_Lab = new System.Windows.Forms.Label();
            this.Blog_Link = new System.Windows.Forms.LinkLabel();
            this.Back_Button = new System.Windows.Forms.Button();
            this.Help_Link = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadListView = new System.Windows.Forms.ListView();
            this.xID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownLoadPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Speed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Schedule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownLoadListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.状态操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.终止ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateDownLoadList_Timer = new System.Windows.Forms.Timer(this.components);
            this.Test_Button = new System.Windows.Forms.Button();
            this.InfoMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.DownLoadListMenu.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(621, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(592, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "刷新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Used_Lab
            // 
            this.Used_Lab.AutoSize = true;
            this.Used_Lab.Location = new System.Drawing.Point(6, 7);
            this.Used_Lab.Name = "Used_Lab";
            this.Used_Lab.Size = new System.Drawing.Size(107, 12);
            this.Used_Lab.TabIndex = 2;
            this.Used_Lab.Text = "网盘已使用:未刷新";
            // 
            // FilelistView
            // 
            this.FilelistView.AllowDrop = true;
            this.FilelistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilelistView.ContextMenuStrip = this.InfoMenu;
            this.FilelistView.LargeImageList = this.IconList;
            this.FilelistView.Location = new System.Drawing.Point(8, 45);
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.Size = new System.Drawing.Size(659, 410);
            this.FilelistView.TabIndex = 3;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            this.FilelistView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilelistView_DragDrop);
            this.FilelistView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilelistView_DragEnter);
            this.FilelistView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilelistView_KeyDown);
            this.FilelistView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilelistView_MouseDoubleClick);
            // 
            // InfoMenu
            // 
            this.InfoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载ToolStripMenuItem,
            this.文件操作ToolStripMenuItem,
            this.新建文件夹ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.InfoMenu.Name = "InfoMenu";
            this.InfoMenu.Size = new System.Drawing.Size(137, 92);
            this.InfoMenu.Opening += new System.ComponentModel.CancelEventHandler(this.InfoMenu_Opening);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制下载地址ToolStripMenuItem1,
            this.添加到下载列表ToolStripMenuItem});
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.下载ToolStripMenuItem.Text = "下载";
            // 
            // 复制下载地址ToolStripMenuItem1
            // 
            this.复制下载地址ToolStripMenuItem1.Name = "复制下载地址ToolStripMenuItem1";
            this.复制下载地址ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.复制下载地址ToolStripMenuItem1.Text = "复制下载地址";
            this.复制下载地址ToolStripMenuItem1.Click += new System.EventHandler(this.复制下载地址ToolStripMenuItem1_Click);
            // 
            // 添加到下载列表ToolStripMenuItem
            // 
            this.添加到下载列表ToolStripMenuItem.Name = "添加到下载列表ToolStripMenuItem";
            this.添加到下载列表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加到下载列表ToolStripMenuItem.Text = "添加到下载列表";
            this.添加到下载列表ToolStripMenuItem.Click += new System.EventHandler(this.添加到下载列表ToolStripMenuItem_Click);
            // 
            // 文件操作ToolStripMenuItem
            // 
            this.文件操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件信息ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.复制ToolStripMenuItem});
            this.文件操作ToolStripMenuItem.Name = "文件操作ToolStripMenuItem";
            this.文件操作ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.文件操作ToolStripMenuItem.Text = "文件操作";
            // 
            // 文件信息ToolStripMenuItem
            // 
            this.文件信息ToolStripMenuItem.Name = "文件信息ToolStripMenuItem";
            this.文件信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.文件信息ToolStripMenuItem.Text = "文件信息";
            this.文件信息ToolStripMenuItem.Click += new System.EventHandler(this.文件信息ToolStripMenuItem_Click_1);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 新建文件夹ToolStripMenuItem
            // 
            this.新建文件夹ToolStripMenuItem.Name = "新建文件夹ToolStripMenuItem";
            this.新建文件夹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.新建文件夹ToolStripMenuItem.Text = "新建文件夹";
            this.新建文件夹ToolStripMenuItem.Click += new System.EventHandler(this.新建文件夹ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "Dir.png");
            this.IconList.Images.SetKeyName(1, "exe.png");
            this.IconList.Images.SetKeyName(2, "File.png");
            this.IconList.Images.SetKeyName(3, "zip.png");
            // 
            // Info_Lab
            // 
            this.Info_Lab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Info_Lab.AutoSize = true;
            this.Info_Lab.Location = new System.Drawing.Point(598, 32);
            this.Info_Lab.Name = "Info_Lab";
            this.Info_Lab.Size = new System.Drawing.Size(65, 12);
            this.Info_Lab.TabIndex = 5;
            this.Info_Lab.Text = "等待中....";
            // 
            // Path_Lab
            // 
            this.Path_Lab.AutoSize = true;
            this.Path_Lab.Location = new System.Drawing.Point(4, 27);
            this.Path_Lab.Name = "Path_Lab";
            this.Path_Lab.Size = new System.Drawing.Size(179, 12);
            this.Path_Lab.TabIndex = 6;
            this.Path_Lab.Text = "当前路径:/我的应用数据/wp2pcs";
            // 
            // Blog_Link
            // 
            this.Blog_Link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Blog_Link.AutoSize = true;
            this.Blog_Link.Location = new System.Drawing.Point(595, 537);
            this.Blog_Link.Name = "Blog_Link";
            this.Blog_Link.Size = new System.Drawing.Size(101, 12);
            this.Blog_Link.TabIndex = 7;
            this.Blog_Link.TabStop = true;
            this.Blog_Link.Text = "点击进入作者博客";
            this.Blog_Link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Blog_Link_LinkClicked);
            // 
            // Back_Button
            // 
            this.Back_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Back_Button.Location = new System.Drawing.Point(12, 505);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(75, 23);
            this.Back_Button.TabIndex = 8;
            this.Back_Button.Text = "返回上层";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Help_Link
            // 
            this.Help_Link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Help_Link.AutoSize = true;
            this.Help_Link.Location = new System.Drawing.Point(12, 537);
            this.Help_Link.Name = "Help_Link";
            this.Help_Link.Size = new System.Drawing.Size(77, 12);
            this.Help_Link.TabIndex = 9;
            this.Help_Link.TabStop = true;
            this.Help_Link.Text = "不会用请点我";
            this.Help_Link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Help_Link_LinkClicked);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(125, 426);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 26);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 487);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Used_Lab);
            this.tabPage1.Controls.Add(this.Path_Lab);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.Info_Lab);
            this.tabPage1.Controls.Add(this.FilelistView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(673, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "网盘文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.DownloadListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(673, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "下载管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(678, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "注意:本程序自带的下载功能仅仅是能用的程度,建议将下载链接复制到迅雷 IDM等专用下载工具下载!";
            // 
            // DownloadListView
            // 
            this.DownloadListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.xID,
            this.xName,
            this.DownLoadPath,
            this.Speed,
            this.Schedule,
            this.State});
            this.DownloadListView.ContextMenuStrip = this.DownLoadListMenu;
            this.DownloadListView.FullRowSelect = true;
            this.DownloadListView.GridLines = true;
            this.DownloadListView.Location = new System.Drawing.Point(6, 38);
            this.DownloadListView.Name = "DownloadListView";
            this.DownloadListView.Size = new System.Drawing.Size(661, 420);
            this.DownloadListView.TabIndex = 0;
            this.DownloadListView.UseCompatibleStateImageBehavior = false;
            this.DownloadListView.View = System.Windows.Forms.View.Details;
            // 
            // xID
            // 
            this.xID.Text = "ID";
            // 
            // xName
            // 
            this.xName.Text = "文件名";
            this.xName.Width = 146;
            // 
            // DownLoadPath
            // 
            this.DownLoadPath.Text = "文件路径";
            this.DownLoadPath.Width = 147;
            // 
            // Speed
            // 
            this.Speed.Text = "传输速度";
            this.Speed.Width = 113;
            // 
            // Schedule
            // 
            this.Schedule.Text = "传输进度";
            this.Schedule.Width = 97;
            // 
            // State
            // 
            this.State.Text = "状态";
            this.State.Width = 87;
            // 
            // DownLoadListMenu
            // 
            this.DownLoadListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.状态操作ToolStripMenuItem,
            this.打开目录ToolStripMenuItem});
            this.DownLoadListMenu.Name = "DownLoadListMenu";
            this.DownLoadListMenu.Size = new System.Drawing.Size(125, 48);
            this.DownLoadListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DownLoadListMenu_Opening);
            // 
            // 状态操作ToolStripMenuItem
            // 
            this.状态操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂停ToolStripMenuItem,
            this.开始ToolStripMenuItem,
            this.终止ToolStripMenuItem});
            this.状态操作ToolStripMenuItem.Name = "状态操作ToolStripMenuItem";
            this.状态操作ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.状态操作ToolStripMenuItem.Text = "状态操作";
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.暂停ToolStripMenuItem.Text = "暂停";
            this.暂停ToolStripMenuItem.Click += new System.EventHandler(this.暂停ToolStripMenuItem_Click);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始ToolStripMenuItem.Text = "继续";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // 终止ToolStripMenuItem
            // 
            this.终止ToolStripMenuItem.Name = "终止ToolStripMenuItem";
            this.终止ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.终止ToolStripMenuItem.Text = "终止";
            this.终止ToolStripMenuItem.Click += new System.EventHandler(this.终止ToolStripMenuItem_Click);
            // 
            // 打开目录ToolStripMenuItem
            // 
            this.打开目录ToolStripMenuItem.Name = "打开目录ToolStripMenuItem";
            this.打开目录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开目录ToolStripMenuItem.Text = "打开目录";
            this.打开目录ToolStripMenuItem.Click += new System.EventHandler(this.打开目录ToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(673, 461);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "暂无。。有时间就写上";
            // 
            // UpdateDownLoadList_Timer
            // 
            this.UpdateDownLoadList_Timer.Enabled = true;
            this.UpdateDownLoadList_Timer.Interval = 1000;
            this.UpdateDownLoadList_Timer.Tick += new System.EventHandler(this.UpdateDownLoadList_Timer_Tick);
            // 
            // Test_Button
            // 
            this.Test_Button.Location = new System.Drawing.Point(305, 523);
            this.Test_Button.Name = "Test_Button";
            this.Test_Button.Size = new System.Drawing.Size(75, 23);
            this.Test_Button.TabIndex = 12;
            this.Test_Button.Text = "Test";
            this.Test_Button.UseVisualStyleBackColor = true;
            this.Test_Button.Visible = false;
            this.Test_Button.Click += new System.EventHandler(this.Test_Button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 558);
            this.Controls.Add(this.Test_Button);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Help_Link);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.Blog_Link);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "老司机高速坐骑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.InfoMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.DownLoadListMenu.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Used_Lab;
        private System.Windows.Forms.ListView FilelistView;
        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.Label Info_Lab;
        private System.Windows.Forms.Label Path_Lab;
        private System.Windows.Forms.LinkLabel Blog_Link;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.ContextMenuStrip InfoMenu;
        private System.Windows.Forms.LinkLabel Help_Link;
        private System.Windows.Forms.ToolStripMenuItem 新建文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView DownloadListView;
        private System.Windows.Forms.ColumnHeader DownLoadPath;
        private System.Windows.Forms.ColumnHeader Speed;
        private System.Windows.Forms.ColumnHeader Schedule;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader xName;
        private System.Windows.Forms.ContextMenuStrip DownLoadListMenu;
        private System.Windows.Forms.ToolStripMenuItem 状态操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开目录ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制下载地址ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加到下载列表ToolStripMenuItem;
        private System.Windows.Forms.Timer UpdateDownLoadList_Timer;
        private System.Windows.Forms.ToolStripMenuItem 终止ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.Button Test_Button;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ColumnHeader xID;
        private System.Windows.Forms.Label label2;
    }
}