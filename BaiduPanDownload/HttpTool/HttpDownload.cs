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

namespace BaiduPanDownload.HttpTool
{
    class HttpDownload : HttpTask
    {
        public string DownLoadUrl { get; set; }
        
        public int ThreadNum { get; set; } = 1;

        public bool Stop { get; set; }


        long contentLength = 0L;
        long downloadLength = 0L;
        long speed = 0;

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
                State = "下载中";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(DownLoadUrl);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                contentLength = httpWebResponse.ContentLength;
                threads = new DownloadThread[ThreadNum];
                long q = contentLength / ThreadNum;
                new Thread(SpeedStatistics).Start();
                for(int i=0; i<ThreadNum; i++)
                {
                    if (i ==( ThreadNum - 1))
                    {
                        threads[i] = new DownloadThread
                        {
                            Url = DownLoadUrl,
                            FileName = FilePath + "\\" + FileName + "._tmp" + i.ToString(),
                            From = q * i,
                            To = contentLength,
                            download = this
                        };
                        break;
                    }
                    
                    threads[i] = new DownloadThread
                    {
                        Url = DownLoadUrl,
                        FileName = FilePath + "\\" + FileName + "._tmp" + i.ToString(),
                        From = q * i,
                        To = (q * (i + 1)) - 1,
                        download=this
                    };
                }
            }
            catch(Exception ex)
            {
                State = "下载失败";
                SetComplete();
                MessageBox.Show($"下载失败! 错误: {ex.Message} \r\n如果以上错误为404的话 那就是文件名非法\r\n百度云的API并不允许下载有特殊字符的文件名");
            }
        }

        void SpeedStatistics()
        {
            long back=0;
            while (true)
            {
                if (back == 0)
                {
                    back = downloadLength;
                }else
                {
                    speed = downloadLength - back;
                    back = downloadLength;
                }
                if (Complete >= threads.Length)
                {
                    if (Stop)
                    {
                        break;
                    }
                    string[] files = new string[threads.Length];
                    for (int i = 0; i < threads.Length; i++)
                    {
                        files[i] = threads[i].FileName;
                    }
                    State = "拼接文件中";
                    FileOperation.CombineFiles(files, FilePath + "\\" + FileName);
                    Running = false;
                    TaskComplete = true;
                    State="下载完成";
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        public void PasteDownload()
        {
            if (DownloadComplete())
            {
                return;
            }
            State = "暂停中";
            foreach (DownloadThread thread in threads)
            {
                thread.Paste();
            }
            Running = false;
            Paste = true;
        }

        public override void ContinueTask()
        {
            if (DownloadComplete())
            {
                return;
            }

            State = "下载中";
            foreach (DownloadThread thread in threads)
            {
                thread.Continue();
            }
            Running = true;
            Paste = false;
        }

        public void StopDownload()
        {
            if (DownloadComplete())
            {
                return;
            }
            State = "已停止";
            SetComplete();
            foreach (DownloadThread thread in threads)
            {
                thread.Stop();
            }
            Thread.Sleep(1000);
            for (int i = 0; i < threads.Length; i++)
            {
                try
                {
                    File.Delete(threads[i].FileName);
                }
                catch { }
                
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
            return speed;
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
            return ((float)downloadLength / (float)contentLength * 100f);
        }

        public void addComplete()
        {
            this.Complete++;
        }

        public override string GetState()
        {
            throw new NotImplementedException();
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
class DownloadThread
{
    public string Url { get; set; }
    public string FileName { get; set; }
    public long From { get; set; }
    public long To { get; set; }
    public HttpDownload download { get; set; }

    int errorNum = 0;
    bool isPaste = false;
    bool isStop = false;

    public DownloadThread()
    {
        new Thread(DownloadFile).Start();
    }

    void DownloadFile()
    {
        try
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
            httpWebRequest.Timeout = 5000;
            httpWebRequest.AddRange(From,To);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
            long contentLength = httpWebResponse.ContentLength;
            using (Stream responseStream = httpWebResponse.GetResponseStream())
            {
                using (Stream stream = new FileStream(FileName, FileMode.Create))
                {
                    long num = 0L;
                    byte[] array = new byte[1024];
                    int i = responseStream.Read(array, 0, array.Length);
                    while (i > 0)
                    {
                        num = (long)i + num;
                        Application.DoEvents();
                        stream.Write(array, 0, i);
                        if (isStop)
                        {
                            break;
                        }
                        //史上最sb的暂停方案
                        while (isPaste)
                        {
                            if (isStop)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                        }
                        i = responseStream.Read(array, 0, array.Length);
                        download.addDownloadLength(i);
                        Application.DoEvents();
                    }
                    download.addComplete();
                }
            }
        }
        catch(Exception ex)
        {
            errorNum++;
            if (errorNum > 5)
            {
                return;
            }
            new Thread(DownloadFile).Start();
        }
    }

    public void Paste()
    {
        isPaste = true;
    }

    public void Continue()
    {
        isPaste = false;
    }

    public void Stop()
    {
        isStop = true;
    }
}
