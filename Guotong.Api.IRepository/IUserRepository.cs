using Guotong.Api.IRepository.Base;
using Guotong.Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository
{
    public interface IUserRepository:IBaseRepository<User>
    {
        List<User> GetAllUserInfo();
        User GetUser(string userName,string passWord);
        Task<User> GetById(int id);
    }
}
