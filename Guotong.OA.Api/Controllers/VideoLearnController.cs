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
using Microsoft.Extensions.Logging;

namespace Guotong.Api.Controllers
{
    /// <summary>
    /// 视频学习
    /// </summary>
    public class VideoLearnController : BaseController
    {
        private readonly IVideoCenterService _videoCenterService;
        private readonly IVideoRecordService _videoRecordService;
        public VideoLearnController(IVideoCenterService videoCenterService,IVideoRecordService videoRecordService) {
            _videoCenterService = videoCenterService;
            _videoRecordService = videoRecordService;
        }

        /// <summary>
        /// 得到视频列表信息
        /// </summary>
        /// <param name="startPage">开始页</param>
        /// <param name="endPage">结束页</param>
        /// <param name="cid">单位编号</param>
        /// <param name="userid">人员编号</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult VideoLearnList(int cid, int userid, int startPage, int endPage)
        {
            List<VideoCenterViewModel> videoModels = _videoCenterService.GetVideoLearnCenterList(startPage, endPage, cid, userid);
            var message = new MessageModel<List<VideoCenterViewModel>>();
            if (videoModels!=null)
            {
                 message = new MessageModel<List<VideoCenterViewModel>>
                {
                    status = 200,
                    success = true,
                    msg = "请求成功",
                    response = videoModels
                };
            }
            return Ok(message);
        }

        /// <summary>
        /// 添加观看记录信息
        /// </summary>
        /// <param name="videoId">视频编号</param>
        /// <param name="cid">单位编号</param>
        /// <param name="userId">用户编号</param>
        /// <param name="watchLongTime">观看时长</param>
        /// <param name="watchState">观看状态  0 未观看 1 未看完 2 已看完</param>
        /// <param name="videoImage">观看图片</param>
        /// <param name="imageIO">图片IO流</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddVideoRecord(int videoId,int cid,int userId,int watchLongTime,int watchState,string videoImage,string imageIO) {
            bool addState = await _videoRecordService.AddRecord(new VideoLearnRecord { 
            VideoId=videoId,
            Cid=cid,
            UserId=userId,
            WatchLongTime=watchLongTime,
            WatchState=watchState,
            VideoImage=videoImage,
            StartWatchTime=DateTime.Now,
            FinishWatchTime=DateTime.Now
            },imageIO);
            var message = new MessageModel<bool>();
            if (addState)
            {
                message = new MessageModel<bool>
                {
                    status = 200,
                    success = true,
                    msg = "请求成功",
                    response=addState
                };
            }
            return Ok(message);
        }
    }
}
