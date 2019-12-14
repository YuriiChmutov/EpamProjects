using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EPAM.HomeTask2
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
        Dinozavr dino = null;

        public StoryClass()
        {
            animal = new Animal();
            mouse = new Mouse();
            frog = new Frog();
            rabbit = new Rabbit();
            fox = new Fox();
            wolf = new Wolf();
            bear = new Bear();
            dino = new Dinozavr();
        }

        #region Кусок сказки для животного
        public void partOfStoryForEachAnimal(ref string story, List<Animal> teremok, string listOfAnimals,  Animal animal, Animal animal2)
        {
            if (animal == dino) throw new DinozavrException("Ой, а динозавры то вымерли, прости Гена, иди в другую сказку.");

            int answer = 0;

            story += $"{animal.generateWayToTravelToTeremok()} к теремку {animal.nameOfAnimal} и спросил: \n" +
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
            if (mouse.isAppear)
            {
                story += $" {mouse.generateWayToTravelToTeremok()} к теремку {mouse.nameOfAnimal} и спросил:\n" +
                    $"{mouse.firstPhraseFromAnimal()}\n" +
                    $"Никто не отзывается. Животное подумало и приняло решение {mouse.whatToDo(ref answer)}.\n";

                if (answer != 0) { teremok.Add(mouse); story += $"Теперь теремок не пустой.\n\n"; }
                else story += $"Так и остался теремок пустым.\n\n";
            }
            //------------------------ЛЯГУШОНОК--------------------------------//
            if (frog.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, frog, mouse);
                }
                catch (DinozavrException ex)
                {
                    story += $"Ошибка: " + ex.Message;
                }
            }

            //------------------------ЗАЙКА----------------------------------//

            if (rabbit.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, rabbit, frog);
                }
                catch(DinozavrException ex)
                {
                    story += $"Ошибка: " + ex.Message;
                }
            }

            //------------------------ДИНОЗАВР----------------------------------//

            if (dino.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, dino, rabbit);
                }
                catch (DinozavrException ex)
                {
                    story += $"{dino.generateWayToTravelToTeremok()} к теремку {dino.nameOfAnimal} и спросил:\n" +
                            $"{dino.firstPhraseFromAnimal()}\n\n";
                    story += $"Ошибка: {ex.Message}\n\n";
                }
            }

            //------------------------ЛИСЕНОК----------------------------------//
            if (fox.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, fox, rabbit);
                }
                catch(DinozavrException ex)
                {
                    story += $"Ошибка: " + ex.Message;
                }
            }

            //------------------------ВОЛЧОНОК----------------------------------//
            if (wolf.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal(ref story, teremok, listOfAnimals, wolf, fox);
                }
                catch(DinozavrException ex)
                {
                    story += $"Ошибка: " + ex.Message;
                }
            }

            //------------------------МЕДВЕДЬ----------------------------------//
            if (bear.isAppear)
            {
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
            }
            return story;
        }

        public void ShowStory() //выводим сказку в консоль
        {
            Console.WriteLine(CreateStory());
            //Console.ReadKey();
        }
    }
}

