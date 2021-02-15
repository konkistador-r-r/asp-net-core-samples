using System;
using System.Linq;

namespace ModelConfigClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (var user in users)
                    Console.WriteLine($"{user.Id} - {user.Name} - {user.Age}");
            }
            Console.ReadKey();
        }
    }
}
