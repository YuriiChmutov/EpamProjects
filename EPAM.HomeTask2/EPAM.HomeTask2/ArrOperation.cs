using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask2
{
    delegate int[] arrDelegate(int[] array);
    class ArrOperation
    {
         int[] array = { 2, -4, 10, 5, -6, 9 };

        static void WriteArray(int [] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(i + " ");
            }
        }
        
        static void IncSort(int [] array)
        {
            var arr = from i in array orderby i select i; 
        }


        static void DecSort(int [] array)
        {
            var arr = from i in array orderby i descending select i;
        }


        static void ChetArray(int [] array)
        {


            var arr = from i in array where i % 2 == 0 select i;
        }
    }
}
