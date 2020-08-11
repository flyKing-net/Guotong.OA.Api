using AutoMapper;
using Guotong.Api.IRepository;
using Guotong.Api.IRepository.Base;
using Guotong.Api.IService;
using Guotong.Api.Model.Entity;
using Guotong.Api.Model.ViewModel;
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
        private readonly IMapper iMapper;
        public UserService(IBaseRepository<User> baseRepository,IUserRepository userRepository,IMapper IMapper):base(baseRepository) {
            userDal = userRepository;
            iMapper = IMapper;
        }


        public List<User> GetAllUserInfo()
        {
            return userDal.GetAllUserInfo();
        }

        public Task<User> GetById(int id)
        {
            return userDal.GetById(id);
        }

        public User GetUser(string userName, string passWord)
        {
            return userDal.GetUser(userName,passWord);
        }

        public async Task<UserViewModel> GetUserDetails(int id)
        {
            var userinfo = await userDal.GetById(id);
            if (userinfo != null)
            {
                //UserViewModel userViewModel = new UserViewModel
                //{
                //    Name = userinfo.Name,
                //    DepartmentName = userinfo.DepartmentName,
                //    Account = userinfo.Account,
                //    Status = userinfo.Status,
                //    CreateTime = userinfo.CreateTime
                //};

                UserViewModel userViewModel = iMapper.Map<UserViewModel>(userinfo);
                return userViewModel;
            }
            else
            {
                return null;
            }

        }
    }
}
