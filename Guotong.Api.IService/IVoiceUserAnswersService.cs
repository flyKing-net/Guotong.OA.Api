using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.IService
{
    public interface IVoiceUserAnswersService:IBaseService<VoiceUserAnswers>
    {
        Task<bool> AddUserAnswers(VoiceUserAnswers voiceUserAnswers);
    }
}
