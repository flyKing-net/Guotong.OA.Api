using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IService
{
    public interface IVideoRecordService:IBaseService<VideoLearnRecord>
    {

        /// <summary>
        /// 得到视频观看记录信息
        /// </summary>
        /// <param name="videoId">视频编号</param>
        /// <param name="cid">单位编号</param>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        VideoRecordViewModel GetRecord(int videoId, int cid, int userid);

        /// <summary>
        /// 添加视频观看记录信息
        /// </summary>
        /// <param name="videoLearnRecord">实体类</param>
        /// <returns></returns>
        Task<bool> AddRecord(VideoLearnRecord videoLearnRecord,string imageIO);

        /// <summary>
        /// 修改视频观看记录信息
        /// </summary>
        /// <param name="videoLearnRecord">实体类</param>
        /// <returns></returns>
        Task<bool> UpdateRecord(VideoLearnRecord videoLearnRecord);


    }
}
