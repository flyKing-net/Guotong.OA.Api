using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IService
{
    public interface IVideoRecordService:IBaseService<VideoLearnRecord>
    {
        /// <summary>
        /// 添加视频观看记录信息
        /// </summary>
        /// <param name="videoLearnRecord">实体类</param>
        /// <returns></returns>
        Task<bool> AddRecord(VideoLearnRecord videoLearnRecord);
    }
}
