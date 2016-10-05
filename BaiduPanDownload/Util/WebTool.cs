using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BaiduPanDownload.Util
{
    class WebTool
    {
        public static string GetHtml(string Url)
        {
            string sException = null;
            string sRslt = null;
            WebResponse oWebRps = null;
            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(Url);
            
            rq.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";
            rq.Method = "GET";
            rq.Timeout = 50000;
            try
            {
                oWebRps = rq.GetResponse();
                
            }
            catch (WebException e)
            {
                sException = e.Message.ToString();
                sRslt = "ERROR\r\n" + sException;
            }
            catch (Exception e)
            {
                sException = e.ToString();
                sRslt = "ERROR\r\n" + sException;
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
    }
}
