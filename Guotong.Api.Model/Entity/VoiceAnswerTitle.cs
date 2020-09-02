using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Entity
{
    /// <summary>
    /// 语音题目标题信息表
    /// </summary>
    public class VoiceAnswerTitle
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 题目标题
        /// </summary>
        public string AnswerTitle { get; set; }

        /// <summary>
        /// 答题规则
        /// </summary>
        public string RulesOfAnswer { get; set; }

        /// <summary>
        /// 发布人单位编号
        /// </summary>
        public int PublishCid { get; set; }

        /// <summary>
        /// 发布人编号
        /// </summary>
        public int PublisherId { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 用户回答实体类
        /// </summary>
        public VoiceUserAnswers userAnswers { get; set; }
    }
}
