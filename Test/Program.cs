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
        static readonly string Url = @"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token=23.26d5ebed36b39ecb83ccc369532d5db4.2592000.1481987849.2872528644-1641135&path=%2Fapps%2Fwp2pcs%2FR0409%20%E6%B8%B8%E6%88%8F%E6%9C%AC%E4%BD%93.rar";
        static readonly string Path = @"C:\Users\18448\Desktop\Test\Test.rar";

        static void Main(string[] args)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 99999;
            Console.WriteLine("测试下载程序");
            Console.WriteLine("下载文件为: "+ Url);
            Console.WriteLine("下载目录为: "+ Path);
            var t=new HttpDownload
            {
                Url=Url,
                DownloadPath=Path,
                ThreadNum=120
            };
            t.Start();
            Thread.Sleep(9999999);
        }

    }
}
