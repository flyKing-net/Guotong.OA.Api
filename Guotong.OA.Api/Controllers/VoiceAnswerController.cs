using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guotong.Api.IService;
using Guotong.Api.Model;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guotong.Api.Controllers
{
    /// <summary>
    /// 语音答题
    /// </summary>
    public class VoiceAnswerController : BaseController
    {
        private readonly IVoiceAnswerTitleService _answerTitleService;
        private readonly IVoiceSubjectInfoService _subjectInfoService;
        private readonly IVoiceUserAnswersService _userAnswersService;
        private readonly IVoiceAnswerInfoService _answerInfoService;
        public VoiceAnswerController(IVoiceAnswerTitleService answerTitleService,IVoiceSubjectInfoService subjectInfoService,IVoiceUserAnswersService userAnswersService,IVoiceAnswerInfoService answerInfoService)
        {
            _answerTitleService = answerTitleService;
            _subjectInfoService = subjectInfoService;
            _userAnswersService = userAnswersService;
            _answerInfoService = answerInfoService;
        }
      
        /// <summary>
        /// 得到语音答题列表信息
        /// </summary>
        /// <param name="cid">单位编号</param>
        /// <param name="userid">用户编号</param>
        /// <param name="startPage">开始页</param>
        /// <param name="endPage">结束页</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetVoiceAnswerList(int cid, int userid, int startPage, int endPage)
        {
            List<VoiceAnswerListViewModel> viewModels = _answerTitleService.GetAnswerList(startPage, endPage, cid, userid);
            var message = new MessageModel<List<VoiceAnswerListViewModel>>();
            if (viewModels!=null)
            {
                message = new MessageModel<List<VoiceAnswerListViewModel>>()
                {
                    status = 200,
                    success = true,
                    msg = "请求成功",
                    response = viewModels
                };
            }
            return Ok(message);
        }

        /// <summary>
        /// 添加语音答题标题信息
        /// </summary>
        /// <param name="answerTitle">答题标题</param>
        /// <param name="rulesOfAnswer">答题规则</param>
        /// <param name="publishCid">发布人单位编号</param>
        /// <param name="publisherId">发布人编号</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddVoiceAnswerTitles(string answerTitle, string rulesOfAnswer, int publishCid, int publisherId)
        {
            bool addState = await _answerTitleService.AddAnswerTitle(new VoiceAnswerTitle
            {
                AnswerTitle = answerTitle,
                RulesOfAnswer = rulesOfAnswer,
                PublishCid = publishCid,
                PublisherId = publisherId,
                PublishTime = DateTime.Now
            });
            var message = new MessageModel<bool>();
            if (addState)
            {
                message = new MessageModel<bool> { 
                status=200,
                success=true,
                msg="请求成功",
                response=addState
                };
            }
            return Ok(message);
        }


        /// <summary>
        /// 修改语音答题标题信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="answerTitle">答题标题</param>
        /// <param name="rulesOfAnswer">答题规则</param>
        /// <param name="publishCid">发布人单位编号</param>
        /// <param name="publisherId">发布人编号</param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateVoiceAnswerTitles(int id, string answerTitle, string rulesOfAnswer, int publishCid, int publisherId) {
            bool updateState = await _answerTitleService.UpdateAnswerTitle(new VoiceAnswerTitle {
                Id=id,
                AnswerTitle = answerTitle,
                RulesOfAnswer = rulesOfAnswer,
                PublishCid = publishCid,
                PublisherId = publisherId,
                PublishTime = DateTime.Now
            });
            var message = new MessageModel<bool>();
            if (updateState)
            {
                message = new MessageModel<bool>
                {
                    status = 200,
                    success = true,
                    msg = "请求成功",
                    response = updateState
                };
            }
            return Ok(message);
        }

        /// <summary>
        /// 得到语音答题题干信息
        /// </summary>
        /// <param name="answerTitleId">答题题目标题编号</param>
        /// <returns></returns>
        [HttpGet("{answerTitleId}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetVoiceSubjectInfo(int answerTitleId) {
            List<VoiceSubjectInfoViewModel> viewModels = _subjectInfoService.GetVoiceSubjectInfos(answerTitleId);
            MessageModel<List<VoiceSubjectInfoViewModel>> message = new MessageModel<List<VoiceSubjectInfoViewModel>>();
            if (viewModels!=null)
            {
                message = new MessageModel<List<VoiceSubjectInfoViewModel>> { 
                status=200,
                success=true,
                msg="请求成功",
                response=viewModels
                };
            }
            return Ok(message);
        }

        /// <summary>
        /// 添加语音答题题干信息
        /// </summary>
        /// <param name="answerTitleId">语音答题标题编号</param>
        /// <param name="subjectId">题干编号</param>
        /// <param name="subjectContent">题干内容</param>
        /// <param name="timeLimit">时长</param>
        /// <param name="subjectType">题干类型</param>
        /// <param name="subjectTimeLength">题干时长</param>
        /// <param name="minTimeLimit">最小时长</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddVocieSubject(int answerTitleId, int subjectId, string subjectContent, int timeLimit, int subjectType, int subjectTimeLength, int minTimeLimit) {
            bool addState = await _subjectInfoService.AddVoiceSubject(new VoiceSubjectInfo
            {
                AnswerTitleId = answerTitleId,
                SubjectId = subjectId,
                SubjectContent = subjectContent,
                TimeLimit = timeLimit,
                SubjectType = subjectType,
                SubjectTimeLength = subjectTimeLength,
                MinTimeLimit = minTimeLimit,
                PublishTime = DateTime.Now
            }) ;
            MessageModel<bool> message = new MessageModel<bool>();
            if (addState)
            {
                message = new MessageModel<bool> { 
                status=200,
                success=true,
                msg="请求成功",
                response=addState
                };
            }
            return Ok(message);
        }

        /// <summary>
        /// 修改语音答题题干信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="answerTitleId">语音答题标题编号</param>
        /// <param name="subjectId">题干编号</param>
        /// <param name="subjectContent">题干内容</param>
        /// <param name="timeLimit">时长</param>
        /// <param name="subjectType">题干类型</param>
        /// <param name="subjectTimeLength">题干时长</param>
        /// <param name="minTimeLimit">最小时长</param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateVoiceSubject(int id,int answerTitleId, int subjectId, string subjectContent, int timeLimit, int subjectType, int subjectTimeLength, int minTimeLimit) {
            bool updateState =await _subjectInfoService.UpdateVoiceSubject(new VoiceSubjectInfo {
                Id=id,
                AnswerTitleId = answerTitleId,
                SubjectId = subjectId,
                SubjectContent = subjectContent,
                TimeLimit = timeLimit,
                SubjectType = subjectType,
                SubjectTimeLength = subjectTimeLength,
                MinTimeLimit = minTimeLimit,
                PublishTime = DateTime.Now
            });
            MessageModel<bool> message = new MessageModel<bool>();
            if (updateState)
            {
                message = new MessageModel<bool>
                {
                    status = 200,
                    success = true,
                    msg = "请求成功",
                    response = updateState
                };
            }
            return Ok(message);
        }

        /// <summary>
        /// 添加用户答题信息
        /// </summary>
        /// <param name="answerTitleId">题目标题编号</param>
        /// <param name="cid">单位编号</param>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddUserAnswers(int answerTitleId,int cid,int userid) 
        {
            bool addState=await _userAnswersService.AddUserAnswers(new VoiceUserAnswers
            {
                AnswerTitleId = answerTitleId,
                Cid = cid,
                UserId = userid,
                SubmitTime = DateTime.Now,
                ViolationState=1
            });
            MessageModel<bool> message = new MessageModel<bool>();
            if (addState)
            {
                message = new MessageModel<bool>
                {
                    status = 200,
                    success = true,
                    msg = "请求成功",
                    response = addState
                };
            }
            return Ok(message);
        }


        /// <summary>
        /// 添加答题语音信息
        /// </summary>
        /// <param name="answerId">语音编号</param>
        /// <param name="answerContent">语音内容</param>
        /// <param name="subjectInfoId">题干编号</param>
        /// <param name="answerTime">回答时间</param>
        /// <param name="answerText">文字内容</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAnswerInfo(int answerId,string answerContent,int subjectInfoId,int answerTime,string answerText) {
            bool addState = await _answerInfoService.AddAnswerInfo(new VoiceAnswerInfo
            {
                AnswerId = answerId,
                AnswerContent = answerContent,
                SubjectInfoId = subjectInfoId,
                AnswerTime = answerTime,
                SubmitTime = DateTime.Now,
                AnswerText = answerText
            });
            MessageModel<bool> message = new MessageModel<bool>();
            if (addState)
            {
                message = new MessageModel<bool>
                {
                    status = 200,
                    success = true,
                    msg = "请求成功",
                    response = addState
                };
            }
            return Ok(message);
        }
    }
}
