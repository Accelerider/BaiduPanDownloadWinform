using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanDownload.Util
{
    class FileOperation
    {
        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="Files">需要合并的文件数组</param>
        /// <param name="Path">输出目录</param>
        public static void CombineFiles(string[] Files,string Path)
        {
            try
            {
                int readfile;
                byte[] bytes = new byte[8192];
                using(FileStream targetFileStream = new FileStream(Path, FileMode.Create))
                {
                    foreach (string file in Files)
                    {
                        using (FileStream fileStream = new FileStream(file, FileMode.Open))
                        {
                            while (true)
                            {
                                readfile = fileStream.Read(bytes, 0, bytes.Length);
                                if (readfile <= 0)
                                {
                                    break;
                                }
                                targetFileStream.Write(bytes, 0, readfile);
                            }
                        }
                        File.Delete(file);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("合并文件失败: "+ex.Message);
            }
        }

        /// <summary>
        /// 分割文件
        /// </summary>
        /// <param name="FileName">被拆分文件</param>
        /// <param name="OutFile">拆分后文件</param>
        /// <param name="Size">单个文件长度</param>
        /// <returns>子文件列表</returns>
        public static ArrayList SplitFile(string FileName, string OutFileName, int Size)
        {
            try
            {
                using (FileStream inFile = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    ArrayList ret = new ArrayList();
                    bool mark = true;
                    int i = 0;
                    int n = 0;
                    byte[] buffer = new byte[Size];
                    while (mark)
                    {
                        string name = OutFileName + i.ToString() + ".Tmp";
                        FileStream OutFile = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        ret.Add(name);
                        if ((n = inFile.Read(buffer, 0, Size)) > 0)
                        {
                            OutFile.Write(buffer, 0, n);
                            i++;
                            OutFile.Close();
                        }
                        else
                        {
                            OutFile.Close();
                            File.Delete(name);
                            ret.Remove(name);
                            break;
                        }
                    }
                    return ret;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("分割文件失败: "+ex.Message);
            }
            return null;
        }
    }
}
