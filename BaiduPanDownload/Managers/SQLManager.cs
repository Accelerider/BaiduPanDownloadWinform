using BaiduPanDownload.Util.FileTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Managers
{
    class SQLManager
    {
        public static SQLManager GetSQLManager { get; } = new SQLManager();

        readonly string dbFilePath = AppDomain.CurrentDomain.BaseDirectory+"data.db";

    }
}
