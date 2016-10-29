using BaiduPanDownload.Data;
using BaiduPanDownload.HttpTool;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Managers
{
    class CopyManager
    {
        public static CopyManager GetCopyManager { get; } = new CopyManager();

        ArrayList CopyList = new ArrayList();

        public void AddFile(DiskFileInfo info)
        {
            if (!CopyList.Contains(info))
            {
                CopyList.Add(info);
            }
        }

        public void Clear()
        {
            CopyList.Clear();
        }

        public void Copy(string Path)
        {
            var info = new CopyInfo();
            foreach(DiskFileInfo copy in CopyList)
            {
                info.Add(copy.path, Path+"/"+copy.getName());
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("param", JsonConvert.SerializeObject(info));
            WebTool.CreatePostHttpResponse($"https://pcs.baidu.com/rest/2.0/pcs/file?method=copy&access_token={Program.config.Access_Token}",parameters,null,null,Encoding.UTF8,null);
        }

    }
}
