using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using Guotong.Api.SetUp;
using Guotong.Api.Common.Helper;
using Guotong.Api.IService;
using Guotong.Api.Service;
using Guotong.Api.Repository.Dapper;
using Autofac;
using Guotong.Api.Common.Redis;
using AutoMapper;
using log4net.Repository;
using Guotong.Api.Log;
using log4net;
using log4net.Config;
using Guotong.Api.Filter;
using Guotong.Api.Middleware;
using Guotong.Api.JsonConv;

namespace Guotong.OA.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// log4net 仓储
        /// </summary>
        public static ILoggerRepository repository { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            //注册appsettings读取类
            services.AddSingleton(new AppSettings(Configuration));
            //var text = AppSettings.app(new string[] {"AppSettings", "ConnectionString" });
            //Console.WriteLine($"ConnectionString:{text}");
            //Console.ReadLine();

            BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;

            //使用静态类封装注册Swagger
            services.AddSwaggerSetup();

            //jwt授权验证
            services.AddAuthorizationSetUp();

            services.AddControllers();

            //注册redis
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();

            //注入映射
            services.AddAutoMapper(typeof(Startup));

            //log注入ILoggerHelper
            services.AddSingleton<ILoggerHelper, LoggerHelper>();

            repository = LogManager.CreateRepository("");//需要获取日志的仓库名
            XmlConfigurator.Configure(repository,new FileInfo("Log4net.config"));//指定配置文件

            //注入全局异常
            services.AddControllers(option => {
                option.Filters.Add(typeof(GlobalExceptionFilter));
            }).AddJsonOptions(option=> {
                //空的字段不返回
                option.JsonSerializerOptions.IgnoreNullValues = true;
                //返回json小写
                option.JsonSerializerOptions.PropertyNamingPolicy = new LowercasePolicy();
                //时间格式格式化
                option.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                option.JsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
            });
        }

        public void ConfigureContainer(ContainerBuilder builder) {
            builder.RegisterModule(new AutofacModuleRegister()); //注册AutofacModuleRegister
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCustomExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json","Web App V1.0");
                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
