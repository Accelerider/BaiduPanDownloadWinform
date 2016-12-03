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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.config.DownloadPath;
            checkBox1.Checked = Program.config.WebDownload;
            textBox2.Text = Program.config.NetSpeed.ToString();
            comboBox1.Text = Program.config.TaskNum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择下载目录";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("这里填写需要单任务下载速度上限(不能突破物理带宽)\r\n单位为Mbps,一般10Mbps≈1.2MB/s","帮助");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(MessageBox.Show("监听分享页的下载请求,可从分享页调用本工具实现不限速下载,\r\n需要配合浏览器插件,点击确定跳转到下载链接","帮助", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                try
                {
                    System.Diagnostics.Process.Start("https://github.com/Mrs4s/BaiduExporter/releases");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("调用浏览器失败! " + ex.Message);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("参数不合法!","警告");
                return;
            }
            var NetSpeed = int.Parse(textBox2.Text);
            if (NetSpeed > 120)
            {
                MessageBox.Show("暂不兼容这么快的速度!","警告");
                return;
            }
            Program.config.DownloadPath = textBox1.Text;
            Program.config.NetSpeed = NetSpeed;
            if (Program.config.WebDownload != checkBox1.Checked)
            {
                MessageBox.Show("部分设置需要重启程序后才能生效!");
            }
            Program.config.WebDownload = checkBox1.Checked;
            Program.config.TaskNum = int.Parse(comboBox1.Text);
            Program.config.save();
            this.Close();
        }
    }
}
