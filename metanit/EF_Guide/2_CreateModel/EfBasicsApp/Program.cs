using System;
using System.Linq;

namespace EfBasicsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                var c = new Company { Name = "CocaCola" };
                db.Add(c);

                var p1 = new Product { Name = "Chocolate", Price = 1, Manufacturer = c };
                var p2 = new Product { Name = "Water", Price = 2, Manufacturer = c };
                var p3 = new Product { Name = "Chair", Price = 3 };
                db.AddRange(p1, p2, p3);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var list = db.Products.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Product i in list)
                {
                    Console.WriteLine($"{i.Id} - {i.Name} - {i.Manufacturer?.Name}");
                }
            }
            Console.Read();
        }
    }
}
