using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Data
{
    class ShareKey
    {

        public string MD5 { get; set; }
        public string CRC32 { get; set; }
        public long Size { get; set; }
        public string SliceMD5 { get; set; }

    }
}
