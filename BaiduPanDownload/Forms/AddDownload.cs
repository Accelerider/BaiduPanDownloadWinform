
using BaiduPanDownload.HttpTool;
using BaiduPanDownload.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class AddDownload : Form
    {
        Main main;
        BaiduPanDownload.Data.DiskFileInfo info;
        public AddDownload(Main main, BaiduPanDownload.Data.DiskFileInfo info)
        {
            InitializeComponent();
            this.main = main;
            this.info = info;
        }

        private void AddDownload_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.config.DownloadPath;
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
            if (info.isdir == 1)
            {
                MessageBox.Show("即将添加文件夹下载,程序可能未响应一段时间!");
            }
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
                MessageBox.Show("下载文件夹不存在!");
                return;
            }
            if (info.isdir == 1)
            {
                Directory.CreateDirectory(textBox1.Text + "\\" + info.getName());
                JObject jobj = JObject.Parse(WebTool.GetHtml(string.Format("https://pcs.baidu.com/rest/2.0/pcs/file?method=list&access_token={0}&path={1}", Program.config.Access_Token, info.path)));
                foreach (JObject job in jobj["list"])
                {
                    BaiduPanDownload.Data.DiskFileInfo fileinfo = JsonConvert.DeserializeObject<BaiduPanDownload.Data.DiskFileInfo>(job.ToString());
                    main.AddDownloadFile(fileinfo, textBox1.Text + "\\" + info.getName(), fileinfo.getName());

                }
                this.Close();
                return;
            }
            main.AddDownloadFile(info, textBox1.Text, info.getName());
            this.Close();
        }
    }
}
