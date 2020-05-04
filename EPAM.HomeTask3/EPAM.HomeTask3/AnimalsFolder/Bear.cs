using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask3
{
    class Bear: Animal
    {
        public Bear()
        {
            nameOfAnimal = "медведь";
            isAppear = isAppearMethod();
        }

        public override string generateWayToTravelToTeremok()
        {
            List<string> ways = new List<string>()
            {
                "Прибежал", "Прискакал", "Прилетел частным авиорейсом",
                "Подъехал на такси", "Пришел прогулочным шагом", "Подкрался"
            };
            
            return ways[GetRandom.returnRandom(ways.Count)];
        }
    }
}
