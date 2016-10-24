using System;
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


    }
}
