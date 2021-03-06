﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Common.Redis
{
    /// <summary>
    /// Redis缓存接口
    /// </summary>
    public interface IRedisCacheManager
    {
        /// <summary>
        /// 获取Redis 缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        /// 异步获取Redis缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> GetValueAsync(string key);


        /// <summary>
        /// 获取值，并序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 异步获取值，并序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// 保存缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        void Set(string key,object value,TimeSpan cacheTime);

        /// <summary>
        /// 异步保存缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        Task SetAsync(string key, object value, TimeSpan cacheTime);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Get(string key);

        /// <summary>
        /// 异步判断是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> GetAsync(string key);

        /// <summary>
        /// 移除某一个缓存值
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 异步移除某一个缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveAsync(string key);

        /// <summary>
        /// 全部清除
        /// </summary>
        void Clear();

        /// <summary>
        /// 异步全部清除
        /// </summary>
        /// <returns></returns>
        Task ClearAsync();
    }
}
