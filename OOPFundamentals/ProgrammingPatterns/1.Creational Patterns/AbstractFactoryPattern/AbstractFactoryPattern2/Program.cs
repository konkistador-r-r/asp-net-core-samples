using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbstractFactoryPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dev = FactoryMethodPattern.Developer.Create(FactoryMethodPattern.DeveloperType.Panel, "123");
            //var house = dev.Create();

            // Simple Factory - when a method returns one of several possible classes that share a common super class.
            // Choosing class at runtime
            //SimpleFactory();

            AbstractFactory();

            Console.ReadLine();
        }

        public static void SimpleFactory() {
            // Create the factory object
            var shipFactory = new SimpleFactory.EnemyShipFactory();

            // Enemy ship object
            SimpleFactory.EnemyShip theEnemy = null;

            Console.WriteLine("What type of ship? (U / R / B)");

            var userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput))
            {
                String typeOfShip = userInput;
                theEnemy = shipFactory.makeEnemyShip(typeOfShip);

                if (theEnemy != null)
                {
                    Console.WriteLine(theEnemy);
                }
            }
            else Console.WriteLine("Please enter U, R or B next time");
        }

        public static void AbstractFactory() {
            // EnemyShipBuilding handles orders for new EnemyShips
            // You send it a code using the orderTheShip method &
            // it sends the order to the right factory for creation

            var MakeUFOs = new AbstractFactory.UFOEnemyShipBuilder();

            var theGrunt = MakeUFOs.orderTheShip("UFO");
            Console.WriteLine(theGrunt + "\n");

            var theBoss = MakeUFOs.orderTheShip("UFO BOSS");
            Console.WriteLine(theBoss + "\n");
        }
    }
}
