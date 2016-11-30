using BaiduPanDownload.Util.FileTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanDownload.HttpTool
{
    class WebTool
    {
        /// <summary>
        /// Get请求网站
        /// </summary>
        /// <param name="Url">地址</param>
        /// <returns>网站返回的数据</returns>
        public static string GetHtml(string Url)
        {
            string sRslt = null;
            LogTool.WriteLogDebug(typeof(WebTool),$"正在GET {Url} ");
            WebResponse oWebRps = null;
            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(Url);
            rq.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";
            rq.Method = "GET";
            rq.Timeout = 5000;
            try
            {
                oWebRps = rq.GetResponse();
            }
            catch (Exception e)
            {
                sRslt = "ERROR:" + e.Message;
                LogTool.WriteLogError(typeof(WebTool),$"GET {Url} 时发生错误!",e);
            }
            finally
            {
                if (oWebRps != null)
                {
                    StreamReader oStreamRd = new StreamReader(oWebRps.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                    sRslt = oStreamRd.ReadToEnd();
                    oStreamRd.Close();
                    oWebRps.Close();
                }
            }
            return sRslt;
        }

        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";

            request.Headers.Add("X_REG_CODE", "288a633ccc1");
            request.Headers.Add("X_MACHINE_ID", "a306b7c51254cfc5e22c7ac0702cdf87");
            request.Headers.Add("X_REG_SECRET", "de308301cf381bd4a37a184854035475d4c64946");
            request.Headers.Add("X_STORE", "0001");
            request.Headers.Add("X_BAY", "0001-01");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Accept-Language", "zh-CN");
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Accept = "*/*";

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";
            }

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            // if (cookies != null)
            // {
            request.CookieContainer = new CookieContainer();
            // request.CookieContainer.Add(cookies);
            // }
            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }

                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
            }

            return res;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="Url">下载链接</param>
        /// <param name="FileName">保存路径</param>
        /// <param name="From">Range定义的头</param>
        /// <param name="To">Range定义的尾</param>
        public static bool DownloadFile(string Url,string FileName,int From,int To)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
                httpWebRequest.Timeout = 5000;
                httpWebRequest.AddRange(From, To);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                long contentLength = httpWebResponse.ContentLength;
                using (Stream responseStream = httpWebResponse.GetResponseStream())
                {
                    using (Stream stream = new FileStream(FileName, FileMode.Create))
                    {
                        long num = 0L;
                        byte[] array = new byte[1024];
                        int i = responseStream.Read(array, 0, array.Length);
                        while (i > 0)
                        {
                            num = (long)i + num;
                            Application.DoEvents();
                            stream.Write(array, 0, i);
                            i = responseStream.Read(array, 0, array.Length);
                            Application.DoEvents();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
