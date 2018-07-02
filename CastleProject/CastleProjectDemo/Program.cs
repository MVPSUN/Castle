using Castle.DynamicProxy;
using CastleProjectDemo.Castle;
using CastleProjectDemo.Implement;
using CastleProjectDemo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyLandlord = CreateLandlordProxy();
            proxyLandlord.RentHouse();
            proxyLandlord.Test("代理参数");
        }
        private static ILandlordible CreateLandlordProxy()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            //Landlord landlord = proxyGenerator.CreateClassProxy<Landlord>(new IntermediaryIntercetor());// 类代理:虚方法触发代理
            return proxyGenerator.CreateInterfaceProxyWithTarget<ILandlordible>(new Landlord(), new IntermediaryIntercetor());// 接口代理： 接口内的方法触发代理
        }
    }
}
