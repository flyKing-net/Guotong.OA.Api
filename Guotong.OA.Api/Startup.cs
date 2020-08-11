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

namespace Guotong.OA.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            //ע��appsettings��ȡ��
            services.AddSingleton(new AppSettings(Configuration));
            //var text = AppSettings.app(new string[] {"AppSettings", "ConnectionString" });
            //Console.WriteLine($"ConnectionString:{text}");
            //Console.ReadLine();

            BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;

            //ʹ�þ�̬���װע��Swagger
            services.AddSwaggerSetup();

            //jwt��Ȩ��֤
            services.AddAuthorizationSetUp();

            services.AddControllers();

            //ע��redis
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();

            //ע��ӳ��
            services.AddAutoMapper(typeof(Startup));
        }

        public void ConfigureContainer(ContainerBuilder builder) {
            builder.RegisterModule(new AutofacModuleRegister()); //ע��AutofacModuleRegister
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json","Web App V1.0");
                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
