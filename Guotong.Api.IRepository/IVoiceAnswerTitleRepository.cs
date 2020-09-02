using Guotong.Api.IRepository.Base;
using Guotong.Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository
{
    public interface IVoiceAnswerTitleRepository:IBaseRepository<VoiceAnswerTitle>
    {
        List<VoiceAnswerTitle> GetAnswerList(int startPage,int endPage,int cid,int userid);

        Task<int> AddAnswerTitle(VoiceAnswerTitle voiceAnswerTitle);

        Task<int> UpdateAnswerTitle(VoiceAnswerTitle voiceAnswerTitle);
    }
}
