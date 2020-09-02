using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Entity
{
    /// <summary>
    /// 答题详情
    /// </summary>
    public class VoiceAnswerInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 答题详情编号
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// 答题语音内容
        /// </summary>
        public string AnswerContent { get; set; }

        /// <summary>
        /// 回答时长
        /// </summary>
        public int AnswerTime { get; set; }

        /// <summary>
        /// 题目编号
        /// </summary>
        public int SubjectInfoId { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubmitTime { get; set; }

        /// <summary>
        /// 答题文本
        /// </summary>
        public string AnswerText { get; set; }
    }
}
