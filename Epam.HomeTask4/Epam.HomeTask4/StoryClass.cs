using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EPAM.HomeTask4
{
    delegate string stringDelegate();
    delegate void beginingForEachAnimalDelegate<T>(ref string story, T animal) where T: Animal;
    delegate void whenTeremokIsEmptyDelegate<T, K>(ref string story, K answer, List<T> teremok, T animal) where T: Animal;
    delegate void whenTeremokIsNotEmptyDelegate<T, K>(string listOfAnimals, ref string story, K answer, List<T> teremok, T animal, T animal2) where T: Animal;

    class StoryClass //рабочий класс, в который закинут весь функционал
    {
        public stringDelegate drawHash = () => new String('-', 90);

        //public event <НазваниеДелегата> <НазваниеСобытия>;
        public event beginingForEachAnimalDelegate<Animal> onBegining;
        public event whenTeremokIsNotEmptyDelegate<Animal, Int32> onWhenTeremokIsNotEmpty;
        public event whenTeremokIsEmptyDelegate<Animal, Int32> onWhenTeremokIsEmpty;

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
        public void partOfStoryForEachAnimal<T>(ref string story, List<Animal> teremok,
                                            string listOfAnimals,  T animal, T animal2) where T: Animal
        {           
            int answer = 0;

            onBegining(ref story, animal);

            if (animal == dino) throw new DinozavrException("\nError: Ой, а динозавры то вымерли, прости Гена," +
                                                            " иди в другую сказку.\n\n");

            if (teremok.Count != 0)
            { 
                onWhenTeremokIsNotEmpty(listOfAnimals, ref story, answer, teremok, animal, animal2);
            }
            else
            {
                onWhenTeremokIsEmpty(ref story, answer, teremok, animal);
            }
        }
        #endregion


        #region Начало для каждого животного (бежало животное... и спросило...)
        public void beginingForEachAnimalMethod<T>(ref string story, T animal) where T: Animal
        {
            story += $"\n\n{animal.generateWayToTravelToTeremok()} к теремку {animal.nameOfAnimal} и спросил: \n" +
                     $"{animal.firstPhraseFromAnimal()}\n";
        }
        #endregion


        #region Метод, если теремок не пустой
        public void TeremokIsNotEmptyMethod<T>(string listOfAnimals, ref string story, int answer, List<T> teremok, T animal, T animal2) where T: Animal
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
        #endregion


        #region Метод, если теремок пустой
        public void TeremokIsEmptyMethod<T>(ref string story, int answer, List<T> teremok, T animal) where T: Animal
        {
            story += $"Никто не отзывается. Животное подумало и приняло решение {animal.whatToDo(ref answer)}.\n";
            if (answer != 0) { teremok.Add(animal); story += $"Теперь теремок не пустой.\n\n"; }
            else story += $"Так и остался теремок пустым.\n\n";
        }
        #endregion


        #region Кусок сказки для Мышонка
        private void mouseMethod(ref string story, int answer, List<Animal> teremok)
        {
            if (mouse.isAppear)
            {
                story += $" {mouse.generateWayToTravelToTeremok()} к теремку {mouse.nameOfAnimal} и спросил:\n" +
                    $"{mouse.firstPhraseFromAnimal()}\n" +
                    $"Никто не отзывается. Животное подумало и приняло решение {mouse.whatToDo(ref answer)}.\n";

                if (answer != 0) { teremok.Add(mouse); story += $"Теперь теремок не пустой.\n\n"; }
                else story += $"Так и остался теремок пустым.\n\n";
            }
        }
        #endregion


        #region Кусок сказки для Медведя
        private void bearMethod(ref string story, int answer, List<Animal> teremok, string listOfAnimals)
        {
            if (bear.isAppear)
            {
                story += $"\n\n{bear.generateWayToTravelToTeremok()} к теремку {bear.nameOfAnimal} и спросил:\n" +
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
        }
        #endregion

        private string CreateStory() //метод, в котором творится сказка
        {
            string listOfAnimals = null;
            int answer = 0;
            List<Animal> teremok = new List<Animal>(); //коллекция для фиксирования, кто в теремочке живет

            string story = "Стоял в поле теремок.";

            #region МЫШОНОК

            mouseMethod(ref story, answer, teremok);

            #endregion

            story += drawHash();

            #region ЛЯГУШОНОК

            if (frog.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal<Animal>(ref story, teremok, listOfAnimals, frog, mouse);
                }
                catch (DinozavrException ex)
                {
                    story +=  ex.Message;  
                }
            }
            #endregion

            story += drawHash();

            #region ЗАЙКА

            if (rabbit.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal<Animal>(ref story, teremok, listOfAnimals, rabbit, frog);
                }
                catch(DinozavrException ex)
                {
                    story +=  ex.Message;
                    
                }
            }
            #endregion

            story += drawHash();

            #region ДИНОЗАВР

            if (dino.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal<Animal>(ref story, teremok, listOfAnimals, dino, rabbit);
                }
                catch (DinozavrException ex)
                {
                    story += ex.Message;
                }
            }
            #endregion

            story += drawHash();

            #region ЛИСЕНОК

            if (fox.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal<Animal>(ref story, teremok, listOfAnimals, fox, rabbit);
                }
                catch(DinozavrException ex)
                {
                    story += ex.Message;
                    
                }
            }
            #endregion

            story += drawHash();

            #region ВОЛЧОНОК

            if (wolf.isAppear)
            {
                try
                {
                    partOfStoryForEachAnimal<Animal>(ref story, teremok, listOfAnimals, wolf, fox);
                }
                catch(DinozavrException ex)
                {
                    story += ex.Message;
                    
                }
            }
            #endregion

            story += drawHash();

            #region МЕДВЕДЬ 

            bearMethod(ref story, answer, teremok, listOfAnimals);
            
            #endregion

            return story;
        }

        public void ShowStory()
        {
           
            Console.WriteLine(CreateStory()); 
        }
        
    }
}

//if (animal.generateWayToTravelToTeremok() == "Подъехал на такси" ||
//    animal.generateWayToTravelToTeremok() == "Прилетел частным авиорейсом")
//{

//    throw new WayOfTavelException("Стоп! Ошибка! Откуда у животного деньги на проезд?" +
//        " Животное пришло к теремку пешком, окей? Тогда продолжаем сказку...\n");

//}