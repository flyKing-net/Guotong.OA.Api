
using Guotong.Api.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guotong.Api.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _env;
        private readonly ILoggerHelper _loggerHelper;

        public GlobalExceptionFilter(IHostEnvironment env, ILoggerHelper loggerHelper)
        {
            _env = env;
            _loggerHelper = loggerHelper;
        }


        public void OnException(ExceptionContext context)
        {
            var json = new JsonErrorResponse();
            json.Status = StatusCodes.Status500InternalServerError;
            json.Message = context.Exception.Message; //错误信息
            if (_env.IsDevelopment())
            {
                json.DevelopmentMessage = context.Exception.StackTrace; //堆栈信息
            }
            context.Result = new InternalServerErrorObjectResult(json);

            //采用log4net 进行错误日志记录
            _loggerHelper.Error(json.Message,"出现未知异常",context.Exception);
        }

        public class InternalServerErrorObjectResult : ObjectResult {
            public InternalServerErrorObjectResult(object value) : base(value) {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        public class JsonErrorResponse
        {
            public int Status { get; set; }

            public bool Success { get; set; } = false;
            /// <summary>
            /// 生产环境的消息
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// 开发环境的消息
            /// </summary>
            public string DevelopmentMessage { get; set; }
        }

    }
}
