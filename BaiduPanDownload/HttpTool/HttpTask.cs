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
        public string State { get; set; } = "等待中";

        public abstract long GetSpeed();

        public abstract void Continue();

        public abstract float GetPercentage();

        public abstract string GetState();

        public abstract new int GetType();

        public abstract bool Runing();

        public abstract void Start();

        public abstract void StopTask();

        public abstract void PasteTask();
    }
}
