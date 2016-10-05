using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduPanDownload.Util
{
    class Config
    {
        public string Access_Token { get; set; }
        public string DownloadPath { get; set; }
        public string Message
        {
            get
            {
                return "请不要泄漏Access_Token,有了这个就可以访问您的百度网盘!";
            }
        }

        public void save()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json", JObject.Parse(JsonConvert.SerializeObject(this)).ToString());
             
        }
    }
}
