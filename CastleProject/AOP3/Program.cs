using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Initer.Load();

            var c = container.Resolve<IDependency>();
            c.A();
            //BizClass1 c1 = container.Resolve<BizClass1>(); 
            //c1.B();
            Console.ReadKey();
        }
    }

    public interface IDependency
    {
        [SafeExecute]
        [PerformanceLog]
        int A();
    }

    [UseInterceptor]
    public class BizClass: IDependency
    {
        [SafeExecute]
        [PerformanceLog]
        public int A()
        {
            Console.WriteLine("Biz.A()");
            return 10;
        }
    }

    //public class BizClass1: IDependency
    //{
    //    public int A()
    //    {
    //        return 100;
    //    }

    //    public int B()
    //    {
    //        return 20;
    //    }
    //}
}
