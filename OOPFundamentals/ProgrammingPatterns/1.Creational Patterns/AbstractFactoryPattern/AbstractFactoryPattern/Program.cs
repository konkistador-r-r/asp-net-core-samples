using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ниже показано, как вызвать метод Run с различными параметрами: 
            // Абстрактная фабрика № 1 
            CarFactory bmwCar = new BmwFactory();
            Client c1 = new Client(bmwCar);
            c1.Run();
            // Абстрактная фабрика № 2      
            CarFactory audiFactory = new AudiFactory();
            Client c2 = new Client(audiFactory);
            c2.Run();
            Console.Read();

            // Чтобы получше разобраться с этим паттерном, рекомендую написать на его основе 
            // несколько программ, приняв для примера условие, что фабрика связана с какими-то 
            // бизнес-объектами.
        }
    }
}
