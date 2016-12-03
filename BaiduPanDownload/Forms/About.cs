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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.mrs4s.top/2016/10/06/%E3%80%90c%E5%B0%8F%E5%B7%A5%E5%85%B7%E3%80%91%E7%99%BE%E5%BA%A6%E7%BD%91%E7%9B%98%E4%B8%8D%E9%99%90%E9%80%9F%E4%B8%8B%E8%BD%BD%E5%B7%A5%E5%85%B7");
            }
            catch (Exception ex)
            {
                MessageBox.Show("调用浏览器失败! " + ex.Message);
            }
        }
    }
}
