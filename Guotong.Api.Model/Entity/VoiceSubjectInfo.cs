using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Entity
{
    /// <summary>
    /// 语音题目信息表
    /// </summary>
    public class VoiceSubjectInfo
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
        /// 题目编号
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// 题目内容
        /// </summary>
        public string SubjectContent { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        public int TimeLimit { get; set; }

        /// <summary>
        /// 题目类型
        /// </summary>
        public int SubjectType { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 题目时长
        /// </summary>
        public int SubjectTimeLength { get; set; }

        /// <summary>
        /// 最小时长
        /// </summary>
        public int MinTimeLimit { get; set; }

        /// <summary>
        /// 答题标题实体类
        /// </summary>
        public VoiceAnswerTitle answerTitle { get; set; }
    }
}
