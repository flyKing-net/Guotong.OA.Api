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
        /// 视频名称
        /// </summary>
        public string VideoTitle { get; set; }

        /// <summary>
        /// 视频描述
        /// </summary>
        public string VideoDescribe { get; set; }
    }
}
