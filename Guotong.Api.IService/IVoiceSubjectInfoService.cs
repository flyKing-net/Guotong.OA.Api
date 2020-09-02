using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Guotong.Api.IService
{
    public interface IVoiceSubjectInfoService:IBaseService<VoiceSubjectInfo>
    {
        List<VoiceSubjectInfoViewModel> GetVoiceSubjectInfos(int answerTitleId);

        Task<bool> AddVoiceSubject(VoiceSubjectInfo voiceSubjectInfo);

        Task<bool> UpdateVoiceSubject(VoiceSubjectInfo voiceSubjectInfo);
    }
}
