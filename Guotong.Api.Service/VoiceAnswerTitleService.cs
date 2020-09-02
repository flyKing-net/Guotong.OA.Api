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
    public class VoiceAnswerTitleService : BaseService<VoiceAnswerTitle>, IVoiceAnswerTitleService
    {
        private readonly IVoiceAnswerTitleRepository _voiceAnswerDal;
        private readonly IMapper iMapper;

        public VoiceAnswerTitleService(IBaseRepository<VoiceAnswerTitle> baseRepository,IVoiceAnswerTitleRepository voiceAnswer,IMapper IMapper):base(baseRepository) 
        {
            _voiceAnswerDal = voiceAnswer;
            iMapper = IMapper;
        }

        /// <summary>
        /// 添加语音答题标题信息
        /// </summary>
        /// <param name="voiceAnswerTitle">实体类</param>
        /// <returns></returns>
        public async Task<bool> AddAnswerTitle(VoiceAnswerTitle voiceAnswerTitle)
        {
            return await _voiceAnswerDal.AddAnswerTitle(voiceAnswerTitle)>0;
        }


        /// <summary>
        /// 得到语音答题列表信息
        /// </summary>
        /// <param name="startPage">开始页</param>
        /// <param name="endPage">结束页</param>
        /// <param name="cid">单位编号</param>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public List<VoiceAnswerListViewModel> GetAnswerList(int startPage, int endPage, int cid, int userid)
        {
            List<VoiceAnswerTitle> voiceAnswerTitles = _voiceAnswerDal.GetAnswerList(startPage,endPage,cid,userid);
            List<VoiceAnswerListViewModel> viewModels = iMapper.Map<List<VoiceAnswerListViewModel>>(voiceAnswerTitles);
            return viewModels;
        }

        /// <summary>
        /// 修改语音答题标题信息
        /// </summary>
        /// <param name="voiceAnswerTitle">实体类</param>
        /// <returns></returns>
        public async Task<bool> UpdateAnswerTitle(VoiceAnswerTitle voiceAnswerTitle)
        {
            return await _voiceAnswerDal.UpdateAnswerTitle(voiceAnswerTitle)>0;
        }
    }
}
