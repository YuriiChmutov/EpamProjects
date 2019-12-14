using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask2
{
    static class GetRandom
    {
        static Random random = new Random();
        public static int returnRandom(int length)//метод возвращает независимо случайные числа
        {                                         //length - размер списка вариантов действий
            return random.Next(DateTime.Now.Millisecond) % length;
            //return DateTime.Now.Millisecond % length;
        }
    }
}
