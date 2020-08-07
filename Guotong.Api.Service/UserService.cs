using Guotong.Api.IRepository;
using Guotong.Api.IService;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository;
using Guotong.Api.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository userDal;
        public UserService(IUserRepository userRepository) {
            userDal = userRepository;
        }


        public List<User> GetAllUserInfo()
        {
            return userDal.GetAllUserInfo();
        }

        public User GetUser(string userName, string passWord)
        {
            return userDal.GetUser(userName,passWord);
        }
    }
}
