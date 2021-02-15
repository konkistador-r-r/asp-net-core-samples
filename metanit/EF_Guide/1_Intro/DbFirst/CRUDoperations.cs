using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbFirst
{
    // При изменении объекта Entity Framework сам отслеживает все изменения, и когда вызывается метод SaveChanges(), 
    // будет сформировано SQL-выражение UPDATE для данного объекта, которое обновит объект в базе данных.
    // Но надо отметить, что в данном случае действие контекста данных ограничивается пределами конструкции using.
    public static class CRUDoperations
    {
        public static void AddData() {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };
                User user3 = new User { Name = "Stas", Age = 30 };

                // Добавление по одному
                db.Users.Add(user1);
                // добавить сразу несколько объектов
                db.Users.AddRange(user2, user3);
                db.SaveChanges();
            }
        }

        public static void ReadAllData() {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }

        public static void UpdateData() {
            // Редактирование
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    //обновляем объект
                    //db.Users.Update(user);
                    // db.Users.UpdateRange(user1, user2);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteData() {
            // Удаление
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    //удаляем объект
                    db.Users.Remove(user);
                    // db.Users.RemoveRange(user1, user2);
                    db.SaveChanges();
                }
            }
        }

        public static void ClearTable() {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.RemoveRange(db.Users);
                db.SaveChanges();
            }
        }

        #region Distributed Operations
        public static User SelectFirstOrDefault()
        {
            using (var db = new ApplicationContext())
            {
                return db.Users.FirstOrDefault();
            }
        }

        public static User SelectUser(int userId) {
            using (var db = new ApplicationContext())
            {
                return db.Users.Find(userId);
            }
        }

        public static User ChangeUser(User user) {
            // Редактирование
            if (user != null)
            {
                user.Name = "Sam";
                user.Age = 33;
            }

            return user;
        }

        public static void UpdateUser(User user)
        {
            using (var db = new ApplicationContext())
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }
        #endregion

        #region What fields got updated in SQL query
        public static void UpdateDataLog()
        {
            // Редактирование
            using (ApplicationContext db = new ApplicationContext())
            {
                // С помощью метода GetService<ILoggerFactory>() получаем сервис ILoggerFactory, которому через метод AddProvider() передаем наш провайдер MyLoggerProvider.
                // установка логгирования локально
                db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                // получаем первый объект
                User user1 = db.Users.FirstOrDefault();
                // BAD all records selected!!!
                // User user2 = db.Users.AsEnumerable().LastOrDefault();
                User user2 = db.Users.OrderByDescending(u=>u.Id).FirstOrDefault();
                if (user1 != null && user2 != null)
                {
                    user1.Name = "Bob";
                    user2.Age = 44;
                    //user.Age = 44;
                    //обновляем объект
                    //db.Users.Update(user);
                    // db.Users.UpdateRange(user1, user2);
                    // 2 UPDATE queries generated
                    db.SaveChanges();
                }
            }
        }
        #endregion
    }
}
