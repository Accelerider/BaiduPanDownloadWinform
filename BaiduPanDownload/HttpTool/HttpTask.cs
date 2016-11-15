using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.HttpTool
{
    abstract class HttpTask
    {
        public int ID { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string State  = "等待中";

        public bool Running  = false;

        public bool Paste = false;

        public bool TaskComplete = false;

        public abstract long GetSpeed();

        public abstract void ContinueTask();

        public abstract float GetPercentage();

        public abstract string GetState();

        public abstract new int GetType();

        public abstract void Start();

        public abstract void StopTask();

        public abstract void PasteTask();

        protected void  SetComplete()
        {
            Running = false;
            TaskComplete = true;
        }
    }
}
