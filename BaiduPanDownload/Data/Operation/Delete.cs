using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Data.Operation
{
    class Delete
    {
        ArrayList list { get; } = new ArrayList();

        public void Add(string Path)
        {
            list.Add(new Path { path = Path }) ;
        }
    }
    class Path
    {
        public string path { get; set; }
    }
}
