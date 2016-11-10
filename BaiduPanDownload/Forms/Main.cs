using BaiduPanDownload.Data;
using BaiduPanDownload.HttpTool;
using BaiduPanDownload.Managers;
using BaiduPanDownload.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        Dictionary<string, DiskFileInfo> Fileinfo = new Dictionary<string, DiskFileInfo>();
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
                var jobj = JObject.Parse(WebTool.GetHtml($"https://pcs.baidu.com/rest/2.0/pcs/file?method=list&access_token={Program.config.Access_Token}&path="+ Uri.EscapeDataString($"{path.ToString()}")));
                FilelistView.BeginUpdate();
                FilelistView.Items.Clear();
                Fileinfo.Clear();
                foreach (JObject job in jobj["list"])
                {
                    DiskFileInfo fileinfo = JsonConvert.DeserializeObject<DiskFileInfo>(job.ToString());
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
                MessageBox.Show("更新文件列表时遇到意外的错误: "+ex.ToString());
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
                DiskFileInfo info = Fileinfo[FilelistView.SelectedItems[0].Text];
                if (info.isdir == 1)
                {
                    Path += "/" + FilelistView.SelectedItems[0].Text;
                    new Thread(this.updateFileList).Start(HomePath + Path);
                    return;
                }
                if (info.getSuffix() == "mp4" || info.getSuffix()=="mkv")
                {
                    new Video
                    {
                        info=info
                    }.Show();
                    return;
                }
                new AddDownload(this, info).ShowDialog();
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

        private void 文件信息ToolStripMenuItem_Click_1(object sender, EventArgs e)
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
            DiskFileInfo info = Fileinfo[FilelistView.SelectedItems[0].Text];
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
            /*
            MessageBox.Show(
                "吧要下载的文件放到您百度网盘的 [/我的应用数据/wp2pcs/] 目录,即可在本程序访问"+Environment.NewLine+
                "双击文件为下载;双击目录为打开目录" +Environment.NewLine+
                "文件夹下载请使用右键下载"+Environment.NewLine+
                "如果刷新出现错误,请重新登录!"+Environment.NewLine+
                "新增加上传文件!直接把文件拖入即可,不支持文件夹!!!"
                ,"帮助"
                );
                */
            try
            {
                System.Diagnostics.Process.Start("http://www.mrs4s.top/2016/10/06/%E3%80%90c%E5%B0%8F%E5%B7%A5%E5%85%B7%E3%80%91%E7%99%BE%E5%BA%A6%E7%BD%91%E7%9B%98%E4%B8%8D%E9%99%90%E9%80%9F%E4%B8%8B%E8%BD%BD%E5%B7%A5%E5%85%B7");
            }
            catch (Exception ex)
            {
                MessageBox.Show("调用浏览器失败! " + ex.Message);
            }
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
            if (!Directory.Exists(Program.config.TempPath))
            {
                Directory.CreateDirectory(Program.config.TempPath);
            }
            if (Program.config.Access_Token == "null" || Program.config.Access_Token == string.Empty)
            {
                return;
            }
            SpaceInfo info = JsonConvert.DeserializeObject<SpaceInfo>(WebTool.GetHtml("https://pcs.baidu.com/rest/2.0/pcs/quota?method=info&access_token=" + Program.config.Access_Token));
            Used_Lab.Text = string.Format("网盘已使用: {0} / {1} (GB)", (float)info.used / 1024 / 1024 / 1024, (float)info.quota / 1024 / 1024 / 1024);
            DownloadListView.View = View.Details;
            new Thread(updateFileList).Start(HomePath + Path);
            new Thread(Upgraded).Start();
            LoadConfig();
        }
        void LoadConfig()
        {
            if (Program.config.ThreadNum > 16)
            {
                Program.config.ThreadNum = 8;
                Program.config.save();
                MessageBox.Show("下载线程设置不正确,已重置!");
            }
            if (Program.config.NetSpeed > 100)
            {
                Program.config.NetSpeed = 30;
                Program.config.save();
                MessageBox.Show("暂时不兼容这么快的网速");
            }
            ComboBox.Text = Program.config.ThreadNum.ToString();
            DownloadPath_TextBox.Text = Program.config.DownloadPath;
            NetSpeed_TextBox.Text = Program.config.NetSpeed.ToString();
            SuperDLSize_Textbox.Text = Program.config.SuperDownloadSize.ToString();
        }
        /// <summary>
        /// 检查更新
        /// </summary>
        void Upgraded()
        {
            try
            {
                JObject job = JObject.Parse(WebTool.GetHtml("http://www.mrs4s.top/api/update.json"));
                //版本6
                if ((int)job["Build"] > 6)
                {

                    DialogResult dr = MessageBox.Show((string)job["Message"] + "\r\n\r\n是否更新?", "发现更新", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start((string)job["Yes_Button"]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("调用浏览器失败! " + ex.Message);
                        }
                    }
                }
            }
            catch { }
        }

        public void AddDownloadFile(DiskFileInfo info,string DownloadPath,string FileName,bool SuperDownload)
        {
            if (DownloadTaskInfo.ContainsKey(FileName))
            {
                MessageBox.Show("警告:任务已存在");
            }
            if (SuperDownload)
            {
                TaskManager.GetTastManager.CreateSuperDownload(info, DownloadPath, FileName, Program.config.NetSpeed/10);
            }else
            {
                TaskManager.GetTastManager.CreateDownloadTask($"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={Program.config.Access_Token}&path="+ Uri.EscapeDataString($"{info.path}"), DownloadPath, FileName,Program.config.ThreadNum);
            }
        }

        int getDownloadTaskNum()
        {
            var ret = 0;
            for(int i = 0; i < DownloadListView.Items.Count; i++)
            {
                if (DownloadListView.Items[i].SubItems[4].Text == "下载中" || DownloadListView.Items[i].SubItems[4].Text=="暂停中")
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
            for (int i = 0; i < FilelistView.SelectedIndices.Count; i++)
            {
                if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[i].Text))
                {
                    MessageBox.Show("出现了未知错误! 请刷新重试");
                    return;
                }
                DiskFileInfo info = Fileinfo[FilelistView.SelectedItems[i].Text];
                if (WebTool.GetHtml(string.Format("https://pcs.baidu.com/rest/2.0/pcs/file?method=delete&access_token={0}&path={1}", Program.config.Access_Token, info.path)).Contains("ERROR"))
                {
                    MessageBox.Show("删除失败");
                    return;
                }
            }
            new Thread(updateFileList).Start(HomePath + Path);
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void 添加到下载列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FilelistView.SelectedIndices.Count; i++)
            {
                if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[i].Text))
                {
                    MessageBox.Show("出现了未知错误! 请刷新重试");
                    return;
                }
                DiskFileInfo info = Fileinfo[FilelistView.SelectedItems[i].Text];
                new AddDownload(this, info).ShowDialog();
            }
            //string url = string.Format("https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={0}&path={1}", Program.config.Access_Token, info.path);
        }

        private void 复制下载地址ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            CopyFilesAddress();
        }

        private void CopyFilesAddress()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem item in FilelistView.SelectedItems)
            {
                var info = Fileinfo[item.Text];
                if (info.isdir == 1)
                {
                    Console.WriteLine("暂时不支持复制文件夹...");
                }
                else
                {
                    sb.AppendLine($"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={Program.config.Access_Token}&path="+ Uri.EscapeDataString($"{info.path}"));
                }
            }
            try
            {

                Clipboard.SetDataObject(sb.ToString());
                Console.WriteLine(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问剪贴板失败! " + ex.Message);
            }
        }

        private void UpdateDownLoadList_Timer_Tick(object sender, EventArgs e)
        {
            DownloadListView.BeginUpdate();
            foreach(HttpTask Task in TaskManager.GetTastManager.GetTasks())
            {
                if (DownloadListView.Items.Count==Task.ID)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Task.ID.ToString();
                    item.SubItems.Add(Task.FileName);
                    item.SubItems.Add(Task.FilePath);
                    item.SubItems.Add((getSizeMB((long)Task.GetSpeed()) < 1 ? (Task.GetSpeed() / 1024) + "K/s" : getSizeMB((long)Task.GetSpeed()) + "M/s"));
                    item.SubItems.Add(Task.GetPercentage()+"%");
                    item.SubItems.Add(Task.State.ToString());
                    DownloadListView.Items.Add(item);
                    continue;
                }
                DownloadListView.Items[Task.ID].SubItems[3].Text= (getSizeMB((long)Task.GetSpeed()) < 1 ? (Task.GetSpeed() / 1024) + "K/s" : getSizeMB((long)Task.GetSpeed()) + "M/s");
                DownloadListView.Items[Task.ID].SubItems[4].Text = Task.GetPercentage() + "%";
                DownloadListView.Items[Task.ID].SubItems[5].Text = Task.State.ToString();
            }
            DownloadListView.EndUpdate();
            return;
            
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).PasteTask();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).ContinueTask();
        }

        void OpenFolderAndSelectFile(string fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }

        private void 打开目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //要改
            if (!TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).State.ToString().Contains("完成") && TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).GetType()!=1)
            {
                MessageBox.Show("任务未完成!");
                return;
            }
            var FilePath = TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).FilePath + "\\" + TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).FileName;
            if (!File.Exists(FilePath))
            {
                MessageBox.Show("文件不存在,似乎已经被删除了");
                return;
            }
            OpenFolderAndSelectFile(FilePath);
        }

        private void 终止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).StopTask();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TaskManager.GetTastManager.GetDownloadingTaskNum() > 0)
            {
                DialogResult dr = MessageBox.Show("你还有任务未完成,退出程序意味着放弃所有下载(其实是我懒没写断点续传),是否继续?", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show("即将开始清理下载产生的临时数据,请等待");
                    foreach(HttpTask Task in TaskManager.GetTastManager.GetTasks())
                    {
                        Task.StopTask();
                    }
                }else
                {
                    e.Cancel = true;
                }
            }
        }
        private void Test_Button_Click(object sender, EventArgs e)
        {
            new Video().Show();
        }

        private void FilelistView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                return;
            }
            e.Effect = DragDropEffects.None;
        }

        private void FilelistView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach(string file in files)
            {
                TaskManager.GetTastManager.CreateUploadTask(file.Split('\\')[file.Split('\\').Length-1], file, HomePath + Path).Start();
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("还没写完。。");
            CopyManager.GetCopyManager.Copy(HomePath+Path);
            new Thread(updateFileList).Start(HomePath+Path);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("还没写完。。");
            if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
            {
                MessageBox.Show("出现了未知错误! 请刷新重试");
                return;
            }
            for(int i = 0; i < FilelistView.SelectedItems.Count; i++)
            {
                var info = Fileinfo[FilelistView.SelectedItems[i].Text];
                CopyManager.GetCopyManager.AddFile(info);
            }

        }

        private void InfoMenu_Opening(object sender, CancelEventArgs e)
        {
            if (FilelistView.SelectedIndices.Count <= 0)
            {
                e.Cancel = true;
                return;
            }
        }

        private void DownLoadListMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DownloadListView.SelectedIndices.Count <= 0)
            {
                e.Cancel = true;
                return;
            }
        }

        private void 分享文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).State.ToString().Contains("完成") && TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).GetType() != 1)
            {
                MessageBox.Show("任务未完成!");
                return;
            }
            var FilePath = TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).FilePath + "\\" + TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text)).FileName;
            if (!File.Exists(FilePath))
            {
                MessageBox.Show("文件不存在,似乎已经被删除了");
                return;
            }

        }

        private void FilelistView_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+C
            if(e.Control && e.KeyValue == 67)
            {
                if (FilelistView.SelectedIndices.Count <= 0)
                {
                    return;
                }
                if (!Fileinfo.ContainsKey(FilelistView.SelectedItems[0].Text))
                {
                    MessageBox.Show("出现了未知错误! 请刷新重试");
                    return;
                }
                CopyManager.GetCopyManager.Clear();
                for (int i = 0; i < FilelistView.SelectedItems.Count; i++)
                {
                    var info = Fileinfo[FilelistView.SelectedItems[i].Text];
                    CopyManager.GetCopyManager.AddFile(info);
                }
                return;
            }
            //Ctrl+V
            if(e.Control && e.KeyValue == 86)
            {
                CopyManager.GetCopyManager.Copy(HomePath + Path);
                new Thread(updateFileList).Start(HomePath + Path);
                return;
            }
        }

        private void DownloadListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DownloadListView.SelectedItems.Count < 1)
            {
                return;
            }
            var Task=TaskManager.GetTastManager.GetTaskByID(int.Parse(DownloadListView.SelectedItems[0].Text));
            if(Task is SuperDownload)
            {
                new DownloadInfo()
                {
                    info = Task as SuperDownload
                }.Show();
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if(ComboBox.Text==string.Empty || DownloadPath_TextBox.Text==string.Empty || NetSpeed_TextBox.Text==string.Empty || SuperDLSize_Textbox.Text == string.Empty)
            {
                MessageBox.Show("保存失败: 参数错误");
                return;
            }
            if (int.Parse(NetSpeed_TextBox.Text) > 100)
            {
                MessageBox.Show("暂时不兼容这么快的网速");
                return;
            }
            Program.config.ThreadNum=int.Parse(ComboBox.Text);
            Program.config.DownloadPath = DownloadPath_TextBox.Text;
            Program.config.NetSpeed=int.Parse(NetSpeed_TextBox.Text);
            Program.config.SuperDownloadSize=int.Parse(SuperDLSize_Textbox.Text);
            Program.config.save();
            MessageBox.Show("保存完成");
        }

        private void NetSpeed_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(Char.IsNumber(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void SuperDLSize_Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择下载目录";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DownloadPath_TextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
