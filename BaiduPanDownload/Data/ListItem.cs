using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Data
{
    class ListItem
    {
        //0:下载 1:上传
        public int Type { get; set; } = 0;
        public DiskFileInfo Info { get; set; }
        public float Schedule { get; set; } = 0F;
        public bool Complete { get; set; } = false;

    }
}
