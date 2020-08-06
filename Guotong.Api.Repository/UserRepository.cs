using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public async Task<int> GetCount()
        {
            int count = await ExecuteScalarAsync<int>("select count(*) form [User]");
           return count;
        }
    }
}
