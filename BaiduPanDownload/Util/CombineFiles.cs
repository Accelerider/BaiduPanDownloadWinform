using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanDownload.Util
{
    class CombineFiles
    {
        public string[] Files { get; set; }
        public string Path { get; set; }

        FileStream targetFileStream;

        public void Start()
        {
            try
            {
                int readfile;
                byte[] bytes = new byte[8192];
                targetFileStream = new FileStream(Path, FileMode.Create);
                foreach(string file in Files)
                {
                    FileStream fileStream = new FileStream(file, FileMode.Open);
                    while (true)
                    {
                        readfile = fileStream.Read(bytes, 0, bytes.Length);
                        if (readfile > 0)
                        {
                            targetFileStream.Write(bytes, 0, readfile);
                        }
                        else
                        {
                            break;
                        }
                    }
                    fileStream.Close();
                    File.Delete(file);
                }
                targetFileStream.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("合并文件失败: "+ex.Message);
            }
        }
    }
}
