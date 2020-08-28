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
        /// <returns></returns>
        public List<VideoLearnCenter> GetVideoLearnCenterList(int startPage, int endPage)
        {
            string sql = @"select rowNumbers ,Id,VideoTitle,VideoName,VideoDescribe,UploadCid,UploadUserId,UploadTime,VideoLimit,MustWatch from (
                           select ROW_NUMBER() over(order by Id desc) rowNumbers ,Id,VideoTitle,VideoName,VideoDescribe,UploadCid,UploadUserId,UploadTime,VideoLimit,MustWatch from VideoLearnCenter
                           ) a where rowNumbers>=@startPage and rowNumbers<=@endPage";
            return Select(sql, new {startPage=startPage,endPage=endPage });
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
