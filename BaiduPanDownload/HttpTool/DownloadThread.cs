using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduPanDownload.HttpTool
{
    /// <summary>
    /// 下载线程,1.7重置版
    /// </summary>
    class DownloadThread
    {
        #region 参数
        /// <summary>
        /// 下载链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 下载路径
        /// </summary>
        public string DownloadPath { get; set; }
        /// <summary>
        /// 开始下载位置
        /// </summary>
        public long From { get; set; }
        /// <summary>
        /// 结束下载位置
        /// </summary>
        public long To { get; set; }
        /// <summary>
        /// 已下载字节数
        /// </summary>
        public long DownloadedLength { get; private set; } = 0L;
        /// <summary>
        /// 是否下载完成
        /// </summary>
        public bool Completed { get; private set; }
        /// <summary>
        /// 是否下载失败
        /// </summary>
        public bool Failed { get; protected set; }
        /// <summary>
        /// 下载速度
        /// </summary>
        public long Speed { get; private set; } = 0L;
        #endregion

        #region 事件
        public delegate void DelegateMethod(DownloadThread thread);
        /// <summary>
        /// 下载完成事件
        /// </summary>
        public event DelegateMethod DownloadCompletedEvent;
        /// <summary>
        /// 下载失败事件,被STOP的任务并不会触发
        /// </summary>
        public event DelegateMethod DownloadFailedEvent;
        #endregion


        Thread WorkThread;
        int ErrorNum = 0;
        HttpWebRequest Request;

        public DownloadThread()
        {
            WorkThread = new Thread(DownloadFile);
            WorkThread.Start();
            Task SpeedStatisticsTask = new Task(() =>
            {
                long Backup = 0L;
                while (!Completed && !Failed)
                {
                    Thread.Sleep(1000);
                    if (Backup == 0)
                    {
                        Backup = DownloadedLength;
                        continue;
                    }
                    Speed = (DownloadedLength - Backup);
                    Backup = DownloadedLength;
                }
                Speed = 0L;
            });
            SpeedStatisticsTask.Start();
        }

        void DownloadFile()
        {
            try
            {
                Thread.Sleep(500);
                Request = WebRequest.Create(Url) as HttpWebRequest;
                Request.Timeout = 5000;
                Request.AddRange(From, To);
                HttpWebResponse Response = Request.GetResponse() as HttpWebResponse;
                using (Stream ResponseStream = Response.GetResponseStream())
                {
                    using (Stream Stream = new FileStream(DownloadPath, FileMode.Create))
                    {
                        
                        byte[] Array = new byte[512];
                        int i = ResponseStream.Read(Array, 0, Array.Length);
                        while (i > 0)
                        {
                            DownloadedLength += i;
                            Stream.Write(Array, 0, i);
                            i = ResponseStream.Read(Array, 0, Array.Length);
                        }

                    }
                }
                Completed = true;
                DownloadCompletedEvent?.Invoke(this);
            }
            catch (ThreadAbortException) { return; }
            catch (Exception ex)
            {
                if (ex.Message.Contains("终止") || ex.Message.Contains("内部"))
                {
                    return;
                }
                if (ErrorNum >= 5)
                {
                    Failed = true;
                    DownloadFailedEvent?.Invoke(this);
                    return;
                }
                MessageBox.Show(ex.ToString());
                ErrorNum++;
                DownloadedLength = 0L;
                WorkThread = new Thread(DownloadFile);
                WorkThread.Start();
            }
        }
        /// <summary>
        /// 终止下载
        /// </summary>
        public void Stop()
        {
            WorkThread.Abort();
            Request?.Abort();
            Thread.Sleep(200);
            try
            {
                File.Delete(DownloadPath);
            }
            catch { }
        }
        /// <summary>
        /// 重新下载
        /// </summary>
        public void ReStart()
        {
            Stop();
            DownloadedLength = 0L;
            WorkThread = new Thread(DownloadFile);
            WorkThread.Start();
        }
        /// <summary>
        /// 便利方法,获取下载进度
        /// </summary>
        /// <returns></returns>
        public float GetPercentage()
        {
            if (Completed)
            {
                return 100F;
            }
            return ((float)DownloadedLength/(float)(To - From)) * 100;
        }
    }
}

