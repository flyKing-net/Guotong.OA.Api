using Guotong.Api.IService.Base;
using Guotong.Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IService
{
    public interface IUserService:IBaseService<User>
    {
        Task<int> GetCount();

    }
}
