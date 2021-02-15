using System;
using System.Linq;

namespace GeneratePrimaryKeyValue
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //User user = new User { Name = "Tom" };
                //Console.WriteLine($"Id перед добавлением в контекст {user.Id}");    // Id = 0
                //db.Users.Add(user);
                //db.SaveChanges();
                //Console.WriteLine($"Id после добавления в базу данных {user.Id}");  // Id = 1

                //db.Users.Add(new User { Id = 1, Name = "Tom" });
                //db.Users.Add(new User { Id = 2, Name = "Alice" });
                //db.SaveChanges();

                User user1 = new User() { FirstName = "Tom", LastName = "Henks" };
                Console.WriteLine($"Age: {user1.Age}"); // 0

                db.Users.Add(user1);
                db.SaveChanges();

                Console.WriteLine($"Age: {user1.Age}"); // 18

                user1 = db.Users.Where(u => u.Name.Contains("Tom Henks")).First();
                user1.Age = 0;
                db.SaveChanges();

                Console.WriteLine($"Age: {user1.Age}"); // ?

                var users = db.Users.ToList();
                foreach (var user in users)
                    Console.WriteLine($"{user.Id} - {user.Name} - {user.Age}");
            }
            Console.ReadKey();
        }
    }
}
