using BaiduPanDownload.HttpTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class DownloadInfo : Form
    {
        public SuperDownload info { get; set; }

        public DownloadInfo()
        {
            InitializeComponent();
        }

        private void DownloadInfo_Load(object sender, EventArgs e)
        {
            if (info == null)
            {
                MessageBox.Show("出现未知错误!");
                this.Close();
            }
            for (int id = 0; id < info.SubTaskNum; id++)
            {
                var SubTask = info.GetTaskByID(id);
                if (SubTask == null)
                {
                    Update_Timer.Stop();
                    MessageBox.Show("任务尚未初始化完成!");
                    this.Close();
                    break;
                }
            }
        }

        private void Update_Timer_Tick(object sender, EventArgs e)
        {
            for (int id = 0; id < info.SubTaskNum; id++)
            {
                var SubTask = info.GetTaskByID(id);
                if (SubTaskList.Items.Count == id)
                {
                    ListViewItem Item = new ListViewItem();
                    Item.Text = id.ToString();
                    Item.SubItems.Add((getSizeMB((long)SubTask.GetSpeed()) < 1 ? (SubTask.GetSpeed() / 1024) + "K/s" : getSizeMB((long)SubTask.GetSpeed()) + "M/s"));
                    Item.SubItems.Add(SubTask.GetPercentage()+"%");
                    Item.SubItems.Add(SubTask.State.ToString());
                    SubTaskList.Items.Add(Item);
                    continue;
                }
                SubTaskList.Items[id].SubItems[1].Text = (getSizeMB((long)SubTask.GetSpeed()) < 1 ? (SubTask.GetSpeed() / 1024) + "K/s" : getSizeMB((long)SubTask.GetSpeed()) + "M/s");
                SubTaskList.Items[id].SubItems[2].Text = SubTask.GetPercentage() + "%";
                SubTaskList.Items[id].SubItems[3].Text = SubTask.State.ToString();
            }
        }

        float getSizeMB(long byt)
        {
            return (float)byt / 1024 / 1024;
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {
            if (SubTaskList.SelectedItems.Count < 1)
            {
                e.Cancel = true;
            }
        }

        private void 重新下载这个子任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.ReDownload(int.Parse(SubTaskList.SelectedItems[0].Text));
        }
    }
}
