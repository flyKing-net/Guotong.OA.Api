using Guotong.Api.IRepository.Base;
using Guotong.Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository
{
    public interface IVoiceAnswerInfoRepository:IBaseRepository<VoiceAnswerInfo>
    {
        Task<int> AddAnswerInfo(VoiceAnswerInfo voiceAnswerInfo);
    }
}
