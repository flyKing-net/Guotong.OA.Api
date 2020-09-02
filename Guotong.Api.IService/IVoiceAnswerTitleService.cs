using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IService
{
    public interface IVoiceAnswerTitleService:IBaseService<VoiceAnswerTitle>
    {
        List<VoiceAnswerListViewModel> GetAnswerList(int startPage, int endPage, int cid, int userid);

        Task<bool> AddAnswerTitle(VoiceAnswerTitle voiceAnswerTitle);

        Task<bool> UpdateAnswerTitle(VoiceAnswerTitle voiceAnswerTitle);
    }
}
