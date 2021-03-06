﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Guotong.Api.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Guotong.Api.SetUp
{
    public class AutofacModuleRegister:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册RedisAop
            builder.RegisterType<RedisCacheAOP>();

            //反射加载程序集，注册service
            var assemblysServices = Assembly.Load("Guotong.Api.Service");
            builder.RegisterAssemblyTypes(assemblysServices)
                .InstancePerDependency() //瞬时单例
                .AsImplementedInterfaces() //自动以其实现的所有接口类型暴露
                .EnableInterfaceInterceptors() //引用Autofac.Extras.DynamicProxy
                .InterceptedBy(typeof(RedisCacheAOP)); //还可放一AOP拦截器集合

            //注册Repository
            var assemblysRepository = Assembly.Load("Guotong.Api.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository)
                .InstancePerDependency() //瞬时单例
                .AsImplementedInterfaces() //自动以其实现的所有接口类型暴露
                .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy
        }
    }
}
