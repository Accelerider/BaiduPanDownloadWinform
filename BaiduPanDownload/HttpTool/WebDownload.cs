using BaiduPanDownload.Forms;
using BaiduPanDownload.HttpTool.Download;
using BaiduPanDownload.Util.FileTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace BaiduPanDownload.HttpTool
{
    class WebDownload
    {

        public void Listen()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Listener));
        }
        void Listener(object obj)
        {
            using (HttpListener Server = new HttpListener())
            {
                Server.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                Server.Prefixes.Add("http://127.0.0.1:36728/Download/");
                try
                {
                    Server.Start();
                    while (true)
                    {
                        HttpListenerContext ctx = Server.GetContext();
                        ctx.Response.StatusCode = 200;
                        string Url = ctx.Request.QueryString["Url"];
                        //直接用QueryString会乱码
                        string Name = HttpUtility.UrlDecode(GetData(ctx.Request.RawUrl, "&Name=", "&Cookies"));
                        Name = Name.Split('/')[Name.Split('/').Length - 1];
                        string Cookies = ctx.Request.QueryString["Cookies"];
                        if (Url == null || Name == string.Empty || Cookies == null)
                        {
                            LogTool.WriteLogInfo(typeof(WebDownload), "网页监听器接收到非法数据");
                            ctx.Response.Close();
                            continue;
                        }
                        new Thread(() =>
                        {
                            new BaiduPanDownload.Forms.Download()
                            {
                                Url = Url,
                                FileName = Name,
                                Cookies = new CookiesData
                                {
                                    BDUSS = GetData(Cookies, "BDUSS=", ";pcsett="),
                                    PCSETT = GetData(Cookies, ";pcsett=", "end")
                                }
                            }.ShowDialog();
                        }).Start();
                        ctx.Response.Close();
                    }
                }catch(Exception ex)
                {
                    LogTool.WriteLogError(typeof(WebDownload),"监听网页请求时出现错误!",ex);
                    MessageBox.Show("监听网页请求时出现错误: "+ex.Message+"\r\n这个错误会导致无法监听浏览器的下载请求,但是不影响软件的正常使用,如果一直出现这个错误请在设置里面关闭监听");
                }

            }
        }
        string GetData(string str,string p1,string p2)
        {
            Regex rg = new Regex("(?<=(" + p1 + "))[.\\s\\S]*?(?=(" + p2 + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }
    }
}
