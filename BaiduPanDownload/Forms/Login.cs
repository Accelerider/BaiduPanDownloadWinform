using BaiduPanDownload.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class Login : Form
    {

    private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, ShowCommands nShowCmd);

        public Login()
        {
            //InternetSetCookie("http://openapi.baidu.com/oauth/2.0/authorize?response_type=token&client_id=CuOLkaVfoz1zGsqFKDgfvI0h&redirect_uri=oob&scope=netdisk", "JSESSIONID",string.Empty);
            
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
            //ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 255", "", ShowCommands.SW_HIDE);
            webBrowser1.Dispose();
            this.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 2", "", ShowCommands.SW_HIDE);
            webBrowser1.Url = new Uri("http://www.baidu.com");
            webBrowser1.Url = new Uri("http://openapi.baidu.com/oauth/2.0/authorize?response_type=token&client_id=CuOLkaVfoz1zGsqFKDgfvI0h&redirect_uri=oob&scope=netdisk");
        }
    }
}
