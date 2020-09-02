using Guotong.Api.Model.Entity;
using Guotong.Api.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository
{
    public interface IVoiceSubjectInfoRepository:IBaseRepository<VoiceSubjectInfo>
    {
        List<VoiceSubjectInfo> GetVoiceSubjectInfos(int answerTitleId);

        Task<int> AddVoiceSubject(VoiceSubjectInfo voiceSubjectInfo);

        Task<int> UpdateVoiceSubject(VoiceSubjectInfo voiceSubjectInfo);
    }
}
