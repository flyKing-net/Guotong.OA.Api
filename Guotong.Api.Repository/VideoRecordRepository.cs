using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository
{
    public class VideoRecordRepository : BaseRepository<VideoLearnRecord>, IVideoRecordRepository
    {

        public async Task<int> AddRecord(VideoLearnRecord videoLearnRecord)
        {
            string sql =@"insert into VideoLearnRecord(VideoId,Cid,UserId,WatchLongTime,WatchState,VideoImage,StartWatchTime,FinishWatchTime) 
                          values(@VideoId,@Cid,@UserId,@WatchLongTime,@WatchState,@VideoImage,@StartWatchTime,@FinishWatchTime)";
            return await Insert(sql, videoLearnRecord);
        }
    }
}
