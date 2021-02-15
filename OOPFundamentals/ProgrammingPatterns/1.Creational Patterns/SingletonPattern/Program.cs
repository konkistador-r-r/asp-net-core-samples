using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Конструктор объявлен, как protected,
            // так что нельзя использовать оператор new
            Earth earth1 = Earth.Instance();
            Earth earth2 = Earth.Instance();

            if (earth1 == earth2)
            {
                Console.WriteLine("Objects are the same instance of Earth type");
            }

            earth1.Hello();
            

            // Использование обобщенного шаблона позволяет не реализовывать паттерн Singleton у объектов использующих его
            ASingleton.Instance.Hello();
            //var asingle = new ASingleton(); // is inaccessible due to its protection level

            Moon.Instance.Hello();
            //var moon = new Moon(); // is inaccessible due to its protection level


            Console.Read();
        }
    }
}
