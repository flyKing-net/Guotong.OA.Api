using Guotong.Api.IRepository;
using Guotong.Api.IRepository.Base;
using Guotong.Api.IService;
using Guotong.Api.Model.Entity;
using Guotong.Api.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Guotong.Api.Service
{
    public class VoiceAnswerInfoService : BaseService<VoiceAnswerInfo>, IVoiceAnswerInfoService
    {
        private readonly IVoiceAnswerInfoRepository _answerInfoDal;
        public VoiceAnswerInfoService(IBaseRepository<VoiceAnswerInfo> baseRepository,IVoiceAnswerInfoRepository answerInfoRepository):base(baseRepository) {
            _answerInfoDal = answerInfoRepository;
        }

        /// <summary>
        /// 添加用户答题语音
        /// </summary>
        /// <param name="voiceAnswerInfo">答题语音详细实体类</param>
        /// <returns></returns>
        public async Task<bool> AddAnswerInfo(VoiceAnswerInfo voiceAnswerInfo)
        {
            return await _answerInfoDal.AddAnswerInfo(voiceAnswerInfo)>0;
        }
    }
}
