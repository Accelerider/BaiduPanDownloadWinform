using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Data
{
    class ListItem
    {
        //0:下载 1:上传
        public int Type = 0;
        public DiskFileInfo Info { get; set; }
        public float Schedule  = 0F;
        public bool Complete = false;

    }
}
