using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask3
{
    class Program
    {
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
