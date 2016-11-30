using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Util.FileTool
{
    class LogTool
    {
        /// <summary>
        /// 写INFO日志
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteLogInfo(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Info(msg);
        }
        /// <summary>
        /// 写ERROR日志
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void WriteLogError(Type t, string msg, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg, ex);
        }
        /// <summary>
        /// 写DEBUG日志
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteLogDebug(Type t, string msg)
        {
            if (Program.config.Debug)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(t);
                log.Debug(msg);
            }
        }
    }
}
