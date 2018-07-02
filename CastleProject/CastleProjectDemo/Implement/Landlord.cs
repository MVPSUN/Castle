using CastleProjectDemo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleProjectDemo.Implement
{
    public class Landlord : ILandlordible
    {
        public  void RentHouse()
        {
            Console.WriteLine("房东收取租金！");
        }
        public  void Test(string param)
        {
            Console.WriteLine("Test！" + param);
        }
    }
}
