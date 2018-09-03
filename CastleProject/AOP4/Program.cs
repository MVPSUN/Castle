using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace AOP4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = Initer.Load();

            SingleClass sc = container.Resolve<SingleClass>();
            sc.cc();

            IDependency svc = container.Resolve<IDependency>();
            svc.calc("123");
            
            Console.ReadKey();
        }
        
    }
    #region 业务接口、类

    public interface IDependency
    {
        void calc(string name);
    }
    public class TestClass:IDependency
    {
        public void calc(string name)
        {
            Console.WriteLine("CC:"+name);
        }
    }

    public class SingleClass
    {
        //要想实现方法前后执行切面，必须是virtual才行
        public virtual void cc()
        {
            Console.WriteLine("CCCC");
        }
    }
    #endregion
}
