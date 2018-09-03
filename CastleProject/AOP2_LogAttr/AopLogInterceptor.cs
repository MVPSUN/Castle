using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    public class AopLogInterceptor : IInterceptor
    { 
        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget;
            if (methodInfo == null)
            {
                methodInfo = invocation.Method;
            }
            var nameSpace = methodInfo.DeclaringType.Namespace;
            var className = methodInfo.DeclaringType.FullName;

            Console.WriteLine("PreExecute: Method Name is "+ className+"，Args"+string.Join(",", invocation.Arguments.Select(p=>Convert.ToString(p))));
            Stopwatch watch = new Stopwatch();
            watch.Start();
            invocation.Proceed(); //实际的方法
            Console.WriteLine("PostExecute: Result is " + Convert.ToString(invocation.ReturnValue)+"。Executing milSecs:"+watch.ElapsedMilliseconds);
            watch.Stop();
            //获取方法标签上的参数
            //TransactionCallHandlerAttribute transaction = methodInfo.GetCustomAttributes<TransactionCallHandlerAttribute>(true).FirstOrDefault();

        }
    }


    public class SafeExecInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Console.WriteLine("Pre SafeExecute");
                invocation.Proceed();
                Console.WriteLine("Post SafeExecute");
            }
            catch (Exception ex)
            {
            }
        }
    }



}
