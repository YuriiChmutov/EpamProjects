using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst.Models;

namespace EpamPractice.Logic
{
    public static class Logic
    {
        public static string print200Symbols(string content, int lenght)
        {
            //content = content.ToString();
            char[] contentCharArray = content.ToCharArray();//пишу в чар массив контент
            int countOfSymbols = lenght;//200 = 200
            if(contentCharArray.Length < lenght)//199 < 200
            {
                countOfSymbols = contentCharArray.Length / 2;
            }
            char[] printContent = new char[countOfSymbols];//что вывожу на превъюхе
            for (int i = 0; i < countOfSymbols; i++)
            {
                printContent[i] += contentCharArray[i];
            }
            string str = new string(printContent);
            str += "...";
            return str;
        }

        public static string calculateProcent(ref double res ,int amount, IEnumerable<Vote> list)
        {
            int amountOfVotesAll = 0;

            foreach (var item in list)
            {
                amountOfVotesAll += item.Amount;
            }

            res = ((double)amount / (double)amountOfVotesAll) * 100;
            res = Math.Round(res, 2);
            double r = res;
            r = (int)r;
            string a = r.ToString();
            return a += "%";
        }

        public static double calculateAvg(int a, int b, int c, int all)
        {
            int res = (a + b * 2 + c * 3);
            return (double)((double)res / (double)all);
        }

        public static double calculateRoundAvg(int a, int b, int c, int all)
        {
            int res = (a + b * 2 + c * 3);
            double returnRoundAvg = (double)((double)res / (double)all);
            return Math.Round(returnRoundAvg, 2);
        }

        public static int width(int a, int b, int c, int all)
        {
            
            return (int)((calculateAvg(a, b, c, all) / 3) * 100);
        }
    }
}