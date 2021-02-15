using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * The template method design pattern is intended to outline the basic structure or “skeleton” of an algorithm, 
 * without explicitly defining (or advertising) the logic of each step within the overall structure to the client. 
 * This pattern is ideal for complex algorithms that must be shared and executed by multiple classes, 
 * where each class must define their own specific implementation.
 */

namespace TemplateMethodPattern
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("THE OFFICE");
            var theOffice = new NBCShow("The Office", DayOfWeek.Thursday, 21);
            theOffice.Broadcast();

            Console.WriteLine("COMPUTERPHILE");
            var computerphile = new YouTubeShow("Computerphile");
            computerphile.Broadcast();

            Console.WriteLine("STRANGER THINGS");
            var strangerThings = new NetflixShow("Stranger Things");
            strangerThings.Broadcast();

            Console.ReadLine();
        }
    }
}
