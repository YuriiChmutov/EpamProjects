using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask2
{
    abstract class AbstractAnimal
    {
        public string nameOfAnimal { get; set; }
        public string phraseToSpeak { get; set; }
        public bool isAppear { get; set; }

        public override string ToString() => $"- Я {nameOfAnimal}";
        public abstract string firstPhraseFromAnimal(); //abstract меняю на virtual и не создаю метод в Animal.cs
        //{                                             
        //    return "- Терем-теремок! Кто в тереме живет?";
        //}

}
}
