using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTusk1.FairyTale
{
    class Rabbit: Animal
    {
        public Rabbit()
        {
            nameOfAnimal = "зайка-поплутайка";
            phraseToSpeak = generatePhrase();
        }


        public override string generatePhrase() // фраза, которую говорит животное, которое уже живет в теремке
        {                                        //присваиваю ее полю через конструктор в классе наследнике
            List<string> phrases = new List<string>()
            {
                "давай жить вместе!",
                "уходи, ты меня пугаешь!",
                "смысл жить вместе? В конце сказки все равно медведь всё разрушит, это естественный отбор."
            };
            
            return phrases[returnRandom(phrases.Count)];
        }

        public override string whatToDo(ref int value)
        {
            List<string> deals = new List<string>()
            {
                "съездить в отпуск в соседний лес, и не трогать этот теремок", "обзавестись домом"
            };
            value = returnRandom(deals.Count);
            
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
            
            return ways[returnRandom(ways.Count)];
        }
    }
}
