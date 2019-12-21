using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask4
{
    interface IAnimal<T, B>
    {
        T whatToDo(ref int value); // не захочет | захочет жить в теремке
        T generateWayToTravelToTeremok(); // каким способом животное пришло к теремку
        T generatePhrase(); // что скажет животное новому животному (передаю полю)

        B isAppearMethod(); // появится ли животное в сказке (у всех, кроме динозавра, вероятность 100% появиться)

    }
}
