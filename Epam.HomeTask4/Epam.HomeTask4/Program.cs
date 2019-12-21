using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask4
{
    class Program
    {
        /*
           - Story class: обобщающие делегаты -> generic events
                          partOfStoryForEachAnimal<T>...
           - IAnimal<T, B>
           - AbstractAnimal<T>
           - В методах животных (что сказать, что сделать есть List<strig>)
        */
        static void Main(string[] args)
        {
            StoryClass story = new StoryClass();
            story.onBegining += story.beginingForEachAnimalMethod;
            story.onWhenTeremokIsNotEmpty += story.TeremokIsNotEmptyMethod;
            story.onWhenTeremokIsEmpty += story.TeremokIsEmptyMethod;
            story.ShowStory();
        }
    }
}
