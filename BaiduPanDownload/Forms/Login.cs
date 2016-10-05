using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("http://openapi.baidu.com/oauth/2.0/authorize?response_type=token&client_id=CuOLkaVfoz1zGsqFKDgfvI0h&redirect_uri=oob&scope=netdisk");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex rg = new Regex("(?<=(" + "access_token=" + "))[.\\s\\S]*?(?=(" + "&" + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            string token = rg.Match(webBrowser1.Url.ToString()).Value;
            if (token == string.Empty)
            {
                MessageBox.Show("你似乎还没有登录呢");
                return;
            }
            Program.config.Access_Token = token;
            Program.config.save();
            MessageBox.Show("保存完成");
            webBrowser1.Dispose();
            this.Close();
        }
    }
}
