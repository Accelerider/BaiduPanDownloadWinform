using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Data
{
    class CopyInfo
    {
        public ArrayList list { get; private set; } = new ArrayList();

        public void Add(string from,string to)
        {
            list.Add(new Info
            {
                from=from,
                to=to
            });
        }
    }
    class Info
    {
        public string from { get; set; }
        public string to { get; set; }
    }
}
