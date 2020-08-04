using System;
using System.Collections.Generic;
using System.Text;

namespace Guotong.Api.Model.Entity
{
    public class User
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public int Cid { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 推送token
        /// </summary>
        public string SocketToken { get; set; }

        /// <summary>
        /// 推送电话类型
        /// </summary>
        public int SocketPhoneModel { get; set; }     
    }
}
