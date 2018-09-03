using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    public class Initer
    {
        public static IContainer Load()
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            //var typesss = assembly.ExportedTypes.Where(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(AopLogAttribute)));
            //var assembly =this.GetType().GetTypeInfo().Assembly;
            builder.RegisterType<AopLogInterceptor>();
            builder.RegisterType<SafeExecInterceptor>();

            Dictionary<string, Type> interceptorMapping = new Dictionary<string, Type>()
            {
                {typeof(AopLogAttribute).FullName, typeof( AopLogInterceptor )},
                {typeof(SafeExecAttribute).FullName, typeof( SafeExecInterceptor )}
            };
            foreach(var type in assembly.ExportedTypes)
            {
            //    interceptorMapping[type.CustomAttributes.First().AttributeType.FullName]

                Type tempType = null;
                var interceptors= type.CustomAttributes.Select(p => interceptorMapping.TryGetValue(p.AttributeType.FullName,out tempType)?tempType:null)
                    .Where(p => p != null).ToArray();
                if(interceptors.Length>0)
                {
                    builder.RegisterType(type)
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope()
                        .EnableInterfaceInterceptors()
                        .InterceptedBy(interceptors);
                }
            }

            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(type=>type.CustomAttributes.Any(p=>p.AttributeType==typeof(AopLogAttribute)))
            //    .AsImplementedInterfaces()//把Where筛选出来的类，都注册为可以实现它们的接口。即，使用IOC.Resolve<接口>，即可创建实例
            //    .InstancePerLifetimeScope()
            //    .EnableInterfaceInterceptors()//在这些类上，允许接口注入。在接口或类上加上接口标签，就可以注入该标签的实现
            //    .InterceptedBy(typeof(AopLogInterceptor));//列出允许注入的标签类型

            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(type => type.CustomAttributes.Any(p => p.AttributeType == typeof(SafeExecAttribute)))
            //    .AsImplementedInterfaces()//把Where筛选出来的类，都注册为可以实现它们的接口。即，使用IOC.Resolve<接口>，即可创建实例
            //    .InstancePerLifetimeScope()
            //    .EnableInterfaceInterceptors()//在这些类上，允许接口注入。在接口或类上加上接口标签，就可以注入该标签的实现
            //    .InterceptedBy(typeof(SafeExecInterceptor));//列出允许注入的标签类型
            return builder.Build();
        }
    }


}
