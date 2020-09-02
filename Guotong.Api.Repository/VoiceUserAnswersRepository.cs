using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository
{
    public class VoiceUserAnswersRepository :BaseRepository<VoiceUserAnswers>, IVoiceUserAnswersRepository
    {
        public async Task<int> AddUserAnswers(VoiceUserAnswers voiceUserAnswers)
        {
            string sql = "insert into VoiceUserAnswers(AnswerTitleId,Cid,UserId,SubmitTime,ViolationState) values(@AnswerTitleId,@Cid,@UserId,@SubmitTime,@ViolationState)";
            return await Insert(sql,voiceUserAnswers);
        }
    }
}
