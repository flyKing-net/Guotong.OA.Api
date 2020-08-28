using Guotong.Api.IRepository;
using Guotong.Api.IRepository.Base;
using Guotong.Api.IService;
using Guotong.Api.Model.Entity;
using Guotong.Api.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Service
{
    public class VideoRecordService : BaseService<VideoLearnRecord>, IVideoRecordService
    {
        private readonly IVideoRecordRepository _videoRecordDal;

        public VideoRecordService(IBaseRepository<VideoLearnRecord> baseRepository,IVideoRecordRepository videoRecord):base(baseRepository) {
            _videoRecordDal = videoRecord;
        }
        public async Task<bool> AddRecord(VideoLearnRecord videoLearnRecord)
        {
            return await _videoRecordDal.AddRecord(videoLearnRecord)>0;
        }
    }
}
