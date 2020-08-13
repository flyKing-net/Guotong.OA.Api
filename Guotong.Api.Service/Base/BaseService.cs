using Guotong.Api.IRepository.Base;
using Guotong.Api.IService.Base;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Service.Base
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        private readonly IBaseRepository<T> baseDal;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            baseDal = baseRepository;
        }

        public async Task<bool> Add(string sql, object param)
        {
           return await baseDal.Insert(sql, param) >0;
        }

        public async Task<bool> DeleteByIds(string sql, object param)
        {
            return await baseDal.Delete(sql, param) >0;
        }

        public async Task<T> Query(string sql,object param)
        {
           return await baseDal.DetailAsync(sql, param);
        }

        public async Task<bool> Update(string sql, object param)
        {
            return await baseDal.Update(sql, param) >0;
        }
    }
}
