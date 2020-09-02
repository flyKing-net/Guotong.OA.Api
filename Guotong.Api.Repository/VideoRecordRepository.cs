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

        public VideoLearnRecord GetRecord(int videoId, int cid, int userid)
        {
            string sql = "select top 1 Id,WatchState,VideoImage from VideoLearnRecord where VideoId=@videoId and Cid=@cid and UserId=@userid order by Id desc";
            return Detail(sql,new {videoId=videoId,cid=cid,userid=userid });
        }

        public async Task<int> UpdateRecord(VideoLearnRecord videoLearnRecord)
        {
            string sql = @"update VideoLearnRecord set WatchLongTime=@WatchLongTime,WatchState=@WatchState,FinishWatchTime=@FinishWatchTime,VideoImage=@VideoImage where Id=@Id";
            return await Update(sql,videoLearnRecord);
        }
    }
}
