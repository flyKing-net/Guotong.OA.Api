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
    public class VoiceUserAnswersService :BaseService<VoiceUserAnswers>, IVoiceUserAnswersService
    {
        private readonly IVoiceUserAnswersRepository _userAnswersDal;
        public VoiceUserAnswersService(IBaseRepository<VoiceUserAnswers> baseRepository,IVoiceUserAnswersRepository userAnswersRepository):base(baseRepository) {
            _userAnswersDal = userAnswersRepository;
        }

        /// <summary>
        /// 添加用户答题信息
        /// </summary>
        /// <param name="voiceUserAnswers">语音答题用户答题试题类</param>
        /// <returns></returns>
        public async Task<bool> AddUserAnswers(VoiceUserAnswers voiceUserAnswers)
        {
            return await _userAnswersDal.AddUserAnswers(voiceUserAnswers)>0;
        }
    }
}
