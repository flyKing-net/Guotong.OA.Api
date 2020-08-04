using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guotong.Api.Auth;
using Guotong.Api.IService;
using Guotong.Api.Model;
using Guotong.Api.Model.Entity;
using Guotong.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Guotong.Api.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserController:BaseController
    {
        //private readonly ITestService _testService;

        //public UserController(ITestService testService) {
        //    _testService = testService;
        //}
       /// <summary>
       /// 模拟登陆
       /// </summary>
       /// <param name="userName">用户名</param>
       /// <param name="password">密码</param>
       /// <param name="role">角色</param>
       /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string userName,string password,string role)
        {
            string jwtStr = string.Empty;
            bool suc = false;
            if (!string.IsNullOrWhiteSpace(userName)&&!string.IsNullOrWhiteSpace(password)&&role != null)
            {
                if (userName.Equals("Acclink") && password.Equals("123456"))
                {
                    //将用户id和角色名，作为单独的自定义变量封装进token字符串
                    TokenModel tokenModel = new TokenModel { Uid = "admin", Role = role };
                    jwtStr = JwtHelper.IssueJwt(tokenModel); //登录，获取到一定规则的Token令牌
                    suc = true;
                }
                else {
                    jwtStr = "login fail!!!";
                }
            }
            else {
                jwtStr = "login fail!!!";
            }

            return Ok(new { 
            success=suc,
            token=jwtStr
            });
        }

        /// <summary>
        /// 需要Admin权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Admin() {
            return Ok("hello Admin");
        }


        /// <summary>
        /// 需要System权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="System")]
        public IActionResult System() {
            return Ok("hello System");
        }

        /// <summary>
        /// 需要Admin和System权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy ="SystemOrAdmin")]
        public IActionResult AdminAndSystem() {
            return Ok("hello AdminAndSystem");
        }


        /// <summary>
        /// 解析Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult ParseToken() {
            //截取Bearer
            var tokenHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").TrimStart();
            var user = JwtHelper.SerializeJwt(tokenHeader);
            return Ok(user);
        }

        ///// <summary>
        ///// 求和
        ///// </summary>
        ///// <param name="i"></param>
        ///// <param name="j"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult SumNumber(int i,int j) {
        //    return Ok(_testService.Sum(i,j));
        //}
    }
}
