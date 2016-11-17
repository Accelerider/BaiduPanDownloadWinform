using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Download
{
    class DownloadThread
    {
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

        public DownloadThread()
        {
            new Thread(Start).Start();
        }


        public void Start()
        {
            try
            {
                Thread.Sleep(1000);
                HttpWebRequest Request = WebRequest.Create(DownloadUrl) as HttpWebRequest;
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
                            Info.DownloadBlockList[ID] = Block;
                            i = ResponseStream.Read(Array, 0, Array.Length);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("出现错误: "+ex.ToString());
            }
        }
    }
}
