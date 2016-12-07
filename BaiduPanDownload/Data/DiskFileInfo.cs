using BaiduPanDownload.HttpTool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Data
{
    public class DiskFileInfo
    {

        public long fs_id { get; set; }
        public string path { get; set; }
        public long ctime { get; set; }
        public long mtime { get; set; }
        public string md5 { get; set; }
        public long size { get; set; }
        public int isdir { get; set; }


        public string getSuffix()
        {
            string[] tmp = path.Split('.');
            return tmp[tmp.Length - 1];
        }

        public string getName()
        {
            string[] tmp = path.Split('/');
            return tmp[tmp.Length - 1];
        }

        public DiskFileInfo[] getFileList()
        {
            if (isdir != 1)
            {
                return new DiskFileInfo[] { this };
            }
            ArrayList FileList = new ArrayList();
            JObject jobj = JObject.Parse(WebTool.GetHtml($"https://pcs.baidu.com/rest/2.0/pcs/file?method=list&access_token={Program.config.Access_Token}&path="+ Uri.EscapeDataString(path)));
            foreach (JObject job in jobj["list"])
            {
                DiskFileInfo fileinfo = JsonConvert.DeserializeObject<BaiduPanDownload.Data.DiskFileInfo>(job.ToString());
                if (fileinfo.isdir == 1)
                {
                    foreach(DiskFileInfo info in fileinfo.getFileList())
                    {
                        FileList.Add(info);
                    }
                    continue;
                }
                FileList.Add(fileinfo);
            }
            return (DiskFileInfo[])FileList.ToArray(typeof(DiskFileInfo));
        }
    }
}
