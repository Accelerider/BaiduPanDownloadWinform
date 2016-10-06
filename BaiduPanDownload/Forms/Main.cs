using BaiduPanDownload.Data;
using BaiduPanDownload.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class Main : Form
    {

        string Path = string.Empty;
        readonly string HomePath = "/apps/wp2pcs";

        ArrayList DownloadList = new ArrayList();

        Dictionary<string, FileInfo> Fileinfo = new Dictionary<string, FileInfo>();
        Dictionary<string, HttpDownload> DownloadTaskInfo = new Dictionary<string, HttpDownload>();

        public Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            new Login().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.config.Access_Token == "null" || Program.config.Access_Token == string.Empty)
            {
                MessageBox.Show("你还未登录呢");
                return;
            }
            if (Info_Lab.Text == "正在刷新...")
            {
                return;
            }
            Info_Lab.Text = "正在刷新...";
            SpaceInfo info = JsonConvert.DeserializeObject<SpaceInfo>(WebTool.GetHtml("https://pcs.baidu.com/rest/2.0/pcs/quota?method=info&access_token=" + Program.config.Access_Token));
            Used_Lab.Text = string.Format("网盘已使用: {0} / {1} (GB)",(float)info.used/1024/1024/1024,(float)info.quota/1024/1024/1024);
            new Thread(updateFileList).Start(HomePath+Path);
        }

        void updateFileList(object path)
        {
            try
            {
                Path_Lab.Text = "当前路径:" + path.ToString().Replace("apps", "我的应用数据");
                JObject jobj = JObject.Parse(WebTool.GetHtml(string.Format("https://pcs.baidu.com/rest/2.0/pcs/file?method=list&access_token={0}&path={1}", Program.config.Access_Token, path.ToString())));
                FilelistView.BeginUpdate();
                FilelistView.Items.Clear();
                Fileinfo.Clear();
                foreach (JObject job in jobj["list"])
                {
                    FileInfo fileinfo = JsonConvert.DeserializeObject<FileInfo>(job.ToString());
                    FilelistView.Items.Add(fileinfo.getName());
                    this.Fileinfo.Add(fileinfo.getName(), fileinfo);
                    if (fileinfo.isdir == 1)
                    {
                        setEndItemImageKey("Dir.png");
                    }
                    else
                    {
                        setEndItemImageKey(getIconImage(fileinfo.getSuffix()));
                    }

                }
                FilelistView.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新文件列表时遇到意外的错误: "+ex.Message);
            }
            Info_Lab.Text = "等待中...";
        }

        void setEndItemImageKey(string key)
        {
            FilelistView.Items[FilelistView.Items.Count - 1].ImageKey = key;
        }

        string getIconImage(string suffix)
        {
            switch (suffix)
            {
                case "zip":
                    return "zip.png";
                case "rar":
                    return "zip.png";
                case "exe":
                    return "exe.png";
                default:
                    return "File.png";
            }
        }

        private void FilelistView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FilelistView.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
            {
                FileInfo info = Fileinfo[FilelistView.SelectedItems[0].Text];
                if (info.isdir == 1)
                {
                    Path += "/" + FilelistView.SelectedItems[0].Text;
                    new Thread(updateFileList).Start(HomePath + Path);
                    return;
                }

                new AddDownload(this, info).ShowDialog();
                /*
                try
                {
                    System.Diagnostics.Process.Start(string.Format("https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={0}&path={1}", Program.config.Access_Token,info.path));
                }catch(Exception ex)
                {
                    MessageBox.Show("调用浏览器失败! "+ex.Message);
                }
                */
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            if (Path == string.Empty)
            {
                MessageBox.Show("已经没有目录可以返回了哦");
                return;
            }
            string[] tmp = Path.Split('/');
            Path = Path.Replace("/"+tmp[tmp.Length-1],string.Empty);
            new Thread(updateFileList).Start(HomePath + Path);
        }

        private void 文件信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilelistView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何文件哦");
                return;
            }
            if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            FileInfo info = Fileinfo[FilelistView.SelectedItems[0].Text];
            MessageBox.Show(
                "文件名: " + info.getName() + Environment.NewLine +
                "文件大小: " + (getSizeGB(info.size) < 1 ? getSizeMB(info.size) + " MB" : getSizeGB(info.size) + " GB") + Environment.NewLine +
                "文件路径: " + info.path.Replace("apps", "我的应用数据")+Environment.NewLine+
                "是不是文件夹: "+(info.isdir==1?"是":"不是")
                ,"文件信息"
                );
        }

        float getSizeGB(long byt)
        {
            return (float)byt / 1024 / 1024 / 1024;
        }

        float getSizeMB(long byt)
        {
            return (float)byt / 1024 / 1024;
        }

        private void Help_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "吧要下载的文件放到您百度网盘的 [/我的应用数据/wp2pcs/] 目录,即可在本程序访问"+Environment.NewLine+
                "双击文件为下载;双击目录为打开目录" +Environment.NewLine+
                "文件夹下载请使用右键下载"+Environment.NewLine+
                "如果刷新出现错误,请重新登录!"
                ,"帮助"
                );
        }

        private void Blog_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.mrs4s.top");
            }
            catch (Exception ex)
            {
                MessageBox.Show("调用浏览器失败! " + ex.Message);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 99999;
            if (Program.config.Access_Token == "null" || Program.config.Access_Token == string.Empty)
            {
                return;
            }
            SpaceInfo info = JsonConvert.DeserializeObject<SpaceInfo>(WebTool.GetHtml("https://pcs.baidu.com/rest/2.0/pcs/quota?method=info&access_token=" + Program.config.Access_Token));
            Used_Lab.Text = string.Format("网盘已使用: {0} / {1} (GB)", (float)info.used / 1024 / 1024 / 1024, (float)info.quota / 1024 / 1024 / 1024);
            DownloadListView.View = View.Details;
            new Thread(updateFileList).Start(HomePath + Path);

        }

        public void AddDownloadFile(FileInfo info,string DownloadPath,string FileName)
        {
            HttpDownload download = new HttpDownload
            {
                DownLoadUrl = string.Format("https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={0}&path={1}", Program.config.Access_Token, info.path),
                DownLoadPath = DownloadPath,
                FileName = FileName,
                ThreadNum = 8
            };
            DownloadList.Add(download);
            download.Start();
            ListViewItem item = new ListViewItem();
            item.Text = download.FileName;
            item.SubItems.Add(download.DownLoadPath);
            item.SubItems.Add((getSizeMB((long)download.getSpeed()) < 1 ? (download.getSpeed() / 1024) + "K/s" : getSizeMB((long)download.getSpeed()) + "M/s"));
            item.SubItems.Add(download.getDownloadPercentage() + "%");
            item.SubItems.Add((download.DownloadComplete() ? "下载完成" : "下载中"));
            DownloadListView.Items.Add(item);
            DownloadTaskInfo.Add(download.FileName,download);
        }

        int getDownloadTaskNum()
        {
            int ret = 0;
            for(int i = 0; i < DownloadListView.Items.Count; i++)
            {
                if (DownloadListView.Items[i].SubItems[4].Text == "下载中")
                {
                    ret++;
                }
            }
            return ret;
        }


        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewDir(HomePath + Path).ShowDialog();
            new Thread(updateFileList).Start(HomePath + Path);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilelistView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何文件哦");
                return;
            }
            if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            FileInfo info = Fileinfo[FilelistView.SelectedItems[0].Text];
            if (WebTool.GetHtml(string.Format("https://pcs.baidu.com/rest/2.0/pcs/file?method=delete&access_token={0}&path={1}", Program.config.Access_Token, info.path)).Contains("ERROR"))
            {
                MessageBox.Show("删除失败");
                return;
            }
            new Thread(updateFileList).Start(HomePath + Path);
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void 添加到下载列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilelistView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何文件哦");
                return;
            }
            if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            FileInfo info = Fileinfo[FilelistView.SelectedItems[0].Text];
            //string url = string.Format("https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={0}&path={1}", Program.config.Access_Token, info.path);
            new AddDownload(this, info).ShowDialog();
        }

        private void 复制下载地址ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FilelistView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何文件哦");
                return;
            }
            if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            FileInfo info = Fileinfo[FilelistView.SelectedItems[0].Text];
            if (info.isdir == 1)
            {
                MessageBox.Show("不支持下载文件夹...");
                return;
            }
            try
            {
                Clipboard.SetDataObject(string.Format("https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={0}&path={1}", Program.config.Access_Token, info.path));
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问剪贴板失败! " + ex.Message);
            }
        }

        private void UpdateDownLoadList_Timer_Tick(object sender, EventArgs e)
        {
            DownloadListView.BeginUpdate();
            //DownloadListView.Items.Clear();
            for(int i = 0; i < DownloadList.Count; i++)
            {
                HttpDownload download = (HttpDownload)DownloadList[i];
                DownloadListView.Items[i].SubItems[2].Text = (getSizeMB((long)download.getSpeed()) < 1 ? (download.getSpeed() / 1024) + "K/s" : getSizeMB((long)download.getSpeed()) + "M/s");
                DownloadListView.Items[i].SubItems[3].Text = download.getDownloadPercentage() + "%";
                DownloadListView.Items[i].SubItems[4].Text = download.Stop?"已终止":download.Paste?"暂停中":(download.DownloadComplete() ? "下载完成" : "下载中");
            }
            DownloadListView.EndUpdate();
            return;
            
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadListView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何任务哦");
                return;
            }
            if (!DownloadTaskInfo.ContainsKey(DownloadListView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }

            DownloadTaskInfo[DownloadListView.SelectedItems[0].Text].PasteDownload();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadListView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何任务哦");
                return;
            }
            if (!DownloadTaskInfo.ContainsKey(DownloadListView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }

            DownloadTaskInfo[DownloadListView.SelectedItems[0].Text].ContinueDownload();
        }

        void OpenFolderAndSelectFile(string fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }

        private void 打开目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadListView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何任务哦");
                return;
            }
            if(DownloadListView.SelectedItems[0].SubItems[4].Text=="下载中"|| DownloadListView.SelectedItems[0].SubItems[4].Text == "暂停中" || DownloadListView.SelectedItems[0].SubItems[4].Text == "已终止")
            {
                MessageBox.Show("尚未下载完成");
                return;
            }
            if (!DownloadTaskInfo.ContainsKey(DownloadListView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            OpenFolderAndSelectFile(DownloadTaskInfo[DownloadListView.SelectedItems[0].Text].DownLoadPath + "\\" + DownloadTaskInfo[DownloadListView.SelectedItems[0].Text].FileName);
        }

        private void 终止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadListView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你没有选中任何任务哦");
                return;
            }
            if (DownloadListView.SelectedItems[0].SubItems[4].Text == "下载完成" )
            {
                MessageBox.Show("已经下载完成了，没办法回头了。。");
                return;
            }
            if (!DownloadTaskInfo.ContainsKey(DownloadListView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            DownloadTaskInfo[DownloadListView.SelectedItems[0].Text].StopDownload();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (getDownloadTaskNum() > 0)
            {
                DialogResult dr = MessageBox.Show("你还有任务未完成,退出程序意味着放弃所有下载(其实是我懒没写断点续传),是否继续?", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show("即将开始清理下载产生的临时数据,请等待");
                    foreach(HttpDownload download in DownloadList)
                    {
                        download.StopDownload();
                    }
                }else
                {
                    e.Cancel = true; ;
                }
            }
        }
    }
}
