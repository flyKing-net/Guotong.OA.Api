using Guotong.Api.IRepository.Base;
using Guotong.Api.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository.Base
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    public class BaseRepository<T> : DbContext, IBaseRepository<T> where T : class, new()
    {
        public async Task<int> Delete(string sql)
        {
            return await ExecuteAsync(sql);
        }

        public T Detail(string sql)
        {
           return QueryFirstOrDefault<T>(sql);
        }

        public async Task<T> DetailAsync(string sql)
        {
            return await QueryFirstOrDefaultAsync<T>(sql);
        }

        public async Task<int> Insert(string sql)
        {
            return await ExecuteAsync(sql);
        }

        public List<T> Select(string sql)
        {
            return Query<T>(sql).ToList();
        }

        public async Task<List<T>> SelectAsync(string sql)
        {
            return (List<T>)await QueryAsync<T>(sql);
        }

        public async Task<int> Update(string sql)
        {
            return await ExecuteAsync(sql);
        }
    }
}
