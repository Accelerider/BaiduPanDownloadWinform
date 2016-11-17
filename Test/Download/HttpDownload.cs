using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test.Download
{
    class HttpDownload
    {
        /// <summary>
        /// 下载链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 下载路径
        /// </summary>
        public string DownloadPath { get; set; }
        /// <summary>
        /// 线程数
        /// </summary>
        public int ThreadNum { get; set; }

        public void Start()
        {
            try
            {
                HttpWebRequest Request = WebRequest.Create(Url) as HttpWebRequest;
                HttpWebResponse Response = Request.GetResponse() as HttpWebResponse;
                if (!File.Exists(DownloadPath + ".dcj"))
                {
                    DownloadInfo info = new DownloadInfo
                    {
                        ContentLength=Response.ContentLength,
                        BlockLength=Response.ContentLength/ThreadNum
                    };
                    info.init(DownloadPath + ".dcj");
                }
                DownloadInfo Info= JsonConvert.DeserializeObject<DownloadInfo>(File.ReadAllText(DownloadPath + ".dcj"));
                if (!File.Exists(DownloadPath))
                {
                    FileStream Stream = new FileStream(DownloadPath, FileMode.CreateNew);
                    Stream.SetLength(Response.ContentLength);
                    Stream.Close();
                }
                Console.WriteLine(Info.DownloadBlockList.Count);
                for(int i = 0; i < Info.DownloadBlockList.Count; i++)
                {
                    DownloadBlock Block= JsonConvert.DeserializeObject<DownloadBlock>(Info.DownloadBlockList[i].ToString());
                    new DownloadThread
                    {
                        ID = i,
                        DownloadUrl = Url,
                        Path = DownloadPath,
                        Block = Block,
                        Info = Info
                    };

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("出现错误: "+ex.ToString());
            }
        }
    }
}
