using Guotong.Api.IRepository.Base;
using Guotong.Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository
{
    public interface IVideoRecordRepository:IBaseRepository<VideoLearnRecord>
    {
        VideoLearnRecord GetRecord(int videoId,int cid,int userid);
        Task<int> AddRecord(VideoLearnRecord videoLearnRecord);
        Task<int> UpdateRecord(VideoLearnRecord videoLearnRecord);
    }
}
