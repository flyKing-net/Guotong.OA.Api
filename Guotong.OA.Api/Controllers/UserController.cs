﻿using System;
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
using System.Security.Cryptography;
using System.Text;

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

        IUserService userService = new UserService();
        /// <summary>
        /// 用户登陆
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
            string msg = "";
            if (!string.IsNullOrWhiteSpace(userName)&&!string.IsNullOrWhiteSpace(password)&&role != null)
            {
                var pwdMd5 = Md5(password); //md5加密
                User user=userService.GetUser(userName,pwdMd5);
                if (user!=null)
                {
                    //将用户id和角色名，作为单独的自定义变量封装进token字符串
                    TokenModel tokenModel = new TokenModel { Uid = "admin", Role = role };
                    jwtStr = JwtHelper.IssueJwt(tokenModel); //登录，获取到一定规则的Token令牌
                    suc = true;
                    msg = $"【{user.Name}】欢迎登录！！！";
                }
                else {
                    jwtStr = "login fail!!!";
                    msg = "请检查用户名或密码是否正确";
                }
            }
            else {
                jwtStr = "login fail!!!";
                msg = "请录入完整信息";
            }

            return Ok(new { 
            success=suc,
            token=jwtStr,
            msg=msg
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
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUserInfo() {
            List<User> users = userService.GetAllUserInfo();
            return Ok(users);
        }

        /// <summary>
        /// md5 加密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public string Md5(string pwd) {
            using (var md5=MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                var strResult = BitConverter.ToString(result);
                string results = strResult.Replace("-","");
                return results.ToLower();
            }
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



    }
}
