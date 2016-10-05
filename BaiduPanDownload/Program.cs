using BaiduPanDownload.Forms;
using BaiduPanDownload.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduPanDownload
{
    static class Program
    {

        public static Config config { get; set; }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Config.json"))
            {
                new Config
                {
                    Access_Token = "null",
                    DownloadPath=@"D:\BaiduYunDownload"
                }.save();
            }
            config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
