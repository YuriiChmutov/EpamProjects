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
        public string firstPhraseFromAnimal() //в качестве демонстрации работы абстрактного класса:
        {                                     // я могу прописать функционал метода, а не только сигнатуру
            return "- Терем-теремок! Кто в тереме живет?";
        }

    }
}
