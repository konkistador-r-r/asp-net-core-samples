using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var auto1 = new AutoConrete1(1, 15, 8);
            var auto2 = ObjectCopier.Clone<Auto>(auto1);//var auto2 = auto1.Clone();
            auto1.MaxSpeed = 100;

            Console.WriteLine("-- Игрушки --");
            Console.WriteLine("-- auto1 --");
            foreach (FieldInfo field in  typeof(Auto).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(field.Name + " " + field.GetValue(auto1));
            }

            Console.WriteLine("-- auto2 --");
            foreach (FieldInfo field in typeof(Auto).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(field.Name + " " + field.GetValue(auto2));
            }

            Console.WriteLine("-- Figures --");
            IFigure figure = new Rectangle(20, 20, 30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(50,50, 30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.Read();
        }
    }
}
