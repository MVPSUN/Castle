using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleProjectDemo.Castle
{
    public class IntermediaryIntercetor : IInterceptor
    {
        /// <summary>
        /// 只有virtual才会触发代理类
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            CollectIntermediaryFeesBefore();
            invocation.Proceed();
            CollectIntermediaryFeesAfter();
        }
        private void CollectIntermediaryFeesBefore()
        {
            Console.WriteLine("中介收取服务费------Before！");
        }
        private void CollectIntermediaryFeesAfter()
        {
            Console.WriteLine("中介收取服务费------After！");
        }
    }

}
