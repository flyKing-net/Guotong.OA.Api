using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository
{
    public class VoiceSubjectInfoRepository : BaseRepository<VoiceSubjectInfo>, IVoiceSubjectInfoRepository
    {
        public async Task<int> AddVoiceSubject(VoiceSubjectInfo voiceSubjectInfo)
        {
            string sql = @"insert VoiceSubjectInfo(AnswerTitleId,SubjectId,SubjectContent,TimeLimit,SubjectType,PublishTime,SubjectTimeLength,MinTimeLimit) 
                          values(@AnswerTitleId,@SubjectId,@SubjectContent,@TimeLimit,@SubjectType,@PublishTime,@SubjectTimeLength,@MinTimeLimit)";
            return await Insert(sql,voiceSubjectInfo);
        }

     
        public List<VoiceSubjectInfo> GetVoiceSubjectInfos(int answerTitleId)
        {
            string sql = @"select sub.Id,AnswerTitleId,SubjectId,SubjectContent,SubjectTimeLength,TimeLimit,MinTimeLimit,SubjectType,sub.PublishTime,AnswerTitle from VoiceSubjectInfo sub 
                           left join VoiceAnswerTitle que on sub.AnswerTitleId=que.Id where AnswerTitleId=@answerTitleId order by AnswerTitleId,SubjectId ";
            return Select<VoiceSubjectInfo, VoiceAnswerTitle>(sql, new { answerTitleId = answerTitleId }, (VoiceSubjectInfo, VoiceAnswerTitle) =>
            {
                VoiceSubjectInfo.answerTitle = VoiceAnswerTitle;
                return VoiceSubjectInfo;
            }, "AnswerTitle");
        }

        public Task<int> UpdateVoiceSubject(VoiceSubjectInfo voiceSubjectInfo)
        {
            string sql = @"update VoiceSubjectInfo set AnswerTitleId=@AnswerTitleId,SubjectId=@SubjectId,SubjectContent=@SubjectContent,TimeLimit=@TimeLimit,
                         SubjectType=@SubjectType,PublishTime=@PublishTime,SubjectTimeLength=@SubjectTimeLength,MinTimeLimit=@MinTimeLimit where Id=@Id";
            return Update(sql,voiceSubjectInfo);
        }
    }
}
