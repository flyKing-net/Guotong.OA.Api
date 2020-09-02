using Guotong.Api.IRepository.Base;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository
{
    public interface IVideoCenterRepository:IBaseRepository<VideoLearnCenter>
    {
        List<VideoLearnCenter> GetVideoLearnCenterList(int startPage, int endPage, int cid, int userid);
        Task<int> AddVideo(VideoLearnCenter videoLearnCenter);

        Task<int> UpdateVideo(VideoLearnCenter videoLearnCenter);

        Task<int> DeleteVideo(int id);
    }
}
