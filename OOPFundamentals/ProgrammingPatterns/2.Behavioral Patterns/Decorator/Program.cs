using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new CheesePizza(new TomatoPizza(pizza1)); // итальянская пицца с томатами
            
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());
            Console.WriteLine("Ингридиенты: {0}", pizza1.GetIngridients().Aggregate((s,p)=> string.Concat(s, ", ", p)));



            // Create video
            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            borrowvideo.Display();

            GunSample();

            Console.WriteLine("Agile Book Decorator Sample");
            AgileBookSamples.Modem.ModemDecoratorTest.Test();
            Console.WriteLine("");

            Console.ReadLine();
        }

        public static void GunSample() {
            // Decorator - Add responsibilities/functionality to objects dynamically (at runtime)
            // Характеристики стрельбы из M16 зависят от использования Приклада, Глушителя, Лазерного Прицела
            //AutomaticGun gun = new ApplyButt(new ApplySilencer(new ApplyLaserSight(new M16()))); // or in different order
            //gun.Fire(); // result will be different

            Console.WriteLine("\r\nAutomaticGun sample");
            AutomaticGun gun = new M16();
            gun.Fire();
            Console.WriteLine("\r\n");

            Console.WriteLine("Choose gun parts to apply (123) 1 - Laser Sight; 2 - Silencer 3 - Butt");
            var userInput = Console.ReadLine();
            foreach (Char l in userInput)
            {
                switch (l)
                {
                    case '1':
                        gun = new ApplyLaserSight(gun);
                        break;
                    case '2':
                        gun = new ApplySilencer(gun);
                        break;
                    case '3':
                        gun = new ApplyButt(gun);
                        break;
                    default:
                        break;
                }
            }
            
            gun.Fire();
            Console.WriteLine("\r\n");
            Console.WriteLine(gun.GetGunDescription());
        }
    }

    
}
