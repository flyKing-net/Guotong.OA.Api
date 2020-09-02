using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IService
{
    public interface IVideoCenterService:IBaseService<VideoLearnCenter>
    {
        /// <summary>
        /// 得到视频列表信息
        /// </summary>
        /// <param name="startPage">开始页</param>
        /// <param name="endPage">结束页</param>
        /// <param name="cid">单位编号</param>
        /// <param name="userid">人员编号</param>
        /// <returns></returns>
        List<VideoCenterViewModel> GetVideoLearnCenterList(int startPage, int endPage, int cid, int userid);

        /// <summary>
        /// 添加视频信息
        /// </summary>
        /// <param name="videoLearnCenter"></param>
        /// <returns></returns>
        Task<bool> AddVideo(VideoLearnCenter videoLearnCenter);

        /// <summary>
        /// 修改视频信息
        /// </summary>
        /// <param name="videoLearnCenter"></param>
        /// <returns></returns>
        Task<bool> UpdateVideo(VideoLearnCenter videoLearnCenter);

        /// <summary>
        /// 删除视频信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteVideo(int id);
    }
}
