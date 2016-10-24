using BaiduPanDownload.Data;
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
    public partial class Video : Form
    {

        public DiskFileInfo info { get; set; }
        public Video()
        {
            InitializeComponent();
        }

        private void Video_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = $"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={Program.config.Access_Token}&path={info.path}";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            Text = $"正在播放:  {info.getName()}  (双击全屏)";
        }
    }
}
