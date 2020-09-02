using Guotong.Api.Model.Entity;
using Guotong.Api.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository
{
    public interface IVoiceUserAnswersRepository:IBaseRepository<VoiceUserAnswers>
    {
        Task<int> AddUserAnswers(VoiceUserAnswers voiceUserAnswers);
    }
}
