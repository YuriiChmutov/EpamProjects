﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EPAM.HomeTusk1.FairyTale
{
    

    class Animal // базовый класс для персонажей сказки
    {
       
       public string nameOfAnimal { get; set; }
       public string phraseToSpeak { get; set; }

       
        public string firstPhraseFromAnimal()
        {
            return "- Терем-теремок! Кто в тереме живет?";
        }

        public virtual string whatToDo(ref int value) //виртуальный метод, для того, чтобы каждое животное делало свои действия
        {  // ref (извлекаю ответ песонажа в виде индекса) для того, чтобы в истории можно было работать с выбором животного
            return "О, давай, отличная идея! И стали они дружно все жить."; // 0 - будет обычно вариантом, когда животное не захотело жить в теремочке
        }

        public virtual string generateWayToTravelToTeremok() //способ передвижения животного (рандомный)
        {
            return new string("What have I do?".ToCharArray());
        }

        public virtual string generatePhrase() // фраза, которую говорит животное, которое уже живет в теремке
        {                               //присваиваю ее полю через конструктор в классе наследнике
            return new String("What can I say?".ToCharArray());
        }

       //public string generateWayOfSpeaking

        public override string ToString() => $"- Я {nameOfAnimal}";

        static void changeConsoleColorMethod()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void normalColorMethod()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }


        
    }

   
}
