using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.ViewModel
{
    public class VideoCenterViewModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 视频标题
        /// </summary>
        public string VideoTitle { get; set; }

        /// <summary>
        /// 视频名称
        /// </summary>
        public string VideoName { get; set; }

        /// <summary>
        /// 视频描述
        /// </summary>
        public string VideoDescribe { get; set; }

        /// <summary>
        /// 视频限制
        /// </summary>
        public int VideoLimit { get; set; }

        /// <summary>
        /// 观看时长
        /// </summary>
        public int WatchLongTime { get; set; }

        /// <summary>
        /// 观看状态 0 未看 1 已看
        /// </summary>
        public int WatchState { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        

    }
}
