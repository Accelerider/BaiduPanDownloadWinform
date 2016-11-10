namespace BaiduPanDownload.Forms
{
    partial class DownloadInfo
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
            this.SubTaskList = new System.Windows.Forms.ListView();
            this.tID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tJD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Update_Timer = new System.Windows.Forms.Timer(this.components);
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重新下载这个子任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubTaskList
            // 
            this.SubTaskList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tID,
            this.tSpeed,
            this.tJD,
            this.tState});
            this.SubTaskList.ContextMenuStrip = this.Menu;
            this.SubTaskList.FullRowSelect = true;
            this.SubTaskList.GridLines = true;
            this.SubTaskList.Location = new System.Drawing.Point(11, 14);
            this.SubTaskList.Name = "SubTaskList";
            this.SubTaskList.Size = new System.Drawing.Size(354, 241);
            this.SubTaskList.TabIndex = 0;
            this.SubTaskList.UseCompatibleStateImageBehavior = false;
            this.SubTaskList.View = System.Windows.Forms.View.Details;
            // 
            // tID
            // 
            this.tID.Text = "任务ID";
            // 
            // tSpeed
            // 
            this.tSpeed.Text = "下载速度";
            this.tSpeed.Width = 85;
            // 
            // tJD
            // 
            this.tJD.Text = "任务进度";
            this.tJD.Width = 86;
            // 
            // tState
            // 
            this.tState.Text = "任务状态";
            this.tState.Width = 116;
            // 
            // Update_Timer
            // 
            this.Update_Timer.Enabled = true;
            this.Update_Timer.Interval = 1000;
            this.Update_Timer.Tick += new System.EventHandler(this.Update_Timer_Tick);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新下载这个子任务ToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(161, 26);
            this.Menu.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_Opening);
            // 
            // 重新下载这个子任务ToolStripMenuItem
            // 
            this.重新下载这个子任务ToolStripMenuItem.Name = "重新下载这个子任务ToolStripMenuItem";
            this.重新下载这个子任务ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.重新下载这个子任务ToolStripMenuItem.Text = "重新下载子任务";
            this.重新下载这个子任务ToolStripMenuItem.Click += new System.EventHandler(this.重新下载这个子任务ToolStripMenuItem_Click);
            // 
            // DownloadInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 269);
            this.Controls.Add(this.SubTaskList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "任务详细信息";
            this.Load += new System.EventHandler(this.DownloadInfo_Load);
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SubTaskList;
        private System.Windows.Forms.ColumnHeader tID;
        private System.Windows.Forms.ColumnHeader tSpeed;
        private System.Windows.Forms.ColumnHeader tJD;
        private System.Windows.Forms.ColumnHeader tState;
        private System.Windows.Forms.Timer Update_Timer;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem 重新下载这个子任务ToolStripMenuItem;
    }
}