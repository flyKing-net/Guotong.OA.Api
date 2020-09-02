using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.ViewModel
{
    public class VideoRecordViewModel
    {
        /// <summary>
        /// 视频记录编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 视频编号
        /// </summary>
        public int VideoId { get; set; }

        /// <summary>
        /// 观看时长
        /// </summary>
        public int WatchLongTime { get; set; }

        /// <summary>
        /// 观看状态
        /// </summary>
        public int WatchState { get; set; }

        /// <summary>
        /// 视频截图
        /// </summary>
        public string VideoImage { get; set; }
    }
}
