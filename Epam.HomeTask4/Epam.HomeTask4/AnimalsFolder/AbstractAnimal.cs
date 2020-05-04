using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask4
{
    abstract class AbstractAnimal<T, B> 
    {
        public T nameOfAnimal { get; set; }
        public T phraseToSpeak { get; set; }
        public B isAppear { get; set; }

        public override string ToString() => $"- Я {nameOfAnimal}";
        public abstract string firstPhraseFromAnimal(); //abstract меняю на virtual и не создаю метод в Animal.cs
        //{                                             
        //    return "- Терем-теремок! Кто в тереме живет?";
        //}

}
}
