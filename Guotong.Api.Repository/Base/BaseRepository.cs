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
        public async Task<int> Delete(string sql, object param)
        {
            return await ExecuteAsync(sql,param);
        }

        public T Detail(string sql, object param)
        {
           return QueryFirstOrDefault<T>(sql, param);
        }

        public async Task<T> DetailAsync(string sql,object param)
        {
            return await QueryFirstOrDefaultAsync<T>(sql,param);
        }

        public async Task<int> Insert(string sql, object param)
        {
            return await ExecuteAsync(sql, param);
        }

        public List<T> Select(string sql,object param)
        {
            return Query<T>(sql,param).ToList();
        }

        public async Task<List<T>> SelectAsync(string sql)
        {
            return (List<T>)await QueryAsync<T>(sql);
        }

        public async Task<int> Update(string sql, object param)
        {
            return await ExecuteAsync(sql, param);
        }
    }
}
