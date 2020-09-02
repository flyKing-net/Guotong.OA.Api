using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Guotong.Api.Repository
{
    public class VoiceAnswerInfoRepository : BaseRepository<VoiceAnswerInfo>, IVoiceAnswerInfoRepository
    {
        public async Task<int> AddAnswerInfo(VoiceAnswerInfo voiceAnswerInfo)
        {
            string sql = "insert into VoiceAnswerInfo(AnswerId,AnswerContent,AnswerTime,SubjectInfoId,SubmitTime,AnswerText) values(@AnswerId,@AnswerContent,@AnswerTime,@SubjectInfoId,@SubmitTime,@AnswerText)";
            return await Insert(sql, voiceAnswerInfo);
        }
    }
}
