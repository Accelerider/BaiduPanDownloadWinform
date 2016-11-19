using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        Thread WorkThread;
        HttpWebRequest Request;

        public void Start()
        {
            try
            {
                Thread.Sleep(1000);
                if (Block.Completed)
                {
                    ThreadCompletedEvent?.Invoke();
                    return;
                }
                Request = WebRequest.Create(DownloadUrl) as HttpWebRequest;
                Request.AddRange(Block.From,Block.To);
                HttpWebResponse Response = Request.GetResponse() as HttpWebResponse;
                if (!File.Exists(Path))
                {
                    Console.WriteLine("出现错误: 本地数据文件不存在");
                    return;
                }
                using (Stream ResponseStream = Response.GetResponseStream())
                {
                    using (FileStream Stream=new FileStream(Path,FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        Stream.Seek(Block.From, SeekOrigin.Begin);
                        byte[] Array = new byte[1024];
                        int i = ResponseStream.Read(Array, 0, Array.Length);
                        while (i > 0)
                        {
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
                Console.WriteLine("出现错误: "+ex.ToString());
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
            WorkThread.Abort();
            Request?.Abort();
        }
    }
}
