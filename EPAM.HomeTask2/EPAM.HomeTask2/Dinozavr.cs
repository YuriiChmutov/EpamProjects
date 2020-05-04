using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask2
{
    class Dinozavr: Animal
    {
        public Dinozavr()
        {
            nameOfAnimal = "Динозавррр Гена";
            phraseToSpeak = "Р - р - р - р - р";
            isAppear = isAppearMethod();
        }

        public override string firstPhraseFromAnimal()
        {
            return "- Те-Р-Р-ем - те-Р-Р-емок! Кто в те-Р-Р-еме живет?";
        }

        public override bool isAppearMethod()
        {
            int value = GetRandom.returnRandom(2);
            if (value == 1) return true;

            return false;            
        }

        public override string generateWayToTravelToTeremok()
        {
            List<string> ways = new List<string>()
            {

                "Пришел прогулочным шагом", "Подкрался",
                "Прибежал", "Прискакал", "Подполз"
            };

            return ways[GetRandom.returnRandom(ways.Count)];
        }
    }
}
