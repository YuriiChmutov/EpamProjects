using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EPAM.HomeTusk1.FairyTale
{
    class StoryClass //рабочий класс, в который закинут весь функционал
    {
        Random random = new Random();

        Animal animal = null;
        Mouse mouse = null;
        Frog frog = null;
        Rabbit rabbit = null;
        Fox fox = null;
        Wolf wolf = null;
        Bear bear = null;

        public StoryClass()
        {
            animal = new Animal();
            mouse = new Mouse();
            frog = new Frog();
            rabbit = new Rabbit();
            fox = new Fox();
            wolf = new Wolf();
            bear = new Bear(); 
        }

        #region Кусок сказки для животного
        public void partOfStoryForEachAnimal(ref string story, List<Animal> teremok, string listOfAnimals,  Animal animal, Animal animal2)
        {
            int answer = 0;
            story += $"{animal.generateWayToTravelToTeremok()} {animal.nameOfAnimal} и спросил: \n" +
                $"{animal.firstPhraseFromAnimal()}\n";

            if (teremok.Count != 0)
            {
                listOfAnimals = "";
                story += $"- Я, ";
                foreach (var item in teremok)
                {
                    story += $" {item.nameOfAnimal}, ";
                    listOfAnimals += $"{item.nameOfAnimal} ";
                }
                story += $"а ты кто?";
                story += $"\n{animal.ToString()}.";
                story += $"\n- {animal2.phraseToSpeak}"; //////////
                story += $"\nНе отчаилось животное, услышав такую фразу, и приняло свое независимо - индивидуальное решение" +
                    $" {animal.whatToDo(ref answer)}.\n";
                if (answer != 0) { teremok.Add(animal); story += $"Теперь живут они вместе.\n\n"; }
                else
                {
                    story += $"Так и остался {listOfAnimals} жить без {animal.nameOfAnimal}.\n\n";
                }

            }
            else
            {
                story += $"Никто не отзывается. Животное подумало и приняло решение {animal.whatToDo(ref answer)}.\n";
                if (answer != 0) { teremok.Add(animal); story += $"Теперь теремок не пустой.\n\n"; }
                else story += $"Так и остался теремок пустым.\n\n";
            }
        }
        #endregion

        private string CreateStory() //метод, в котором творится сказка
        {
            string listOfAnimals = null;
            int answer = 0;
            List<Animal> teremok = new List<Animal>(); //коллекция для фиксирования, кто в теремочке живет

            string story = "Стоял в поле теремок.";

            //------------------------МЫШОНОК--------------------------------//

            story += $" {mouse.generateWayToTravelToTeremok()} {mouse.nameOfAnimal} и спросил:\n" +
                $"{mouse.firstPhraseFromAnimal()}\n" +
                $"Никто не отзывается. Животное подумало и приняло решение {mouse.whatToDo(ref answer)}.\n";

            if (answer != 0) { teremok.Add(mouse); story += $"Теперь теремок не пустой.\n\n"; }
            else story += $"Так и остался теремок пустым.\n\n";

            //------------------------ЛЯГУШОНОК--------------------------------//

            partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, frog, mouse);

            //------------------------ЗАЙКА----------------------------------//

            partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, rabbit, frog);

            //------------------------ЛИСЕНОК----------------------------------//

            partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, fox, rabbit);

            //------------------------ВОЛЧОНОК----------------------------------//

            partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, wolf, fox);


            //------------------------МЕДВЕДЬ----------------------------------//

            story += $"{bear.generateWayToTravelToTeremok()} {bear.nameOfAnimal} и спросил:\n" +
                $"{animal.firstPhraseFromAnimal()}\n";
            if (teremok.Count != 0)
            {
                listOfAnimals = "";
                story += $"- Я, ";
                foreach (var item in teremok)
                {
                    story += $" {item.nameOfAnimal}, ";
                    listOfAnimals += $"{item.nameOfAnimal} ";
                }
                story += $"а ты кто?";
                story += $"\n{bear.ToString()}, всех вас давиш. Лягу на теремок - всех раздавлю!\n" +
                    $"Испугались они, да все из терема прочь!\nА медведь ударил лапой по терему и разбил его.";
            }
            else
            {
                story += $"Никто не отзывается. Медведь ударил лапой по терему и разбил его.\n";   
            }
            return story;
        }

        public void ShowStory() //выводим сказку в консоль
        {
            Console.WriteLine(CreateStory()); 
        }
    }
}

