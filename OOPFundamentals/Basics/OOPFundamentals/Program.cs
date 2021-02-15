using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using OOPFundamentals.Classes;
using OOPFundamentals.Polimorphizm;
using OOPFundamentals.Patterns;


namespace OOPFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //var mother = new Mother("Мария", 30, Human.Sex.Femail);
            //mother.Go();
            //mother.Work();
            //mother.Busy = true;

            //var father = new Father("Александр", 35, Human.Sex.Mail);
            //father.Go();
            //father.Work();

            //var daughter = new Daughter("Анна", 10, Human.Sex.Femail);
            //// доча походила устала
            //daughter.Go();
            //// устала и стала голодной на 20 поинтов
            //daughter.BecomeHungry(20);
            //Console.WriteLine(daughter.GetHealth().ToString());
            //// выбрала кто ее покормит, если не занят);
            //if (!father.Busy)
            //    father.StartFeed += daughter.Eat; // Events
            //// папа нашел время и покормил
            //father.Feed();
            //Console.WriteLine(daughter.GetHealth().ToString());

            var singleton = Singleton.GetSingleton;
            Console.WriteLine(singleton._name);
            singleton._name = "Changed field of singleton class";
            Console.WriteLine(singleton._name);
             //Cannont access to private constructor
             //var singleton2 = new Singleton();

            Console.ReadLine();
        }
    }
}
