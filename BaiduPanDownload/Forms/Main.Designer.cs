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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuperDLSize_Textbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NetSpeed_TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.DownloadPath_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateDownLoadList_Timer = new System.Windows.Forms.Timer(this.components);
            this.Test_Button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.InfoMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.DownLoadListMenu.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage4);
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
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(44, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "注意:百度更新后已限速,使用高速下载能在一定程度上提速(双击高速下载的任务可进入查看详情)";
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
            this.DownloadListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DownloadListView_MouseDoubleClick);
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
            this.状态操作ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.状态操作ToolStripMenuItem.Text = "状态操作";
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.暂停ToolStripMenuItem.Text = "暂停";
            this.暂停ToolStripMenuItem.Click += new System.EventHandler(this.暂停ToolStripMenuItem_Click);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.开始ToolStripMenuItem.Text = "继续";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // 终止ToolStripMenuItem
            // 
            this.终止ToolStripMenuItem.Name = "终止ToolStripMenuItem";
            this.终止ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.终止ToolStripMenuItem.Text = "终止";
            this.终止ToolStripMenuItem.Click += new System.EventHandler(this.终止ToolStripMenuItem_Click);
            // 
            // 打开目录ToolStripMenuItem
            // 
            this.打开目录ToolStripMenuItem.Name = "打开目录ToolStripMenuItem";
            this.打开目录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
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
            this.tabPage3.Text = "账号管理";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "尚未完成。。";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(673, 461);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Save_Button);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.DownloadPath_TextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 449);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "下载设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.SuperDLSize_Textbox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.NetSpeed_TextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(8, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 292);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "加速下载设置";
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(144, 417);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(102, 27);
            this.Save_Button.TabIndex = 7;
            this.Save_Button.Text = "保存";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(374, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "说明:如果小文件使用加速下载可能会出现意料之外的错误,请酌情设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "MB使用加速下载";
            // 
            // SuperDLSize_Textbox
            // 
            this.SuperDLSize_Textbox.Location = new System.Drawing.Point(174, 86);
            this.SuperDLSize_Textbox.Name = "SuperDLSize_Textbox";
            this.SuperDLSize_Textbox.Size = new System.Drawing.Size(65, 21);
            this.SuperDLSize_Textbox.TabIndex = 4;
            this.SuperDLSize_Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SuperDLSize_Textbox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "文件大小超过";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(377, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "说明:根据物理带宽进行下载加速,请如实填写,填写过高会加大出错风险";
            // 
            // NetSpeed_TextBox
            // 
            this.NetSpeed_TextBox.Location = new System.Drawing.Point(173, 28);
            this.NetSpeed_TextBox.MaxLength = 3;
            this.NetSpeed_TextBox.Name = "NetSpeed_TextBox";
            this.NetSpeed_TextBox.Size = new System.Drawing.Size(65, 21);
            this.NetSpeed_TextBox.TabIndex = 1;
            this.NetSpeed_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetSpeed_TextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "物理带宽(M)";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(354, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DownloadPath_TextBox
            // 
            this.DownloadPath_TextBox.Location = new System.Drawing.Point(89, 67);
            this.DownloadPath_TextBox.Name = "DownloadPath_TextBox";
            this.DownloadPath_TextBox.ReadOnly = true;
            this.DownloadPath_TextBox.Size = new System.Drawing.Size(259, 21);
            this.DownloadPath_TextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "默认下载路径";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "说明:下载线程越大理论速度越快,但也越容易出错";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "下载线程";
            // 
            // ComboBox
            // 
            this.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.ComboBox.Location = new System.Drawing.Point(65, 18);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(49, 20);
            this.ComboBox.TabIndex = 0;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(518, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 22);
            this.label11.TabIndex = 1;
            this.label11.Text = "说明";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(410, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(266, 187);
            this.label12.TabIndex = 2;
            this.label12.Text = "百度更新后进行了限速,目前绝大多数破解客户端\r\n已经失效,这个坐骑还能用多久不清楚,但是在还能\r\n用的情况下我就会坚持更新.\r\n目前更新了[高速下载],但是目前版" +
    "本还不够稳定,\r\n可能会出现下到最后没速度的情况,如果出现\r\n\r\n请 双击任务->选择没速度的子任务->重新下载\r\n\r\n我将会尽快在下个版本在根本上解决这个问题" +
    "\r\n最后如果觉得程序不错的话记得在Github上star\r\n一下哦";
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DownloadPath_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NetSpeed_TextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SuperDLSize_Textbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}