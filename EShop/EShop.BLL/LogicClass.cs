using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL
{
    public static class LogicClass
    {
        public static string print200Symbols(string content, int lenght)
        {
            if (content != null)
            {
                //content = content.ToString();
                char[] contentCharArray = content.ToCharArray();//пишу в чар массив контент
                int countOfSymbols = lenght;//200 = 200
                if (contentCharArray.Length < lenght)//199 < 200
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
            else return "...";
        }
    }
}
