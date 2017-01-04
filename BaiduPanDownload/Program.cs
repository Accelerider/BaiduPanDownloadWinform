using BaiduPanDownload.Forms;
using BaiduPanDownload.Util;
using BaiduPanDownload.Util.FileTool;
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
                MessageBox.Show("欢迎使用本工具,有几点需要注意的地方:\r\n1.高速下载是以硬盘的读写为代价的,一般来说100M的网速机械硬盘就会跟不上,请尽量下载到固态\r\n2.软件目前稳定性还不够,请尽量吧所有任务暂停了再关闭!");
            }
            try
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json"));
            }
            catch(Exception ex)
            {
                LogTool.WriteLogError(typeof(Program),"读取配置文件出现错误",ex);
                MessageBox.Show("配置文件读取时出现意料之外的错误! 请删除程序目录下的Config.json重试!");
                return;
            }
           // MessageBox.Show("注意:本版本为测试版,可能有意想不到的致命错误,反馈请在Github提交issues!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
