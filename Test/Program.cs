using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Download;

namespace Test
{
    class Program
    {
        static readonly string Url = @"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token=xx&path=%2Fapps%2Fwp2pcs%2F%E5%8A%A8%E7%94%BB%2F%5B%E3%82%A2%E3%83%8B%E3%83%A1%20BD%5D%20%E5%A4%A9%E4%BD%93%E3%81%AE%E3%83%A1%E3%82%BD%E3%83%83%E3%83%89%20%E7%AC%AC01%E8%A9%B1%E3%80%8C%E5%86%86%E7%9B%A4%E3%81%AE%E8%A1%97%E3%80%8D(1920%C3%971080%20HEVC%2010bit%20FLAC%20FLAC%20softSub(chi%20eng)%20chap).mkv";
        static readonly string Path = @"C:\Users\18448\Desktop\Test\Test.mkv";

        static void Main(string[] args)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 99999;
            Console.WriteLine("测试下载程序");
            Console.WriteLine("下载文件为: "+ Url);
            Console.WriteLine("下载目录为: "+ Path);
            new HttpDownload
            {
                Url=Url,
                DownloadPath=Path,
                ThreadNum=120
            }.Start();
        }

    }
}
