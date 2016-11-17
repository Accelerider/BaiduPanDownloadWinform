using BaiduPanDownload.HttpTool;
using BaiduPanDownload.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

//吃枣药丸
//再不重写就完了
namespace BaiduPanDownload.HttpTool
{
    public class HttpDownload : HttpTask
    {
        public string DownLoadUrl { get; set; }
        
        public int ThreadNum { get; set; } = 1;

        public bool Stop { get; set; }

        public long From { get; set; } = 0L;
        public long To { get; set; } = 0L;

        long contentLength = 0L;
        long downloadLength = 0L;

        public delegate void onTaskCompleted();
        public event onTaskCompleted TaskCompletedEvent;

        DownloadThread[] threads;

        int Complete = 0;

        public override void Start()
        {
            if(!(DownLoadUrl!=null && FilePath!=null && FileName!=null && ThreadNum != 0))
            {
                return;
            }
            Running = true;
            try
            {
                State = TaskState.下载中;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(DownLoadUrl);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                contentLength = httpWebResponse.ContentLength;
                threads = new DownloadThread[ThreadNum];
                if (From == To)
                {
                    From = 0;
                    To = contentLength;
                }else
                {
                    contentLength = To - From;
                }
                long q = contentLength / ThreadNum;
                for(int i=0; i<ThreadNum; i++)
                {
                    if (i ==( ThreadNum - 1))
                    {
                        threads[i] = new DownloadThread
                        {
                            Url = DownLoadUrl,
                            DownloadPath = FilePath + "\\" + FileName + "._tmp" + i.ToString(),
                            From = From+(q * i),
                            To = To
                        };
                        threads[i].DownloadCompletedEvent += HttpDownload_DownloadCompletedEvent;
                        break;
                    }
                    threads[i] = new DownloadThread
                    {
                        Url = DownLoadUrl,
                        DownloadPath = FilePath + "\\" + FileName + "._tmp" + i.ToString(),
                        From =From+(q * i),
                        To = From + (q * (i + 1) - 1),
                    };
                    threads[i].DownloadCompletedEvent+= HttpDownload_DownloadCompletedEvent;
                }
            }
            catch(Exception ex)
            {
                State = TaskState.任务失败;
                SetComplete();
                if(ex is WebException)
                {
                    //404 ERROR
                    if (ex.Message.Contains("404"))
                    {
                        MessageBox.Show("下载失败! 文件名有非法字符,请使用云管家重命名后再下载");
                        return;
                    }
                    //403 ERROR
                    if (ex.Message.Contains("403"))
                    {
                        MessageBox.Show("下载失败! 百度抽风了,你可以换个账号或者等几天再下载\r\nPS:一般来说等一天就好");
                        return;
                    }
                }
                MessageBox.Show($"下载失败! 错误: {ex.Message}");
            }
        }

        private void HttpDownload_DownloadCompletedEvent(DownloadThread thread)
        {
            lock (this)
            {
                bool flag = false;
                foreach (DownloadThread thr in threads)
                {
                    if (thr.Equals(thread))
                    {
                        continue;
                    }
                    if (!thr.Completed)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    return;
                }
                if (Stop)
                {
                    return;
                }
                string[] files = new string[threads.Length];
                for (int i = 0; i < threads.Length; i++)
                {
                    files[i] = threads[i].DownloadPath;
                }
                State = TaskState.合并文件中;
                FileOperation.CombineFiles(files, FilePath + "\\" + FileName);
                Running = false;
                TaskComplete = true;
                State = TaskState.下载完成;
                TaskCompletedEvent?.Invoke();
            }
        }


        public void PasteDownload()
        {
            MessageBox.Show("暂时无法暂停,请等待正式版的断点续传!");
        }

        public override void ContinueTask()
        {
            return;
        }

        public void StopDownload()
        {
            if (DownloadComplete())
            {
                return;
            }
            State =TaskState.已停止;
            foreach (DownloadThread thread in threads)
            {
                thread.Stop();
            }
            
        }

        public bool DownloadComplete()
        {
            if (threads == null)
            {
                return false;
            }
            return Complete >= threads.Length;
        }

        public override long GetSpeed()
        {
            try
            {
                if (State == TaskState.下载完成 || threads == null)
                {
                    return 0L;
                }
                long speed = 0L;
                foreach (DownloadThread task in threads)
                {
                    speed += task.Speed;
                }
                return speed;
            }
            catch
            {
                return 0L;
            }

        }

        public void addDownloadLength(long length)
        {
            lock (this)
            {
                downloadLength += length;
            }
        }

        public override float GetPercentage()
        {
            try
            {
                if (State == TaskState.下载完成)
                {
                    return 100F;
                }
                if (threads == null)
                {
                    return 0F;
                }
                float Percentage = 0F;
                foreach (DownloadThread task in threads)
                {
                    Percentage += task.GetPercentage() / ThreadNum;
                }
                return Percentage;
            }
            catch
            {
                return 0F;
            }

        }



        public override int GetType()
        {
            return 0;
        }

        public override void StopTask()
        {
            StopDownload();
           
        }

        public override void PasteTask()
        {
            PasteDownload();
        }

    }


}
