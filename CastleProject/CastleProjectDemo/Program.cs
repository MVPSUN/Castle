using Castle.DynamicProxy;
using CastleProjectDemo.Castle;
using CastleProjectDemo.Implement;
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
            Landlord proxyLandlord = CreateLandlordProxy();
            proxyLandlord.RentHouse();
            proxyLandlord.Test("代理参数");
        }
        private static Landlord CreateLandlordProxy()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            Landlord proyLandlord = proxyGenerator.CreateClassProxy<Landlord>(new IntermediaryIntercetor());
            return proyLandlord;
        }
    }
}
