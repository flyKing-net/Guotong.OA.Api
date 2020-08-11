using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.IRepository.Base
{
    /// <summary>
    /// 基类接口，其他接口继承该接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        T Detail(string sql, object param);

        /// <summary>
        /// 异步查询一条记录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<T> DetailAsync(string sql, object param);

        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        List<T> Select(string sql);

        /// <summary>
        /// 异步查询多条记录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<List<T>> SelectAsync(string sql);

        Task<int> Insert(string sql);

        Task<int> Update(string sql);

        Task<int> Delete(string sql);

    }
}
