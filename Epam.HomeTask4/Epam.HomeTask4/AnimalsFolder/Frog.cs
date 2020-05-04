using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask4
{
    class Frog: Animal
    {
        
        public Frog()
        {
            nameOfAnimal = "лягушонок-квакушонок";
            phraseToSpeak = generatePhrase();
            isAppear = isAppearMethod();
        }

        public override string generatePhrase() // фраза, которую говорит животное, которое уже живет в теремке
        {                                       //присваиваю ее полю через конструктор в классе наследнике
            List<string> phrases = new List<string>()
            {
                "Давай жить вместе!",
                "Уходи, ты меня пугаешь!",
                "Смысл жить вместе? В конце сказки все равно медведь всё разрушит, это естественный отбор."
            };
            
            return phrases[GetRandom.returnRandom(phrases.Count)];
        }


        public override string whatToDo(ref int value)
        {
            List<string> deals = new List<string>()
            {
                "вернуться туда, откуда оно взялось, ибо так безопаснее", "заиметь крышу над своей лягушачьей головой"
            };
            
            value = GetRandom.returnRandom(deals.Count);
            //Console.WriteLine(value);
            return deals[value];
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
