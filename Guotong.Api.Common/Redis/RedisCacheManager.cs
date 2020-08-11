using Guotong.Api.Common.Helper;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Common.Redis
{
    public class RedisCacheManager : IRedisCacheManager
    {
        private readonly string redisConnectionString;
        public volatile ConnectionMultiplexer redisConnection;
        private readonly object redisConnectionLock = new object();

        public RedisCacheManager() {
            string redisConfiguration = AppSettings.app(new string[] {"AppSettings","RedisCaching","ConnectionString" }); //获取连接字符串
            if (string.IsNullOrWhiteSpace(redisConfiguration))
            {
                throw new ArgumentException("redis的连接为空",nameof(redisConfiguration));
            }
            this.redisConnectionString = redisConfiguration;
            this.redisConnection = GetRedisConnection();
        }

        /// <summary>
        /// 获取连接实例
        /// 通过双if夹lock的方式，实现单例模式
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetRedisConnection() {
            //如果已经连接实例，直接返回
            if (this.redisConnection!=null&&this.redisConnection.IsConnected)
            {
                return this.redisConnection;
            }
            //加锁，防止异步编程中，出现单例无效的问题
            lock (redisConnectionLock)
            {
                if (this.redisConnection!=null)
                {
                    //释放redis连接
                    this.redisConnection.Dispose();
                }
                try
                {
                    //打开redis连接
                    this.redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
                }
                catch (Exception)
                {

                    throw new Exception("Redis服务未启用，请开启该服务");
                }
            }
            return this.redisConnection;
        }

        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public T Get<T>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将redis存储的Byte[]，进行反序列化
                return SerializeHelper.Deserialize<T>(value);
            }
            else {
                return default(T);
            }
        }

        public bool Get(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
        }

        public string GetValue(string key)
        {
            return redisConnection.GetDatabase().StringGet(key);
        }

        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value!=null)
            {
                //序列化，将object值生成RedisValue
                redisConnection.GetDatabase().StringSet(key,SerializeHelper.Serialize(value),cacheTime);
            }
        }

        public bool SetValue(string key,byte[] value) {
            return redisConnection.GetDatabase().StringSet(key,value,TimeSpan.FromSeconds(120));
        }
    }
}
