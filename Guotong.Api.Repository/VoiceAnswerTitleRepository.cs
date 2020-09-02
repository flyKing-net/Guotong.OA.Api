using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository
{
    public class VoiceAnswerTitleRepository : BaseRepository<VoiceAnswerTitle>, IVoiceAnswerTitleRepository
    {
        public async Task<int> AddAnswerTitle(VoiceAnswerTitle voiceAnswerTitle)
        {
            string sql = "insert VoiceAnswerTitle(AnswerTitle,RulesOfAnswer,PublishCid,PublisherId,PublishTime) values(@AnswerTitle,@RulesOfAnswer,@PublishCid,@PublisherId,@PublishTime)";
            return await Insert(sql,voiceAnswerTitle);
        }

        public List<VoiceAnswerTitle> GetAnswerList(int startPage, int endPage, int cid, int userid)
        {
            string sql = @"select Id,cast(Id as nvarchar)+'-'+AnswerTitle AnswerTitle,RulesOfAnswer,PublishCid,PublisherId,PublishTime,AnswerState,ViolationState,AnswerCount from 
                           (select ques.*,row_number() over (order by PublishTime desc) as RowNumber,case when isnull(answers.AnswerTitleId,0)=0 then 0 else 1 end AnswerState,
                           isnull(ViolationState,0) ViolationState,isnull(AnswerCount,0) AnswerCount from VoiceAnswerTitle ques left join (
                           select AnswerTitleId,max(ViolationState) ViolationState,COUNT(1) AnswerCount from VoiceUserAnswers where Cid=@cid and UserId=@userid group by AnswerTitleId) answers 
                           on ques.Id=answers.AnswerTitleId) a where RowNumber>=@startPage and RowNumber<=@endPage order by PublishTime desc ";
            return Select<VoiceAnswerTitle, VoiceUserAnswers>(sql,new {cid=cid,userid=userid,startPage=startPage,endPage=endPage },
                                                       (VoiceAnswerTitle,VoiceUserAnswers)=> {
                                                           VoiceAnswerTitle.userAnswers = VoiceUserAnswers;
                                                           return VoiceAnswerTitle;
                                                       }, "AnswerState");
        }

        public async Task<int> UpdateAnswerTitle(VoiceAnswerTitle voiceAnswerTitle)
        {
            string sql = "update VoiceAnswerTitle set AnswerTitle=@AnswerTitle,RulesOfAnswer=@RulesOfAnswer,PublishCid=@PublishCid,PublisherId=@PublisherId,PublishTime=@PublishTime where Id=@Id";
            return await Update(sql,voiceAnswerTitle);
        }
    }
}
