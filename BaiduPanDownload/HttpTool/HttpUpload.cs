using BaiduPanDownload.Data;
using BaiduPanDownload.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaiduPanDownload.HttpTool
{
    class HttpUpload :HttpTask
    {
        public string UploadPath { get; set; } = "/apps/wp2pcs";

        ArrayList TaskList = new ArrayList();
        WebClient Client = new WebClient();
        long Speed = 0L;
        int UploadingTaskID=0;

        public HttpUpload()
        {
            Client.UploadFileCompleted += WebClient_UploadFileCompleted;
            Client.UploadProgressChanged += WebClient_UploadProgressChanged;
        }

        public override void Start()
        {
            if(FileName==null || FilePath == null ||!File.Exists(FilePath))
            {
                return;
            }
            Running = true;
            UploadPath += $"/{FileName}";
            State =TaskState.正在尝试秒传;
            if(RapidUpload(FilePath, FileName, UploadPath))
            {
                State = TaskState.上传完成;
                SetComplete();
                return;
            }
            State =TaskState.上传中;
            //如果小于20M
            if (new FileInfo(FilePath).Length <= (20 * 1024 * 1024))
            {
                TaskList.Add(new UploadTask
                {
                    Size= new FileInfo(FilePath).Length,
                    ID = 0,
                    From = 0,
                    To = new FileInfo(FilePath).Length,
                    FilePath=FilePath
                });
            }else
            {
                int num = 0;
                foreach (string file in FileOperation.SplitFile(FilePath, $"{Program.config.TempPath}\\{FileName}", 20 * 1024 * 1024))
                {
                    TaskList.Add(new UploadTask
                    {
                        Size = new FileInfo(FilePath).Length,
                        ID = num,
                        From = 0,
                        To = new FileInfo(FilePath).Length,
                        FilePath = file
                    });
                    num++;
                }
            }
            Upload(UploadingTaskID);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SpeedStatistics),string.Empty);
        }

        void Upload(int TaskID)
        {
            UploadTask Task = (UploadTask)TaskList[TaskID];
            if (TaskList.Count == 1)
            {
                //一次性上传
                Client.UploadFileAsync(new Uri($"https://pcs.baidu.com/rest/2.0/pcs/file?method=upload&path={UploadPath}&access_token={Program.config.Access_Token}"), FilePath);
            }else
            {
                //分片上传
                Client.UploadFileAsync(new Uri($"https://pcs.baidu.com/rest/2.0/pcs/file?method=upload&access_token={Program.config.Access_Token}&type=tmpfile"), Task.FilePath);
            }
        }

        long TaskBytesSent = 0L;
        private void WebClient_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            TaskBytesSent = e.BytesSent;
        }

        long BytesSent ;
        void SpeedStatistics(object obj)
        {
            long back = 0L;
            while (true)
            {
                if (back == 0)
                {
                    back = TaskBytesSent;
                }else
                {
                    Speed = TaskBytesSent - back;
                    if (Speed > 0)
                    {
                        BytesSent += Speed;
                    }
                    back =TaskBytesSent;
                }
                Thread.Sleep(1000);
            }
        }
        void WebClient_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            JObject jobj;
            try
            {
                jobj = JObject.Parse(Encoding.UTF8.GetString(e.Result));
            }
            catch
            {
                return;
            }
            if (TaskList.Count > 1)
            {
                ((UploadTask)TaskList[UploadingTaskID]).MD5 = (string)jobj["md5"];
                File.Delete(((UploadTask)TaskList[UploadingTaskID]).FilePath);
            }
            if (UploadingTaskID+1 >= TaskList.Count)
            {
                if (TaskList.Count > 1)
                {
                    string[] md5List = new string[TaskList.Count];
                    for(int i = 0; i < TaskList.Count; i++)
                    {
                        md5List[i] = ((UploadTask)TaskList[i]).MD5;
                    }
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("param", JsonConvert.SerializeObject(new SuperFile { block_list = md5List }));
                    WebTool.CreatePostHttpResponse($"https://pcs.baidu.com/rest/2.0/file?method=createsuperfile&path={UploadPath}&access_token={Program.config.Access_Token}", parameters, null, null, Encoding.UTF8, null);
                }
                State = TaskState.上传完成;
                SetComplete();
            }
            else
            {
                UploadingTaskID++;
                Upload(UploadingTaskID);
            }
        }

        /// <summary>
        /// 尝试秒传文件，文件大小必须大于256K
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileName">文件名称</param>
        /// <param name="UploadPath">上传路径</param>
        /// <returns>是否成功</returns>
        public static bool RapidUpload(string FilePath,string FileName,string UploadPath)
        {
            FileInfo info= new FileInfo(FilePath);
            if (info.Length < (256 * 1024))
            {
                return false;
            }
            if (!SliceFile(FilePath,FileName))
            {
                return false;
            }
            var MD5 = HashTool.HashFile(FilePath);
            var SliceMD5 = HashTool.HashFile($"{Program.config.TempPath}\\{FileName},Tmp");
            var CRC32 = HashTool.GetFileCRC32(FilePath);
            return RapidUpload(MD5,SliceMD5,CRC32,info.Length,UploadPath);
        }

        /// <summary>
        /// 尝试秒传文件
        /// </summary>
        /// <param name="MD5">文件MD5</param>
        /// <param name="SliceMD5">文件前256K的MD5</param>
        /// <param name="CRC32">文件CRC32</param>
        /// <param name="Length">文件长度</param>
        /// <param name="UploadPath">上传路径</param>
        /// <returns>是否成功</returns>
        public static bool RapidUpload(string MD5,string SliceMD5,string CRC32,long Length,string UploadPath)
        {
            if (WebTool.GetHtml($"https://pcs.baidu.com/rest/2.0/pcs/file?method=rapidupload&access_token={Program.config.Access_Token}&content-length={Length}&content-md5={MD5}&slice-md5={SliceMD5}&path={UploadPath}").Contains("ERROR"))
            {
                return false;
            }
            return true;
        }



        static bool SliceFile(string FilePath,string FileName)
        {
            try
            {
                byte[] bytes = new byte[256*1024];
                using (FileStream targetFileStream = new FileStream($"{Program.config.TempPath}\\{FileName},Tmp", FileMode.Create))
                {
                    using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.Read(bytes, 0, bytes.Length);
                        targetFileStream.Write(bytes, 0, 256 * 1024);
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("试图对文件分割时出现错误: "+ex.ToString());
            }
            return false;
        }

        public override long GetSpeed()
        {
            return Speed;
        }

        public override int GetType()
        {
            return 1;
        }

        public override void StopTask()
        {
            UploadingTaskID = TaskList.Count - 1;
            Client.CancelAsync();
            Client.Dispose();
            foreach (UploadTask task in TaskList)
            {
                if (File.Exists(task.FilePath))
                {
                    try
                    {
                        File.Delete(task.FilePath);
                    }
                    catch { }
                    
                }
            }
            SetComplete();
            State =TaskState.已停止;
        }

        public override void PasteTask()
        {
            MessageBox.Show("由于作者过于zz，上传任务并不能暂停。。");
        }

        public override float GetPercentage()
        {
            return ((float)BytesSent / (float)new FileInfo(FilePath).Length * 100f);
        }

        public override void ContinueTask()
        {
            MessageBox.Show("由于作者过于zz，上传任务并不能暂停。。");
        }
    }
    class UploadTask
    {
        public int ID { get; set; }
        public long Size { get; set; }
        public long From { get; set; }
        public long To { get; set; }
        public string MD5 { get; set; }
        public string FilePath { get; set; }
        string TempFile { get; set; } = string.Empty;
    }
}
