using BaiduPanDownload.Data;
using BaiduPanDownload.HttpTool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Util
{
    /// <summary>
    /// 网盘API便利操作类
    /// </summary>
    class DiskAPI
    {
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="Token">账户Token</param>
        /// <returns></returns>
        public static string GetName(string Token)
        {
            var ret = WebTool.GetHtml($"https://openapi.baidu.com/rest/2.0/passport/users/getLoggedInUser?access_token={Token}");
            if (ret.Contains("ERROR"))
            {
                return ret;
            }
            JObject json = JObject.Parse(ret);
            return (string)json["uname"];
        }

        /// <summary>
        /// 获取空间信息
        /// </summary>
        /// <param name="Token">账户Token</param>
        /// <returns></returns>
        public static SpaceInfo GetSpace(string Token)
        {
            var ret = WebTool.GetHtml($"https://pcs.baidu.com/rest/2.0/pcs/quota?method=info&access_token={Token}");
            if (ret.Contains("ERROR"))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<SpaceInfo>(WebTool.GetHtml($"https://pcs.baidu.com/rest/2.0/pcs/quota?method=info&access_token={Token}"));
        }

        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

    }
}
