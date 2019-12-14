using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask2
{
    interface IAnimal
    {
        string whatToDo(ref int value); // не захочет | захочет жить в теремке
        string generateWayToTravelToTeremok(); // каким способом животное пришло к теремку
        string generatePhrase(); // что скажет животное новому животному (передаю полю)

        bool isAppearMethod(); // появится ли животное в сказке (у всех, кроме динозавра, вероятность 100% появиться)

    }
}
