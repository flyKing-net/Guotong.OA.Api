using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guotong.Api.IService;
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
       /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Video(int startPage,int endPage) {
            List<VideoCenterViewModel> videoModels=_videoCenterService.GetVideoLearnCenterList(startPage,endPage);
            return Ok(videoModels);
        }

        /// <summary>
        /// 添加视频信息
        /// </summary>
        /// <param name="videoTitle">视频标题</param>
        /// <param name="videoName">视频名称</param>
        /// <param name="videoDescribe">视频描述</param>
        /// <param name="videoLimit">视频限制</param>
        /// <param name="mustWatch">是否必须观看</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddVideo(string videoTitle,string videoName,string videoDescribe,int videoLimit,int mustWatch) {
            bool addState= await _videoCenterService.AddVideo(new VideoLearnCenter { 
            VideoTitle=videoTitle,
            VideoName= videoName,
            VideoDescribe=videoDescribe,
            VideoLimit=videoLimit,
            MustWatch=mustWatch,
            UploadCid=1,
            UploadUserId=1
            });
            return Ok(addState);
        }

        /// <summary>
        /// 修改视频信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="videoTitle">视频标题</param>
        /// <param name="videoName">视频名称</param>
        /// <param name="videoDescribe">视频描述</param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateVideo(int id, string videoTitle, string videoName, string videoDescribe)
        {
            bool updateState = await _videoCenterService.UpdateVideo(new VideoLearnCenter
            {
                Id = id,
                VideoTitle = videoTitle,
                VideoName = videoName,
                VideoDescribe = videoDescribe
            });
            return Ok(updateState);
        }

        /// <summary>
        /// 删除视频信息
        /// </summary>
        /// <param name="id">视频编号</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteVideo(int id) {
            bool deleteState = await _videoCenterService.DeleteVideo(id);
            return Ok(deleteState);
        }

       /// <summary>
       /// 添加观看记录信息
       /// </summary>
       /// <param name="videoId">视频编号</param>
       /// <param name="cid">单位编号</param>
       /// <param name="userId">用户编号</param>
       /// <param name="watchLongTime">观看时长</param>
       /// <param name="watchState">观看状态</param>
       /// <param name="videoImage">观看图片</param>
       /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddVideoRecord(int videoId,int cid,int userId,int watchLongTime,int watchState,string videoImage) {
            bool addState = await _videoRecordService.AddRecord(new VideoLearnRecord
            {
                VideoId = videoId,
                Cid = cid,
                UserId = userId,
                WatchLongTime = watchLongTime,
                WatchState = watchState,
                VideoImage=videoImage,
                StartWatchTime=DateTime.Now,
                FinishWatchTime=DateTime.Now
            }) ;
            return Ok(addState);
        }
    }
}
