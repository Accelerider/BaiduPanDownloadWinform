using BaiduPanDownload.Data;
using BaiduPanDownload.HttpTool.Download;
using BaiduPanDownload.Managers;
using BaiduPanDownload.Util.FileTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class Download : Form
    {
        /// <summary>
        /// 下载链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Cookies
        /// </summary>
        public CookiesData Cookies { get; set; }
        /// <summary>
        /// 网盘文件信息
        /// </summary>
        public DiskFileInfo Info { get; set; }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        public Download()
        {
            InitializeComponent();
        }

        private void Download_Load(object sender, EventArgs e)
        {
            SwitchToThisWindow(this.Handle, true);
            new Thread(() => { init(); }).Start();
        }
        void init()
        {
            
            textBox2.Text = Program.config.DownloadPath;
            string DriveName = textBox2.Text.Substring(0, 1);
            DiskInfo_Lab.Text = DriveName + "盘剩余空间: " + (getSizeGB(GetFreeSpace(DriveName)) < 1 ? getSizeMB(GetFreeSpace(DriveName)) + "MB" : getSizeGB(GetFreeSpace(DriveName)) + "GB");
            //从网盘下载
            if (Info != null)
            {
                long Size = 0;
                foreach (var SubFile in Info.getFileList())
                {
                    textBox1.Text += $"https://pcs.baidu.com/rest/2.0/pcs/file?method=download&access_token={Program.config.Access_Token}&path=" + Uri.EscapeDataString(SubFile.path)+"\r\n";
                    Size += SubFile.size;
                }
                Name_Lab.Text = "文件名: " + Info.getName();
                Size_Lab.Text = "文件大小: " + (getSizeGB(Size)<1?getSizeMB(Size)+"MB":getSizeGB(Size)+"GB");
                button2.Enabled = true;
                return;
            }
            textBox1.Text += Url + "\r\n这是由网页提取的链接,可能无法正常下载";
            Name_Lab.Text = "文件名: "+FileName;
            try
            {
                HttpWebRequest Request = WebRequest.Create(Url) as HttpWebRequest;
                Request.Referer = "http://pan.baidu.com/disk/home";
                Cookie ck = new Cookie("BDUSS", Cookies.BDUSS);
                ck.Domain = ".baidu.com";
                Request.CookieContainer = new CookieContainer();
                Request.CookieContainer.Add(ck);
                ck = new Cookie("pcsett", Cookies.PCSETT);
                ck.Domain = ".baidu.com";
                Request.CookieContainer.Add(ck);
                using (HttpWebResponse Response = Request.GetResponse() as HttpWebResponse){
                    Size_Lab.Text = "文件大小: " + (getSizeGB(Response.ContentLength) < 1 ? getSizeMB(Response.ContentLength) + "MB" : getSizeGB(Response.ContentLength) + "GB");
                }
                button2.Enabled = true;
            }
            catch(Exception ex)
            {
                LogTool.WriteLogError(typeof(Download),"获取文件信息时出现错误",ex);
                MessageBox.Show("获取文件信息时出现错误!","错误");
            }
        }

        float getSizeGB(long byt)
        {
            return (float)byt / 1024 / 1024 / 1024;
        }

        float getSizeMB(long byt)
        {
            return (float)byt / 1024 / 1024;
        }

        long GetFreeSpace(string driveDirectoryName)
        {
            try
            {
                return new DriveInfo(driveDirectoryName).AvailableFreeSpace;
            }
            catch
            {
                return -1L;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //从网盘下载
            if (!Directory.Exists(textBox2.Text))
            {
                MessageBox.Show("下载路径不存在!");
                return;
            }
            if (Info != null)
            {
                foreach (var SubFile in Info.getFileList())
                {
                    TaskManager.GetTastManager.CreateDownloadTask($"https://pcs.baidu.com/rest/2.0/pcs/file?method=download&access_token={Program.config.Access_Token}&path=" + Uri.EscapeDataString(SubFile.path), textBox2.Text + "\\" + SubFile.getName());
                }
                this.Close();
                return;
            }
            MessageBox.Show("警告:百度对分享的链接有时间限制,请在短时间内下载完成,超过一天很有可能无法断点续传");
            TaskManager.GetTastManager.CreateDownloadTask(Url,textBox2.Text+"\\"+FileName,Cookies,Program.config.NetSpeed*2);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择下载目录";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
