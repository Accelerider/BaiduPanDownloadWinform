using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaiduPanDownload.HttpTool.Download
{
    public class DownloadInfo
    {
        #region 参数
        /// <summary>
        /// 总长度
        /// </summary>
        public long ContentLength { get; set; }
        /// <summary>
        /// 下载完成长度
        /// </summary>
        public long CompletedLength { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool Completed { get; set; }
        /// <summary>
        /// 下载链接
        /// </summary>
        public string DownloadUrl { get; set; }
        /// <summary>
        /// Cookies,从网页下载的时候需要储存
        /// </summary>
        public CookiesData Cookies { get; set; }
        /// <summary>
        /// 块大小
        /// </summary>
        public long BlockLength { get; set; }
        /// <summary>
        /// 下载分块
        /// </summary>
        public ArrayList DownloadBlockList { get;} = new ArrayList();
        #endregion

        /// <summary>
        /// 初始化分块信息
        /// </summary>
        public void init(string Path)
        {
            long temp = 0L;
            while (temp + BlockLength < ContentLength)
            {
                DownloadBlockList.Add(new DownloadBlock
                {
                    From = temp,
                    To = temp + BlockLength - 1,
                    Completed = false,
                });
                temp += BlockLength;
            }
            DownloadBlockList.Add(new DownloadBlock
            {
                From = temp,
                To = ContentLength,
                Completed = false,
            });
            Save(Path);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="Path"></param>
        public void Save(string Path)
        {
            File.WriteAllText(Path, JObject.Parse(JsonConvert.SerializeObject(this)).ToString());
        }
    }
    public class DownloadBlock
    {
        /// <summary>
        /// 下载开始处
        /// </summary>
        public long From { get; set; }
        /// <summary>
        /// 下载结束处
        /// </summary>
        public long To { get; set; }
        /// <summary>
        /// 已下载大小
        /// </summary>
        public long CompletedLength { get; set; } = 0L;
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool Completed { get; set; }
    }
    public class CookiesData
    {
        public string BDUSS { get; set; } = string.Empty;
        public string PCSETT { get; set; } = string.Empty;
    }
}

