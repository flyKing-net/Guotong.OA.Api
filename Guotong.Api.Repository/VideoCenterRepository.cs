using Dapper;
using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository
{
    public class VideoCenterRepository : BaseRepository<VideoLearnCenter>, IVideoCenterRepository
    {
        /// <summary>
        /// 添加视频信息
        /// </summary>
        /// <param name="videoLearnCenter"></param>
        /// <returns></returns>
        public async Task<int> AddVideo(VideoLearnCenter videoLearnCenter)
        {
            string sql = @"insert into VideoLearnCenter(VideoTitle,VideoName,VideoDescribe,UploadCid,UploadUserId,UploadTime,VideoLimit,MustWatch) 
                         values(@VideoTitle,@VideoName,@VideoDescribe,@UploadCid,@UploadUserId,@UploadTime,@VideoLimit,@MustWatch)";
            return await Insert(sql,videoLearnCenter);
        }

        /// <summary>
        /// 得到视频列表信息
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="endPage"></param>
        /// <param name="cid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<VideoLearnCenter> GetVideoLearnCenterList(int startPage, int endPage,int cid,int userid)
        {
            string sql = @"select Id,VideoTitle,VideoName,VideoDescribe,VideoLimit,WatchLongTime,WatchState,FinishWatchTime from (
                           select center.Id,row_number() over (order by center.Id desc) as RowNumber,cast(center.Id as nvarchar)+'-'+VideoTitle as VideoTitle,
                           'http://oa.yiliacc.com/newaspnet/VideoLearningCenter/Videos/'+VideoName VideoName,VideoDescribe,isnull(WatchLongTime,0) WatchLongTime,
                           isnull(WatchState,0) WatchState,VideoLimit,case when isnull(FinishWatchTime,0)=0 then UploadTime else FinishWatchTime end FinishWatchTime from VideoLearnCenter center 
                           left join (select a.VideoId,a.WatchState,b.WatchLongTime,b.FinishWatchTime from(
                           (select VideoId,WatchLongTime,WatchState from VideoLearnRecord where Id in (select MIN(Id) Id from VideoLearnRecord where Cid=@cid and UserId=@userid group by VideoId)  ) a 
                           left join (select VideoId,WatchLongTime,WatchState,FinishWatchTime from VideoLearnRecord where Id in (select max(Id) Id from VideoLearnRecord where Cid=@cid and UserId=@userid group by VideoId)) b 
                           on a.VideoId = b.VideoId)
                           ) record on center.Id=record.VideoId ) a where RowNumber>=@startPage and RowNumber<=@endPage order by Id desc";
            return Select<VideoLearnCenter,VideoLearnRecord>(sql,new {startPage=startPage,endPage=endPage,cid=cid,userid=userid },
                                                             (VideoLearnCenter,VideoLearnRecord)=> {
                                                                 VideoLearnCenter.VideoLearnRecord = VideoLearnRecord;
                                                                 return VideoLearnCenter;
                                                             }, "WatchLongTime");
        }

        /// <summary>
        /// 修改视频信息
        /// </summary>
        /// <param name="videoLearnCenter"></param>
        /// <returns></returns>
        public async Task<int> UpdateVideo(VideoLearnCenter videoLearnCenter)
        {
            string sql = "Update VideoLearnCenter set VideoTitle=@VideoTitle,VideoName=@VideoName,VideoDescribe=@VideoDescribe where Id=@Id";
            return await Update(sql, videoLearnCenter);
        }

        /// <summary>
        /// 删除视频信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteVideo(int id)
        {
            string sql = "delete VideoLearnCenter where Id=@id";
            return await Delete(sql,new { id=id});
        }
    }
}
