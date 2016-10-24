using BaiduPanDownload.HttpTool;
using BaiduPanDownload.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanDownload.Forms
{
    public partial class NewDir : Form
    {
        string path;

        public NewDir(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            if (Name_Textbox.Text == string.Empty)
            {
                MessageBox.Show("请输入名字!");
                return;
            }
            if(ContainsStringList(Name_Textbox.Text,new string[] { "\\","?","|","\"",">","<", ":", "*" , ".","\r","\n","\r\n"," ","\0","\x08" }))
            {
                MessageBox.Show("文件夹名字存在非法字符!");
                return;
            }
            if (WebTool.GetHtml(string.Format("https://pcs.baidu.com/rest/2.0/pcs/file?method=mkdir&access_token={0}&path={1}", Program.config.Access_Token, path+"/"+Name_Textbox.Text)).Contains("ERROR"))
            {
                MessageBox.Show("创建失败,可能是目录已存在!");
            }
            this.Close();
        }

        bool ContainsStringList(string str,string[] strs)
        {
            foreach(string s in strs)
            {
                if (str.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
