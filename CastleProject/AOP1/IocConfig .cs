using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOP1
{
    public class Initer
    {
        public static IContainer Load()
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            //var assembly =this.GetType().GetTypeInfo().Assembly;
            builder.RegisterType<TransactionInterceptor>();
            builder.RegisterAssemblyTypes(assembly)
                .Where(type => typeof(IDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                .AsImplementedInterfaces()//把Where筛选出来的类，都注册为可以实现它们的接口。即，使用IOC.Resolve<接口>，即可创建实例
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()//在这些类上，允许接口注入。在接口或类上加上接口标签，就可以注入该标签的实现
                .InterceptedBy(typeof(TransactionInterceptor));//列出允许注入的标签类型
            return builder.Build();
        }
    }


}
