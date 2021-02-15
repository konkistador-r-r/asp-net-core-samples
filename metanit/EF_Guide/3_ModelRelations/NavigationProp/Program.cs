using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NavigationProp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                //var users = db.Users.ToList(); // No data in references
                var users = db.Users.Include(u => u.Company).ToList(); // Include references
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id} - {user.Name} - {user.CompanyName} - {user.Company?.Name}");
                }
            }

            TestCascadeDelete();

            Console.ReadKey();
        }

        static void TestCascadeDelete() {
            using (ApplicationContext db = new ApplicationContext())
            {
                // добавляем начальные данные
                Company abb = db.Companies.Where(c => c.Name == "ABB").FirstOrDefault();
                if (abb == null)
                {
                    abb = new Company { Name = "ABB" };
                    db.Companies.Add(abb);
                }
                Company dell = db.Companies.Where(c => c.Name == "DELL").FirstOrDefault();
                if (dell == null)
                {
                    dell = new Company { Name = "DELL" };
                    db.Companies.Add(dell);
                }                
                db.SaveChanges();
                
                User tom = db.Users.Where(c => c.Name == "Pitt").FirstOrDefault();
                if (tom == null)
                {
                    tom = new User { Name = "Pitt", Company = abb };
                    db.Users.Add(tom);
                }
                User bob = db.Users.Where(c => c.Name == "Bull").FirstOrDefault();
                if (bob == null)
                {
                    bob = new User { Name = "Bull", Company = abb };
                    db.Users.Add(bob);
                }
                User alice = db.Users.Where(c => c.Name == "John").FirstOrDefault();
                if (alice == null)
                {
                    alice = new User { Name = "John", Company = dell };
                    db.Users.Add(alice);
                }
                User kate = db.Users.Where(c => c.Name == "Weak").FirstOrDefault();
                if (kate == null)
                {
                    kate = new User { Name = "Weak", Company = dell };
                    db.Users.Add(kate);
                }
                User userNo = db.Users.Where(c => c.Name == "No company user").FirstOrDefault();
                if (userNo == null)
                {
                    userNo = new User { Name = "No company user" };
                    db.Users.Add(userNo);
                }
                db.SaveChanges();


                // получаем пользователей
                var users = db.Users.ToList();
                foreach (var user in users) Console.WriteLine($"{user.Name}");

                // Удаляем первую компанию
                var comp = db.Companies.Where(c=>c.Name == "ABB").FirstOrDefault();
                db.Companies.Remove(comp);
                db.SaveChanges();
                Console.WriteLine("\nСписок пользователей после удаления компании");
                // снова получаем пользователей
                users = db.Users.ToList();
                foreach (var user in users) Console.WriteLine($"{user.Name}");
            }
        }
    }
}
