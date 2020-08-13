using AutoMapper;
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
    public class VideoCenterService : BaseService<VideoLearnCenter>, IVideoCenterService
    {
        private readonly IVideoCenterRepository _videoCenterDal;
        private readonly IMapper iMapper;

        public VideoCenterService(IBaseRepository<VideoLearnCenter> baseRepository, IVideoCenterRepository videoCenter,IMapper IMapper):base(baseRepository) 
        {
            _videoCenterDal = videoCenter;
            iMapper = IMapper;
        }

        public async Task<bool> AddVideo(VideoLearnCenter videoLearnCenter)
        {
            return await _videoCenterDal.AddVideo(videoLearnCenter)>0;
        }


        public List<VideoCenterViewModel> GetVideoLearnCenterList(int startPage, int endPage)
        {
            List<VideoLearnCenter> videoList=_videoCenterDal.GetVideoLearnCenterList(startPage, endPage);
            List<VideoCenterViewModel> viewModels = iMapper.Map<List<VideoCenterViewModel>>(videoList);
            return viewModels;
        }

        public async Task<bool> UpdateVideo(VideoLearnCenter videoLearnCenter)
        {
            return await _videoCenterDal.UpdateVideo(videoLearnCenter)>0;
        }

        public async Task<bool> DeleteVideo(int id)
        {
            return await _videoCenterDal.DeleteVideo(id)>0;
        }
    }
}
