using AutoMapper;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;

namespace Guotong.Api.AutoMapper
{
    /// <summary>
    /// 添加映射文件类
    /// </summary>
    public class CustomProfile:Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile() {
            CreateMap<User, UserViewModel>();
            CreateMap<VideoLearnCenter, VideoCenterViewModel>()
                .ForMember(d=>d.WatchLongTime,o=>o.MapFrom(s=>s.VideoLearnRecord.WatchLongTime))
                .ForMember(d=>d.WatchState,o=>o.MapFrom(s=>s.VideoLearnRecord.WatchState))
                .ForMember(d=>d.UpdateTime,o=>o.MapFrom(s=>s.VideoLearnRecord.FinishWatchTime));

            CreateMap<VideoLearnRecord, VideoRecordViewModel>();

            CreateMap<VoiceAnswerTitle, VoiceAnswerListViewModel>()
                .ForMember(d=>d.AnswerState,o=>o.MapFrom(s=>s.userAnswers.AnswerState))
                .ForMember(d=>d.AnswerCount,o=>o.MapFrom(s=>s.userAnswers.AnswerCount))
                .ForMember(d=>d.ViolationState,o=>o.MapFrom(s=>s.userAnswers.ViolationState));

            CreateMap<VoiceSubjectInfo, VoiceSubjectInfoViewModel>()
                .ForMember(d=>d.AnswerTitle,o=>o.MapFrom(s=>s.answerTitle.AnswerTitle));
        }
    }
}
