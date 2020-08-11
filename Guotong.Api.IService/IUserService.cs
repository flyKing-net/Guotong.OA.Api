using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IService
{
    public interface IUserService:IBaseService<User>
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        User GetUser(string userName, string passWord);

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUserInfo();

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<User> GetById(int id);

        /// <summary>
        /// 获取用户详细
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<UserViewModel> GetUserDetails(int id);
    }
}
