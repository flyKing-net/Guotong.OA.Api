using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Entity
{
    /// <summary>
    /// 视频学习记录信息表
    /// </summary>
    public partial class VideoLearnRecord
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 视频编号
        /// </summary>
        public int VideoId { get; set; }

        /// <summary>
        /// 单位编号
        /// </summary>
        public int Cid { get; set; }

        /// <summary>
        /// 人员编号
        /// </summary>
        public int UserId { get; set; }

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

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartWatchTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime FinishWatchTime { get; set; }
    }
}
