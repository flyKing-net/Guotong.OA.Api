using Guotong.OA.Api;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Guotong.Api.SetUp
{
    public static class SwaggerSetUp
    {
        public static void AddSwaggerSetup(this IServiceCollection services) {
            if (services==null) throw new ArgumentNullException(nameof(services));
            var apiName = "api接口文档";
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1.0", //版本号
                    Title = $"{apiName}", //定义全局，方便修改
                    Description = "审计事业部api接口文档", //描述
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "成都账联网络科技有限公司" }, //主体
                    License = new Microsoft.OpenApi.Models.OpenApiLicense { Name = "成都账联网络科技有限公司许可证" } //许可证
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location); //路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //生成xml文件
                var xmlPath = Path.Combine(basePath, xmlFile); // 获取xml注释文件的目录
                c.IncludeXmlComments(xmlPath, true); //注册

                //var xmlModelPath = Path.Combine(AppContext.BaseDirectory, "Webapi.Core.Model.xml");//这个就是Model层的xml文件名
                //c.IncludeXmlComments(xmlModelPath);
                var xmlModelPath = Path.Combine(basePath, "Guotong.Api.Model.xml"); //Model层的文件名
                c.IncludeXmlComments(xmlModelPath, true);

                //在header 中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                #region Token绑定到ConfigureServices
                c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT授权（数据将在请求头中进行传输）直接在下框中输入Bearer{token}（注意两者之间是一个空格）",
                    Name="Authorization", //jwt默认的参数名称
                    In=Microsoft.OpenApi.Models.ParameterLocation.Header,//jwt默认存放Authorization信息的位置（请求头中）
                    Type=Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                }) ;
                #endregion
            });
        }
    }
}
