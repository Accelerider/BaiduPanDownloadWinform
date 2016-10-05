
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class AddDownload : Form
    {
        Main main;
        BaiduPanDownload.Data.FileInfo info;
        public AddDownload(Main main, BaiduPanDownload.Data.FileInfo info)
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
            return new DriveInfo(driveDirectoryName).AvailableFreeSpace;
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

        }
    }
}
