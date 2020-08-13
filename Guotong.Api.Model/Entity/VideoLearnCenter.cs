using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Entity
{
    /// <summary>
    /// 视频学习表
    /// </summary>
    public partial class VideoLearnCenter
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
        /// 上传人单位编号
        /// </summary>
        public int UploadCid { get; set; }

        /// <summary>
        /// 上传人编号
        /// </summary>
        public int UploadUserId { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadTime { get; set; }

        /// <summary>
        /// 视频权限 0 无限制 1 公司 2 非公司
        /// </summary>
        public int VideoLimit { get; set; }

        /// <summary>
        /// 是否必须观看 0 否 1 是
        /// </summary>
        public int MustWatch { get; set; }
    }
}
