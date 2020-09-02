using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.ViewModel
{
    public class VoiceAnswerListViewModel
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
        /// 回答规则
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
        /// 回答状态
        /// </summary>
        public int AnswerState { get; set; }

        /// <summary>
        /// 违规状态
        /// </summary>
        public int ViolationState { get; set; }

        /// <summary>
        /// 回答次数
        /// </summary>
        public int AnswerCount { get; set; }
    }
}
