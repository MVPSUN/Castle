using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOP1
{
    public class TransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Start:" + Convert.ToString(invocation.ReturnValue));

            invocation.Proceed(); //实际的方法

            Console.WriteLine("End:" + invocation.ReturnValue.ToString());
            //获取方法标签上的参数
            //TransactionCallHandlerAttribute transaction = methodInfo.GetCustomAttributes<TransactionCallHandlerAttribute>(true).FirstOrDefault();

        }
    }
}
