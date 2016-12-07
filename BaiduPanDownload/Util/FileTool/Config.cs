using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduPanDownload.Util
{
    public class Config
    {
        public string Access_Token { get; set; }
        public string DownloadPath { get; set; }
        public bool Debug { get; set; } = false;
        public bool WebDownload { get; set; } = true;
        public string TempPath { get; } = AppDomain.CurrentDomain.BaseDirectory + "Temp";
        public int TaskNum { get; set; } = 3;
        public int NetSpeed { get; set; } = 30;
        public ArrayList DownloadList { get; set; } = new ArrayList();

        public void SetDownloadInfo(string FilePath,bool Completed)
        {
            for (int i = 0; i < DownloadList.Count; i++)
            {
                DownloadItem Item = DownloadList[i] is JObject ? JsonConvert.DeserializeObject<DownloadItem>(DownloadList[i].ToString()) : DownloadList[i] as DownloadItem;
                if (Item.FilePath == FilePath)
                {
                    Item.Completed = Completed;
                    DownloadList[i] = Item;
                    save();
                    return;
                }
            }
            DownloadList.Add(new DownloadItem
            {
                FilePath=FilePath,
                Completed=Completed
            });
            save();
        }




        public void save()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json", JObject.Parse(JsonConvert.SerializeObject(this)).ToString());
        }
    }

    public class DownloadItem
    {
        public string FilePath { get; set; }
        public bool Completed { get; set; }
    }
}
