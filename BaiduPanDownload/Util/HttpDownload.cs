using BaiduPanDownload.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaiduPanDownload.Util
{
    class HttpDownload
    {
        public string DownLoadUrl { get; set; }
        public string DownLoadPath { get; set; }
        public string FileName { get; set; }
        public int ThreadNum { get; set; }

        public bool Paste { get; set; }
        public bool Stop { get; set; }

        long contentLength = 0L;
        long downloadLength = 0L;
        long speed = 0;

        DownloadThread[] threads;

        int Complete = 0;

        public void Start()
        {
            if(!(DownLoadUrl!=null && DownLoadPath!=null && FileName!=null && ThreadNum != 0))
            {
                return;
            }
            
            try
            {
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
                            FileName = DownLoadPath + "\\" + FileName + "._tmp" + i.ToString(),
                            From = q * i,
                            To = contentLength,
                            download = this
                        };
                        break;
                    }
                    threads[i] = new DownloadThread
                    {
                        Url = DownLoadUrl,
                        FileName = DownLoadPath + "\\" + FileName + "._tmp" + i.ToString(),
                        From = q * i,
                        To = (q * (i + 1)) - 1,
                        download=this
                    };
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("下载失败! 错误: "+ex.ToString());
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
                    new CombineFiles
                    {
                        Files = files,
                        Path = DownLoadPath + "\\" + FileName
                    }.Start();
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        public void PasteDownload()
        {
            foreach(DownloadThread thread in threads)
            {
                thread.Paste();
            }
            Paste = true;
        }

        public void ContinueDownload()
        {
            foreach (DownloadThread thread in threads)
            {
                thread.Continue();
            }
            Paste = false;
        }

        public void StopDownload()
        {
            if (DownloadComplete())
            {
                return;
            }
            Stop = true;
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

        public float getSpeed()
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

        public float getDownloadPercentage()
        {
            return ((float)downloadLength / (float)contentLength * 100f);
        }

        public void addComplete()
        {
            this.Complete++;
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
            Stream responseStream = httpWebResponse.GetResponseStream();
            Stream stream;
            stream = new FileStream(FileName, FileMode.Create);
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
            stream.Close();
            responseStream.Close();
            download.addComplete();
        }
        catch(Exception ex)
        {
            errorNum++;
            if (errorNum > 5)
            {
                MessageBox.Show("下载失败:"+ex.Message);
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
