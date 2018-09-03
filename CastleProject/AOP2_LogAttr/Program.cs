using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{
    //这个Demo，演示了如何通过AOP，创建一个日志系统，用于记录方法执行前后的参数、返回值、执行时间

    public class Program
    {
        static void Main(string[] args)
        {
            var container = Initer.Load();

            IShoppingCart cart = container.Resolve<IShoppingCart>();
            cart.Checkout("car");
            Console.WriteLine("-------------------");
            ICalculator svc = container.Resolve<ICalculator>();
            var ss = svc.Add(1,2);
            
            Console.ReadKey();
        }
    }
    #region 业务接口、类
    public interface ICalculator
    {
        int Add(int x, int y);
        int Minus(int x, int y);
    }
    [SafeExec]
    [AopLogAttribute(Timeout = 1000)]
    public class LocalCalculator: ICalculator 
    {
        public int Add(int x, int y)
        {
            Console.WriteLine("LocalCalculator add Method executing");
            return x + y;
        }
        public int Minus(int x, int y)
        {
            return x - y;
        }
    }

    public interface IShoppingCart
    {
        void Checkout(string sthName);
    }
    [SafeExec]
    public class TaobaoShoppingCart : IShoppingCart
    {
        public void Checkout(string sthName)
        {
            Console.WriteLine("Checking "+sthName +" out in taobao shopping cart.");
        }
    }

    #endregion



    public interface A
    {

    }
    public class AA : A
    {
    }

    public class B
    {
        public virtual void bbb() { }
    }
    public class BB : B
    {
    }

    
    public class BBProxy:BB
    {
        public BBProxy(BB _b)
        {
            bb = _b;
        }
        public BB bb { get; set;}
        public override void bbb()
        {
            base.bbb();
        }
    }

}
