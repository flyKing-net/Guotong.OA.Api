using AutoMapper;
using Guotong.Api.Common.Helper;
using Guotong.Api.IRepository;
using Guotong.Api.IRepository.Base;
using Guotong.Api.IService;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
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
        private readonly IMapper iMapper;

        public VideoRecordService(IBaseRepository<VideoLearnRecord> baseRepository, IVideoRecordRepository videoRecord, IMapper IMapper) : base(baseRepository) {
            _videoRecordDal = videoRecord;
            iMapper = IMapper;
        }

        public async Task<bool> AddRecord(VideoLearnRecord videoLearnRecord,string imageIO)
        {
            if(!UploadHelper.UploadFile(videoLearnRecord.VideoImage,imageIO)) return false;
            bool addState = true;
            VideoRecordViewModel viewModels = GetRecord(videoLearnRecord.VideoId, videoLearnRecord.Cid, videoLearnRecord.UserId); //查询当前用户观看记录信息
            if (viewModels != null) //存在信息
            {
                if (viewModels.WatchState == 2) //视频已观看完毕
                {
                    addState = await _videoRecordDal.AddRecord(videoLearnRecord) > 0;
                }
                else
                { //视频未看完
                    var videoImages = string.IsNullOrWhiteSpace(viewModels.VideoImage) ? videoLearnRecord.VideoImage : $"{ viewModels.VideoImage}|{videoLearnRecord.VideoImage}";
                    addState = await UpdateRecord(new VideoLearnRecord
                    {
                        Id = viewModels.Id,
                        WatchLongTime = videoLearnRecord.WatchLongTime,
                        WatchState = videoLearnRecord.WatchState,
                        VideoImage= videoImages,
                        FinishWatchTime = DateTime.Now
                    });

                }
            }
            else
            {
                addState = await _videoRecordDal.AddRecord(videoLearnRecord) > 0;
            }
            return addState;
        }

        public VideoRecordViewModel GetRecord(int videoId, int cid, int userid)
        {

            VideoLearnRecord videoRecord = _videoRecordDal.GetRecord(videoId, cid, userid);
            VideoRecordViewModel viewModels = iMapper.Map<VideoRecordViewModel>(videoRecord);
            return viewModels;
        }

        public async Task<bool> UpdateRecord(VideoLearnRecord videoLearnRecord)
        {
            return await _videoRecordDal.UpdateRecord(videoLearnRecord) > 0;
        }
    }
}
