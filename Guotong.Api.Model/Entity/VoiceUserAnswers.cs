using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Entity
{
    /// <summary>
    /// 用户答题信息表
    /// </summary>
    public class VoiceUserAnswers
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 题目标题编号
        /// </summary>
        public int AnswerTitleId { get; set; }

        /// <summary>
        /// 单位编号
        /// </summary>
        public int Cid { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubmitTime { get; set; }

        /// <summary>
        /// 违规状态 
        /// </summary>
        public int ViolationState { get; set; }

        /// <summary>
        /// 答题状态
        /// </summary>
        public int AnswerState { get; set; }

        /// <summary>
        /// 答题次数
        /// </summary>
        public int AnswerCount { get; set; }
    }
}
