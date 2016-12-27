using BaiduPanDownload.HttpTool;
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

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int InternetSetCookieEx(string lpszURL, string lpszCookieName, string lpszCookieData, int dwFlags, IntPtr dwReserved);
        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, ShowCommands nShowCmd);

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("http://www.139.sh");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cookies cookies = new Cookies
            {
                CookiesStr = GetCookies("http://www.139.sh")
            };
            if (!cookies.Contains("Cookie_token"))
            {
                MessageBox.Show("你似乎还没有登录呢");
                return;
            }
            Program.config.Access_Token = cookies.GetCookie("Cookie_token");
            Program.config.save();
            MessageBox.Show("保存完成");
            //ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 255", "", ShowCommands.SW_HIDE);
            webBrowser1.Dispose();
            this.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        string GetCookies(string url)
        {
            uint datasize = 256;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x2000, IntPtr.Zero))
            {
                if (datasize < 0)
                {
                    return null;
                }
                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                {
                    return null;
                }
            }
            return cookieData.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 2", "", ShowCommands.SW_HIDE);
            this.Close();
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            webBrowser1.Navigate(webBrowser1.StatusText);
        }
    }
}
