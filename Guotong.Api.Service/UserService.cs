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
        IUserRepository userDal = new UserRepository();
        public async Task<int> GetCount()
        {
           return await userDal.GetCount();
        }
    }
}
