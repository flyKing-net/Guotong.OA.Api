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
        Task<int> AddRecord(VideoLearnRecord videoLearnRecord);
    }
}
