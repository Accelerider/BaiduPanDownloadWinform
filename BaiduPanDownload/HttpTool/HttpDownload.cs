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
    public class HttpDownload : HttpTask
    {
        public string DownLoadUrl { get; set; }
        
        public int ThreadNum { get; set; } = 1;

        public bool Stop { get; set; }

        public long From { get; set; } = 0L;
        public long To { get; set; } = 0L;

        long contentLength = 0L;
        long downloadLength = 0L;
        long speed = 0;

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
                //需要修改
                new Thread(SpeedStatistics).Start();
                for(int i=0; i<ThreadNum; i++)
                {
                    if (i ==( ThreadNum - 1))
                    {
                        threads[i] = new DownloadThread
                        {
                            Url = DownLoadUrl,
                            FileName = FilePath + "\\" + FileName + "._tmp" + i.ToString(),
                            From = From+(q * i),
                            To = To,
                            download = this
                        };
                        break;
                    }
                    
                    threads[i] = new DownloadThread
                    {
                        Url = DownLoadUrl,
                        FileName = FilePath + "\\" + FileName + "._tmp" + i.ToString(),
                        From =From+(q * i),
                        To = From + (q * (i + 1) - 1),
                        download =this
                    };
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
                if (State == TaskState.已停止)
                {
                    break;
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
                    State = TaskState.合并文件中;
                    FileOperation.CombineFiles(files, FilePath + "\\" + FileName);
                    Running = false;
                    TaskComplete = true;
                    State=TaskState.下载完成;
                    TaskCompletedEvent?.Invoke();
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
            State = TaskState.暂停中;
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

            State = TaskState.下载中;
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
            State =TaskState.已停止;
            foreach (DownloadThread thread in threads)
            {
                thread.Stop();
            }
            Thread.Sleep(2000);
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
            if (State == TaskState.下载完成)
            {
                return 0L;
            }
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
            if (State == TaskState.下载完成)
            {
                return 100F;
            }
            return ((float)downloadLength / (float)contentLength * 100f);
        }

        public void addComplete()
        {
            this.Complete++;
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

    Thread DFThread;
    public DownloadThread()
    {
        DFThread=new Thread(DownloadFile);
        DFThread.Start();
    }
    HttpWebRequest httpWebRequest;
    void DownloadFile()
    {
        try
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
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
        catch (ThreadAbortException)
        {
            return;
        }
        catch(Exception ex)
        {
            if(ex.Message.Contains("请求被取消") || ex.Message.Contains("内部"))
            {
                return;
            }
            errorNum++;
            if (errorNum > 5)
            {
                MessageBox.Show($"下载失败: {ex.Message}");
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
        DFThread.Abort();
        httpWebRequest.Abort();
    }
}
