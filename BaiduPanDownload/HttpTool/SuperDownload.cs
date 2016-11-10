using BaiduPanDownload.Data;
using BaiduPanDownload.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BaiduPanDownload.HttpTool
{
    public class SuperDownload : HttpTask
    {
        public int SubTaskNum { get; set; } = 2;
        public DiskFileInfo Info { get; set; }

        public long ContentLength { get; set; } = 0L;
        Dictionary<int, HttpDownload> SubTasks = new Dictionary<int, HttpDownload>();

        public override void Start()
        {
            if (!(FilePath != null && FileName != null && SubTaskNum != 0))
            {
                return;
            }
            State = TaskState.加速下载中;
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create($"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={Program.config.Access_Token}&path="+ Uri.EscapeDataString($"{Info.path}")) as HttpWebRequest;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                ContentLength= httpWebResponse.ContentLength;
                long q = ContentLength / SubTaskNum;
                for (int i = 0; i < SubTaskNum; i++)
                {
                    if (i == (SubTaskNum - 1))
                    {
                        var LastSubTask = new HttpDownload
                        {
                            ID = i,
                            DownLoadUrl = $"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={Program.config.Access_Token}&path=" + Uri.EscapeDataString($"{Info.path}"),
                            FilePath=FilePath,
                            FileName= FileName + ".tmp" + i.ToString(),
                            ThreadNum =12,
                            From= q * i,
                            To=ContentLength
                        };
                        LastSubTask.Start();
                        LastSubTask.TaskCompletedEvent += TaskCompletedEvent;
                        SubTasks.Add(i,LastSubTask);
                        break;
                    }
                    var SubTask = new HttpDownload
                    {
                        ID = i,
                        DownLoadUrl = $"https://www.baidupcs.com/rest/2.0/pcs/stream?method=download&access_token={Program.config.Access_Token}&path=" + Uri.EscapeDataString($"{Info.path}"),
                        FilePath = FilePath,
                        FileName = FileName+".tmp"+i.ToString(),
                        ThreadNum = 12,
                        From=q * i,
                        To=(q*(i+1))-1
                    };
                    SubTask.Start();
                    SubTask.TaskCompletedEvent += TaskCompletedEvent;
                    SubTasks.Add(i, SubTask);
                }
            }
            catch(Exception ex)
            {
                if (ex is WebException)
                {
                    //404 ERROR
                    if (ex.Message.Contains("404"))
                    {
                        MessageBox.Show("下载失败! 文件名有非法字符,请使用云管家重命名后再下载");
                        return;
                    }
                    //403 ERROR
                    if (ex.Message.Contains("403"))
                    {
                        MessageBox.Show("下载失败! 百度抽风了,你可以换个账号或者等几天再下载\r\nPS:一般来说等一天就好");
                        return;
                    }
                }
                MessageBox.Show("下载时遇到未知错误: " + ex.Message + "\r\n请联系作者");
            }
        }

        private void TaskCompletedEvent()
        {
            bool flag = true;
            string[] FileList = new string[SubTasks.Count];
            foreach(var SubTask in SubTasks)
            {
                FileList[SubTask.Key] = SubTask.Value.FilePath + "\\" + SubTask.Value.FileName;
                if (SubTask.Value.State != TaskState.下载完成)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                State = TaskState.合并文件中;
                FileOperation.CombineFiles(FileList, FilePath + "\\" + FileName);
                State = TaskState.下载完成;
            }
        }

        /// <summary>
        /// 重试下载
        /// <param name="ID">任务ID</param>
        /// </summary>
        public void ReDownload(int ID)
        {
            if (SubTasks.ContainsKey(ID))
            {
                if (SubTasks[ID].State != TaskState.下载完成)
                {
                    HttpDownload download = new HttpDownload
                    {
                        ID=ID,
                        DownLoadUrl=SubTasks[ID].DownLoadUrl,
                        FileName=SubTasks[ID].FileName,
                        FilePath=SubTasks[ID].FilePath,
                        ThreadNum=10,
                        From=SubTasks[ID].From,
                        To=SubTasks[ID].To
                    };
                    SubTasks[ID].StopDownload();
                    download.Start();
                    download.TaskCompletedEvent += TaskCompletedEvent;
                    SubTasks[ID] = download;
                }
            }
        }

        /// <summary>
        /// 根据获取子任务
        /// </summary>
        /// <param name="ID">任务ID</param>
        /// <returns></returns>
        public HttpDownload GetTaskByID(int ID)
        {
            if (!SubTasks.ContainsKey(ID))
            {
                return null;
            }
            return SubTasks[ID];
        }

        public override void ContinueTask()
        {
            State = TaskState.加速下载中;
            foreach (var SubTask in SubTasks)
            {
                SubTask.Value.ContinueTask();
            }
        }

        public override float GetPercentage()
        {
            float Percentage = 0F;
            foreach (var SubTask in SubTasks)
            {
                Percentage += (SubTask.Value.GetPercentage() / SubTaskNum);
            }
            return Percentage;
        }

        public override long GetSpeed()
        {
            long Speed = 0L;
            foreach (var SubTask in SubTasks)
            {
                Speed += SubTask.Value.GetSpeed();
            }
            return Speed;
        }

        public override int GetType()
        {
            return 0;
        }

        public override void PasteTask()
        {
            State = TaskState.暂停中;
            foreach (var SubTask in SubTasks)
            {
                SubTask.Value.PasteDownload();
            }
        }

        public override void StopTask()
        {
            State = TaskState.已停止;
            foreach (var SubTask in SubTasks)
            {
                SubTask.Value.StopDownload();
            }
        }
    }
}
