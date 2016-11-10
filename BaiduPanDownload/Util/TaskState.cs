using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduPanDownload.Util
{
    public enum TaskState
    {
        等待中,
        下载中,
        正在尝试秒传,
        上传中,
        加速下载中,
        合并文件中,
        暂停中,
        已停止,
        任务失败,
        下载完成,
        上传完成
    }
}
