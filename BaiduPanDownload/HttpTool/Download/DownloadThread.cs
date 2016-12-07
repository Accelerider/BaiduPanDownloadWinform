using BaiduPanDownload.Util.FileTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace BaiduPanDownload.HttpTool.Download
{
    class DownloadThread
    {
        #region
        public int ID { get; set; }
        /// <summary>
        /// 下载链接
        /// </summary>
        public string DownloadUrl { get; set; }
        /// <summary>
        /// 下载路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 下载块信息
        /// </summary>
        public DownloadBlock Block { get; set; }
        /// <summary>
        /// 下载信息
        /// </summary>
        public DownloadInfo Info { get; set; }
        #endregion

        #region 事件
        public delegate void onThreadCompletedEvent();
        public event onThreadCompletedEvent ThreadCompletedEvent;
        #endregion

        public DownloadThread()
        {
            WorkThread=new Thread(Start);
            WorkThread.Start();
        }
        bool Stoped = false;
        int num=0;
        Thread WorkThread;
        HttpWebRequest Request;
        HttpWebResponse Response;
        public void Start()
        {
            try
            {
                Thread.Sleep(1000);
                if (Stoped)
                {
                    return;
                }
                if (Block.Completed)
                {
                    ThreadCompletedEvent?.Invoke();
                    return;
                }
                Request = WebRequest.Create(DownloadUrl) as HttpWebRequest;
                Request.UserAgent = "netdisk;5.3.4.5;PC;PC-Windows;5.1.2600;WindowsBaiduYunGuanJia";
                Request.Referer = "http://pan.baidu.com/disk/home";
                if (Info.Cookies != null)
                {
                    Cookie ck = new Cookie("BDUSS", Info.Cookies.BDUSS);
                    ck.Domain = ".baidu.com";
                    Request.CookieContainer = new CookieContainer();
                    Request.CookieContainer.Add(ck);
                    ck = new Cookie("pcsett", Info.Cookies.PCSETT);
                    ck.Domain = ".baidu.com";
                    Request.CookieContainer.Add(ck);
                }
                Request.Timeout = 1000;
                Request.AddRange(Block.From,Block.To);
                Response = Request.GetResponse() as HttpWebResponse;
                if (!File.Exists(Path))
                {
                    LogTool.WriteLogInfo(typeof(DownloadThread), "下载线程出现错误: 数据文件不存在");
                    return;
                }
                using (Stream ResponseStream = Response.GetResponseStream())
                {
                    using (FileStream Stream=new FileStream(Path,FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        Stream.Seek(Block.From, SeekOrigin.Begin);
                        byte[] Array = new byte[4096];
                        int i = ResponseStream.Read(Array, 0, Array.Length);
                        while (true)
                        {
                            if(i<=0 && Block.From - 1 != Block.To && Block.From!=Block.To)
                            {
                                //发送空数据,放弃这个链接重试
                                WorkThread = new Thread(Start);
                                WorkThread.Start();
                                return;
                            }
                            if (i <= 0)
                            {
                                break;
                            }
                            Stream.Write(Array, 0, i);
                            Block.From += i;
                            Block.CompletedLength += i;
                            Info.CompletedLength += i;
                            Info.DownloadBlockList[ID] = Block;
                            i = ResponseStream.Read(Array, 0, Array.Length);
                        }
                        Block.Completed = true;
                        ThreadCompletedEvent?.Invoke();
                    }
                }
            }
            catch(Exception ex)
            {
                if(ex is ThreadAbortException)
                {
                    return;
                }
                if(ex.Message.Contains("终止") || ex.Message.Contains("取消"))
                {
                    return;
                }
                if (num < 5)
                {
                    //num++;
                    //LogTool.WriteLogError(typeof(DownloadThread),"下载线程出现错误,重试中,次数: "+num,ex);
                    WorkThread = new Thread(Start);
                    WorkThread.Start();
                    return;
                }
                LogTool.WriteLogError(typeof(DownloadThread), "下载线程出现错误,重试次数超过阈值,放弃重试", ex);
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (Block.Completed)
            {
                return;
            }
            Request?.Abort();
            Response?.Close();
            WorkThread.Abort();
            Stoped = true;
        }
    }
}
