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
        public string TempPath = AppDomain.CurrentDomain.BaseDirectory + "Temp";
        public int ThreadNum  = 8;
        public int TaskNum = 3;
        public JObject DownloadList  = new JObject();

        public void save()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json", JObject.Parse(JsonConvert.SerializeObject(this)).ToString());
        }
    }
}
