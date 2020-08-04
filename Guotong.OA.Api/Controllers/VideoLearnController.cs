using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Guotong.Api.Controllers
{
    /// <summary>
    /// 视频学习
    /// </summary>
    public class VideoLearnController : BaseController
    {
        private readonly ILogger<VideoLearnController> _logger;
        public VideoLearnController(ILogger<VideoLearnController> logger) {
            _logger = logger;
        }

        /// <summary>
        /// 得到视频列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Video() {
            return Ok("公司制度");
        }
    }
}
