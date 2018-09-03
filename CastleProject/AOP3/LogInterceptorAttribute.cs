using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOP3
{
    //这是打在类上的标签，用于标识这个类会被切面拦截AOP
    [AttributeUsage(AttributeTargets.Class)]
    public class UseInterceptorAttribute : Attribute 
    {
    }

    //这是打在方法上的标签，用于标识此方法会被【哪些】切面拦截
    public interface IMethodProxy 
    {
        IMethodProxy NextProxy { get; }
        IInvocation InnerInvocation { get;}
        void Execute();
    }
    public class BaseMethodProxy : Attribute,IMethodProxy
    {
        public BaseMethodProxy()
        {

        }
        public BaseMethodProxy(IMethodProxy nextProxy, IInvocation innerInvocation)
        {
            InnerInvocation = innerInvocation;
            NextProxy = nextProxy;
        }
        public IInvocation InnerInvocation { get; private set; }
        public IMethodProxy NextProxy { get; private set; }
        public virtual void Execute()
        {
            if (NextProxy != null)
                NextProxy.Execute();
            else
                InnerInvocation.Proceed();   
        }
    }
    
    [AttributeUsage(AttributeTargets.Method)]
    public class PerformanceLogAttribute : BaseMethodProxy
    {
        public PerformanceLogAttribute()
        {

        }
        public PerformanceLogAttribute(IMethodProxy nextProxy, IInvocation innerInvocation):base(nextProxy,innerInvocation)
        {
        }
        
        public override void Execute()
        {
            Console.WriteLine("Performance Log Start");
            base.Execute();
            Console.WriteLine("Performance Log End");
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class SafeExecuteAttribute : BaseMethodProxy 
    {
        public SafeExecuteAttribute()
        {

        }
        public SafeExecuteAttribute(IMethodProxy nextProxy, IInvocation innerInvocation) : base(nextProxy, innerInvocation)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("SafeExecute Start");
            base.Execute();
            Console.WriteLine("SafeExecute End");
        }
    }
    

    public class ClassInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var attrs = invocation.Method.CustomAttributes.Select(p=>p.AttributeType).ToList();
            IMethodProxy lastMethodProxy = null;


            foreach(var attr in attrs)
            {
                if(attr == typeof(SafeExecuteAttribute))
                {
                    lastMethodProxy = new SafeExecuteAttribute(lastMethodProxy,invocation);
                }
                else if (attr == typeof(PerformanceLogAttribute))
                {
                    lastMethodProxy = new PerformanceLogAttribute(lastMethodProxy, invocation);
                }
            }
            lastMethodProxy.Execute();
        }
    }


}
