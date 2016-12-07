
using BaiduPanDownload.Data;
using BaiduPanDownload.HttpTool;
using BaiduPanDownload.Util;
using BaiduPanDownload.Util.FileTool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class AddDownload : Form
    {
        Main main;
        BaiduPanDownload.Data.DiskFileInfo info;
        bool URLMode = false;
        string Url = string.Empty;
        public AddDownload(Main main, BaiduPanDownload.Data.DiskFileInfo info,bool URLMode=false,string Url="")
        {
            InitializeComponent();
            this.main = main;
            this.info = info;
            this.URLMode = URLMode;
            this.Url = Url;
        }

        private void AddDownload_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.config.DownloadPath;
            this.TopMost = true;
            if (URLMode)
            {
                FileName_Lab.Text = "文件名: 获取中";
                FileSize_Lab.Text = "文件大小: 获取中";
                DriveSpace_Lab.Text = textBox1.Text.Substring(0, 1) + "盘剩余空间: " + ((getSizeGB(GetFreeSpace(textBox1.Text.Substring(0, 1)))) < 1 ? getSizeMB(GetFreeSpace(textBox1.Text.Substring(0, 1))) + " MB" : getSizeGB(GetFreeSpace(textBox1.Text.Substring(0, 1))) + " GB");
                button2.Enabled = false;
                button2.Text = "请等待..";
                return;
            }
            FileName_Lab.Text = "文件名: "+info.getName();
            FileSize_Lab.Text = "文件大小: " + ((info.isdir==1)?"未知":(getSizeGB(info.size)<1?getSizeMB(info.size)+" MB":getSizeGB(info.size)+" GB"));
            DriveSpace_Lab.Text = textBox1.Text.Substring(0, 1) + "盘剩余空间: " + ((getSizeGB(GetFreeSpace(textBox1.Text.Substring(0, 1))))<1?getSizeMB(GetFreeSpace(textBox1.Text.Substring(0, 1)))+" MB":getSizeGB(GetFreeSpace(textBox1.Text.Substring(0, 1)))+" GB");
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
                return 0L;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DriveSpace_Lab.Text = textBox1.Text.Substring(0, 1) + "盘剩余空间: " + ((getSizeGB(GetFreeSpace(textBox1.Text.Substring(0, 1)))) < 1 ? getSizeMB(GetFreeSpace(textBox1.Text.Substring(0, 1))) + " MB" : getSizeGB(GetFreeSpace(textBox1.Text.Substring(0, 1))) + " GB");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择下载目录";
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.button2.Text = "添加中...";
            AddDownloadButton();
        }

        void AddDownloadButton()
        {
            if (checkBox1.Checked)
            {
                Program.config.DownloadPath = textBox1.Text;
                Program.config.save();
            }
            if (!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("下载路径不存在!");
                this.button2.Enabled = true;
                this.button2.Text = "添加下载";
                return;
            }
            if (info.size <= Program.config.NetSpeed && info.isdir!=1)
            {
                MessageBox.Show("文件太小,无法下载!");
                this.button2.Enabled = true;
                this.button2.Text = "添加下载";
                return;
            }
            if (info.isdir == 1)
            {
                foreach (DiskFileInfo dfi in info.getFileList())
                {
                    string downloadPath = (textBox1.Text + dfi.path.Replace(dfi.getName(), string.Empty).Replace("/apps/wp2pcs", string.Empty).Replace("/", "\\"));
                    downloadPath = downloadPath.Substring(0, downloadPath.Length-1);
                    if (!Directory.Exists(downloadPath))
                    {
                        Directory.CreateDirectory(downloadPath);
                    }
                    main.AddDownloadFile(dfi, downloadPath, dfi.getName());
                }
                this.Close();
                return;
            }
            main.AddDownloadFile(info, textBox1.Text, info.getName());
            this.Close();
        }
    }
}
