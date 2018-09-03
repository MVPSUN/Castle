using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = Initer.Load();
            IDependency svc = container.Resolve<IDependency>();
            svc.calc("123");
            Console.ReadKey();
        }
    }
    #region 业务接口、类
    [TransactionCallHandler(Timeout = 1000)]
    public interface IDependency
    {
        int calc(string name);

    }
    public class TestClass : IDependency
    {
        public int calc(string name)
        {
            int a = 10;
            int b = 9;
            int c = a + b;
            Console.WriteLine(c);
            return c;
        }
        public virtual int aaa(string name)
        {
            return 666;
        }
    }
    #endregion
}
