using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.HttpTool
{
    public class Cookies
    {
        public string CookiesStr { get; set; }

        Dictionary<string, string> CookiesKV = new Dictionary<string, string>();
        string[] CookiesList;

        public string GetCookie(string Key)
        {
            Check();
            if (!Contains(Key))
                return string.Empty;
            return CookiesKV[Key].Replace(",", string.Empty);
        }

        public string[] GetKeys()
        {
            Check();
            string[] Keys = new string[CookiesKV.Count];
            int i = 0;
            foreach (var Key in CookiesKV)
            {
                Keys[i] = Key.Key;
                i++;
            }
            return Keys;
        }

        public bool Contains(string Key)
        {
            Check();
            return CookiesKV.ContainsKey(Key);
        }

        public void init()
        {
            CookiesList = CookiesStr.Split(';');
            CookiesKV.Clear();
            foreach (var Cookie in CookiesList)
            {
                if (Cookie.Contains("="))
                {
                    CookiesKV.Add(Cookie.Split('=')[0].Replace(" ", string.Empty), Cookie.Split('=')[1]);
                }
            }
        }

        public Cookies Copy()
        {
            return new Cookies { CookiesStr = CookiesStr };
        }

        public void SetData(string K, string V)
        {
            Check();
            if (!CookiesKV.ContainsKey(K))
            {
                CookiesKV.Add(K, V);
                return;
            }
            CookiesKV[K] = V;
        }

        void Check()
        {
            if (CookiesList == null)
                init();
        }
    }
}
