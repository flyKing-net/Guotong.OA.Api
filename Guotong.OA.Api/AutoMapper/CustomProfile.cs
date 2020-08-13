using AutoMapper;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            CreateMap<VideoLearnCenter, VideoCenterViewModel>();
        }
    }
}
