using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Guotong.Api.Repository.Dapper
{
    public class DapperHelper
    {
        /// <summary>
        /// 数据库连接名
        /// </summary>
        private static string _connection = string.Empty;

        /// <summary>
        /// 获取连接名
        /// </summary>
        private static string Connection {
            get { return _connection; }
        }

        /// <summary>
        /// 返回连接实例
        /// </summary>
        private static IDbConnection dbConnection = null;

        /// <summary>
        /// 静态变量保存类的实例
        /// </summary>
        private static DapperHelper uniqueInstance;

        /// <summary>
        /// 定义一个标识确保线程同步
        /// </summary>
        private static readonly object locker = new object();

        /// <summary>
        /// 私有构造方法，使外界不能创建该类的实例，以便实现单例模式
        /// </summary>
        private DapperHelper() {
            _connection = BaseDBConfig.ConnectionString; //读取配置文件
        }

        /// <summary>
        /// 获取实例，这里为单例模式，保证只存在一个实例
        /// </summary>
        /// <returns></returns>
        public static DapperHelper GetInstance() {
            if (uniqueInstance==null)
            {
                lock (locker)
                {
                    if (uniqueInstance==null)
                    {
                        uniqueInstance = new DapperHelper();
                    }
                }
            }
            return uniqueInstance;
        }

        /// <summary>
        /// 创建数据库连接对象，并打开连接
        /// </summary>
        /// <returns></returns>

        public static IDbConnection OpenCurrentDbConnection() {
            if (dbConnection==null)
            {
                dbConnection = new SqlConnection(Connection);
            }
            //判断连接状态
            if (dbConnection.State==ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            return dbConnection;
        }

    }
}
