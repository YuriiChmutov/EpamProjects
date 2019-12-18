using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask3
{
    delegate int randomDelegate(int i);
    static class GetRandom
    {
        static Random random = new Random();

        public static randomDelegate returnRandom = (length) =>
        random.Next(DateTime.Now.Millisecond) % length;  
    }
}
