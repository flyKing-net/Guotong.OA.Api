using Dapper;
using Guotong.Api.IRepository;
using Guotong.Api.Model.Entity;
using Guotong.Api.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guotong.Api.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User GetUser(string userName, string passWord)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" select Id,Name,DepartmentId,DepartmentName from [User] ");
            sqlStr.Append(" where Account=@Account and Password=@Password ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Account",userName);
            parameters.Add("Password",passWord);
            return Detail(sqlStr.ToString(), parameters);
        }

        public List<User> GetAllUserInfo()
        {
            string sql = "select * from [User]";
            return Select(sql,null);
        }

        public async Task<User> GetById(int id)
        {
            string sql = "select * from [User] where Id=@Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id",id);
            return await DetailAsync(sql,parameters);
        }

    }
}
