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
            string sql = "insert VideoLearnCenter values(@VideoTitle,@VideoName,@VideoDescribe,@UploadCid,@UploadUserId,@UploadTime,@VideoLimit,@MustWatch)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("VideoTitle",videoLearnCenter.VideoTitle);
            parameters.Add("VideoName", videoLearnCenter.VideoName);
            parameters.Add("VideoDescribe", videoLearnCenter.VideoDescribe);
            parameters.Add("UploadCid", videoLearnCenter.UploadCid);
            parameters.Add("UploadUserId", videoLearnCenter.UploadUserId);
            parameters.Add("UploadTime", DateTime.Now);
            parameters.Add("VideoLimit", videoLearnCenter.VideoLimit);
            parameters.Add("MustWatch",videoLearnCenter.MustWatch);
            return await Insert(sql,parameters);
        }

        /// <summary>
        /// 得到视频列表信息
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="endPage"></param>
        /// <returns></returns>
        public List<VideoLearnCenter> GetVideoLearnCenterList(int startPage, int endPage)
        {
            string sql = "select * from (select ROW_NUMBER() over(order by Id desc) rowNumbers ,* from VideoLearnCenter) a where rowNumbers>=@start_page and rowNumbers<=@end_page";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("start_page", startPage);
            parameters.Add("end_page", endPage);
            return Select(sql,parameters);
        }

        /// <summary>
        /// 修改视频信息
        /// </summary>
        /// <param name="videoLearnCenter"></param>
        /// <returns></returns>
        public async Task<int> UpdateVideo(VideoLearnCenter videoLearnCenter)
        {
            string sql = "Update VideoLearnCenter set VideoTitle=@VideoTitle,VideoName=@VideoName,VideoDescribe=@VideoDescribe where Id=@Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("VideoTitle", videoLearnCenter.VideoTitle);
            parameters.Add("VideoName", videoLearnCenter.VideoName);
            parameters.Add("VideoDescribe", videoLearnCenter.VideoDescribe);
            parameters.Add("Id", videoLearnCenter.Id);
            return await Update(sql, parameters);
        }

        /// <summary>
        /// 删除视频信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteVideo(int id)
        {
            string sql = "delete VideoLearnCenter where Id=@id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id",id);
            return await Delete(sql,parameters);
        }
    }
}
