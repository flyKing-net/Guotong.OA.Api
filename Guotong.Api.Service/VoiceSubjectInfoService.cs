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
    public class VoiceSubjectInfoService : BaseService<VoiceSubjectInfo>, IVoiceSubjectInfoService
    {
        private readonly IVoiceSubjectInfoRepository _voiceSubjectDal;
        private readonly IMapper iMapper;

        public VoiceSubjectInfoService(IBaseRepository<VoiceSubjectInfo> baseRepository,IVoiceSubjectInfoRepository voiceSubject,IMapper IMapper):base(baseRepository) {
            _voiceSubjectDal = voiceSubject;
            iMapper = IMapper;
        }

        /// <summary>
        /// 添加语音答题题干信息
        /// </summary>
        /// <param name="voiceSubjectInfo">题干实体类</param>
        /// <returns></returns>
        public async Task<bool> AddVoiceSubject(VoiceSubjectInfo voiceSubjectInfo)
        {
            return await _voiceSubjectDal.AddVoiceSubject(voiceSubjectInfo)>0;
        }

        /// <summary>
        /// 得到语音答题题干信息
        /// </summary>
        /// <param name="answerTitleId">答题标题编号</param>
        /// <returns></returns>
        public List<VoiceSubjectInfoViewModel> GetVoiceSubjectInfos(int answerTitleId)
        {
            List<VoiceSubjectInfo> subjectInfos = _voiceSubjectDal.GetVoiceSubjectInfos(answerTitleId);
            List<VoiceSubjectInfoViewModel> viewModels = iMapper.Map<List<VoiceSubjectInfoViewModel>>(subjectInfos);
            return viewModels;
        }


        /// <summary>
        /// 修改语音答题题干信息
        /// </summary>
        /// <param name="voiceSubjectInfo">题干实体类</param>
        /// <returns></returns>
        public async Task<bool> UpdateVoiceSubject(VoiceSubjectInfo voiceSubjectInfo)
        {
            return await _voiceSubjectDal.UpdateVoiceSubject(voiceSubjectInfo)>0;
        }
    }
}
