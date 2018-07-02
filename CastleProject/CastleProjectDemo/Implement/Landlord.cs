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
        public virtual void RentHouse()
        {
            Console.WriteLine("房东收取租金！");
        }
        public virtual void Test(string param)
        {
            Console.WriteLine("Test！" + param);
        }
    }
}
