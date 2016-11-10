using BaiduPanDownload.Data;
using BaiduPanDownload.HttpTool;
using BaiduPanDownload.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace BaiduPanDownload.Managers
{
    class TaskManager
    {
        public static TaskManager GetTastManager { get; } = new TaskManager();

        Dictionary<int, HttpTask> Tasks = new Dictionary<int, HttpTask>();


        public TaskManager()
        {
            Timer TaskManagerTimer = new Timer(1000)
            {
                AutoReset = true,
                Enabled = true
            };
            TaskManagerTimer.Elapsed += TaskManagerTimer_Elapsed;
            TaskManagerTimer.Start();
        }

        private void TaskManagerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (GetDownloadingTaskNum() < Program.config.TaskNum)
            {
                foreach(var task in Tasks)
                {
                    if (task.Value.State==TaskState.等待中)
                    {
                        task.Value.Start();
                        break;
                    }
                }
            }
        }



        /// <summary>
        /// 获取正在执行的任务数量
        /// </summary>
        /// <returns></returns>
        public int GetDownloadingTaskNum()
        {
            int ret=0;
            foreach(var task in Tasks)
            {
                if (task.Value.State==TaskState.下载中 || task.Value.State==TaskState.加速下载中)
                {
                    ret++;
                }
            }
            return ret;
        }


        /// <summary>
        /// 创建下载任务
        /// </summary>
        /// <param name="DownLoadUrl">下载链接</param>
        /// <param name="DownLoadPath">下载路径</param>
        /// <param name="FileName">保存文件名</param>
        /// <param name="ThreadNum">下载线程数</param>
        /// <returns></returns>
        public HttpDownload CreateDownloadTask(string DownLoadUrl,string DownLoadPath,string FileName,int ThreadNum)
        {
            int id = Tasks.Count;
            HttpTask task = new HttpDownload
            {
                ID=id,
                DownLoadUrl=DownLoadUrl,
                FilePath=DownLoadPath,
                FileName=FileName,
                ThreadNum=ThreadNum,
            };
            Tasks.Add(id, task);
            return (HttpDownload)task;
        }

        public SuperDownload CreateSuperDownload(DiskFileInfo info,string DownloadPath,string FileName,int SubTaskNum)
        {
            int id = Tasks.Count;
            HttpTask task = new SuperDownload
            {
                ID=id,
                Info=info,
                FilePath=DownloadPath,
                FileName=FileName,
                SubTaskNum=SubTaskNum
            };
            Tasks.Add(id, task);
            return task as SuperDownload;
        }


        /// <summary>
        /// 创建上载任务
        /// </summary>
        /// <param name="FileName">保存文件名</param>
        /// <param name="FilePath">上载文件路径</param>
        /// <param name="UploadPath">保存目录</param>
        /// <returns></returns>
        public HttpUpload CreateUploadTask(string FileName,string FilePath,string UploadPath)
        {
            int id = Tasks.Count;
            HttpTask task = new HttpUpload
            {
                ID = id,
                FileName=FileName,
                FilePath=FilePath,
                UploadPath=UploadPath
            };
            Tasks.Add(id, task);
            return (HttpUpload)task;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <returns></returns>
        public HttpTask[] GetTasks()
        {
            HttpTask[] ret = new HttpTask[Tasks.Count];
            foreach(var task in Tasks)
            {
                ret[task.Key] = task.Value;
            }
            return ret;
        }

        /// <summary>
        /// 通过ID来获取任务
        /// </summary>
        /// <param name="id">任务ID</param>
        /// <returns></returns>
        public HttpTask GetTaskByID(int id)
        {
            return Tasks[id];
        }
    }
}
