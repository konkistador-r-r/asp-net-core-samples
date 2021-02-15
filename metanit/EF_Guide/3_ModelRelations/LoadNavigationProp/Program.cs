using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadNavigationProp
{
    class Program
    {
        static void Main(string[] args)
        {            
            using (ApplicationContext db = new ApplicationContext())
            {
                // Eager loading (жадная загрузка) - позволяет загружать связанные данные с помощью метода Include(), в который передается навигационное свойство. (LEFT JOIN)
                // чтобы пойти дальше по цепочке навигационных свойств, надо использовать метод ThenInclude()
                ////SimpleSample_EagerLoading(db);
                //AdvancedSample_EagerLoading(db);

                // Explicit loading предполагает явную загрузку данных с помощью метода Load
                //LoadUsersToApplicationContext_ExplicitLoading(db);

                // Lazy loading предполагает неявную автоматическую загрузку связанных данных. Однако здесь есть ряд условий:
                // Прежде всего в методе OnConfiguring у объекта DbContextOptionsBuilder вызывается метод UseLazyLoadingProxies(), который делает доступной ленивую загрузку.
                // Все навигационные свойства должны быть определены как виртуальные (то есть с модификатором virtual), при этом сами классы моделей должны быть открыты для наследования
                // Используем lazy loading. Прежде всего добавим в проект через nuget пакет Microsoft.EntityFrameworkCore.Proxies
                // System.InvalidOperationException: 'Navigation property 'Country' on entity type 'Company' is not virtual. 
                // UseLazyLoadingProxies requires all entity types to be public, unsealed, have virtual navigation properties, and have a public or protected constructor.'
                // Однако при использовании lazy loading следует учитывать ряд моментов. 
                // В частности, при загрузке объектов из бд, загружаются также все связанные с ними данные. 
                // Для определения загружены ли данные, EF Core использует специальный флаг, который устанавливается после загрузки. 
                // И после этого данные не перезагружаются, даже если базе данных произошли какие-нибудь изменения (например, другой пользователь изменил данные).
                // Lazy loading использует синхронную загрузку.Поэтому, если возникнет необходимость выполнять асинхронную загрузку объектов, 
                // то для этого лучше применять eager или explicit loading.
                LazyLoadedProps(db);
            }
            Console.Read();
        }

        //#region EagerLoading
        //private static void SimpleSample_EagerLoading(ApplicationContext db) {
        //    // добавляем начальные данные
        //    InsertSimpleTestData(db);            
        //    GetUserCompaniesInfo_EagerLoading(db);
        //    Console.WriteLine("");
        //    GetCompanyUsersInfo_EagerLoading(db);
        //}
        //private static void InsertSimpleTestData(ApplicationContext db) {
        //    // добавляем начальные данные
        //    Company microsoft = new Company { Name = "Microsoft" };
        //    Company google = new Company { Name = "Google" };
        //    db.Companies.AddRange(microsoft, google);
        //    db.SaveChanges();
        //    User tom = new User { Name = "Tom", Company = microsoft };
        //    User bob = new User { Name = "Bob", Company = google };
        //    User alice = new User { Name = "Alice", Company = microsoft };
        //    User kate = new User { Name = "Kate", Company = google };
        //    db.Users.AddRange(tom, bob, alice, kate);
        //    db.SaveChanges();
        //}
        //private static void GetUserCompaniesInfo_EagerLoading(ApplicationContext db) {
        //    // получаем данные
        //    var users = db.Users
        //        .Include(u => u.Company)  // добавляем данные по компаниям
        //        .ToList();

        //    // вывод данных
        //    foreach (var user in users)
        //        Console.WriteLine($"{user.Name} - {user.Company?.Name}");
        //}
        //private static void GetCompanyUsersInfo_EagerLoading(ApplicationContext db)
        //{
        //    // получаем данные
        //    var companies = db.Companies
        //            .Include(c => c.Users)  // добавляем данные по пользователям
        //            .ToList();

        //    // вывод данных
        //    foreach (var company in companies)
        //    {
        //        Console.WriteLine(company.Name);
        //        // выводим сотрудников компании
        //        foreach (var user in company.Users)
        //            Console.WriteLine(user.Name);
        //        Console.WriteLine("----------------------");     // для красоты
        //    }
        //}

        ///*
        // * Теперь у каждого пользователя также есть ссылка на должность, представленную классом Position. 
        // * Компания хранит ссылку на страну Country, которая хранит ссылку на столицу в виде объекта City. 
        // * Теперь добавим начальные и данные и загрузим пользователей с детальными данными
        // */
        //private static void AdvancedSample_EagerLoading(ApplicationContext db) {
        //    // добавляем начальные данные
        //    InsertAdvancedTestData(db);
        //    GetUserCompaniesAdvancedInfo_EagerLoading(db);
        //}
        //private static void InsertAdvancedTestData(ApplicationContext db) {
        //    Position manager = new Position { Name = "Manager" };
        //    Position developer = new Position { Name = "Developer" };
        //    db.Positions.AddRange(manager, developer);

        //    City washington = new City { Name = "Washington" };
        //    db.Cities.Add(washington);

        //    Country usa = new Country { Name = "USA", Capital = washington };
        //    db.Countries.Add(usa);

        //    Company microsoft = new Company { Name = "Microsoft", Country = usa };
        //    Company google = new Company { Name = "Google", Country = usa };
        //    db.Companies.AddRange(microsoft, google);
        //    db.SaveChanges();

        //    User tom = new User { Name = "Tom", Company = microsoft, Position = manager };
        //    User bob = new User { Name = "Bob", Company = google, Position = developer };
        //    User alice = new User { Name = "Alice", Company = microsoft, Position = developer };
        //    User kate = new User { Name = "Kate", Company = google, Position = manager };
        //    db.Users.AddRange(tom, bob, alice, kate);
        //    db.SaveChanges();
        //}
        //private static void GetUserCompaniesAdvancedInfo_EagerLoading(ApplicationContext db) {
        //    // получаем пользователей
        //    var users = db.Users
        //                    .Include(u => u.Company)  // добавляем данные по компаниям
        //                        .ThenInclude(comp => comp.Country)      // к компании добавляем страну 
        //                            .ThenInclude(count => count.Capital)    // к стране добавляем столицу
        //                    .Include(u => u.Position) // добавляем данные по должностям
        //                    .ToList();
        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"{user.Name} - {user.Position.Name}");
        //        Console.WriteLine($"{user.Company?.Name} - {user.Company?.Country.Name} - {user.Company?.Country.Capital.Name}");
        //        Console.WriteLine("----------------------");     // для красоты
        //    }
        //}
        //#endregion

        //private static void LoadUsersToApplicationContext_ExplicitLoading(ApplicationContext db) {
        //    InsertAdvancedTestData(db);

        //    Company company = db.Companies.FirstOrDefault();
        //    // загружает всех пользователей в контекст. После этого нам не надо подгружать связанные данные, так как они уже есть в контексте.
        //    db.Users.Where(p => p.CompanyId == company.Id).Load();

        //    // Важно, что здесь подгружаются только те пользователи, которые непосредственно связаны с компанией.
        //    // Если нам надо загрузить в контекст вообще все объекты из таблицы Users, то можно было бы использовать следующее выражение db.Users.Load()
        //    Console.WriteLine($"Company: {company.Name}");
        //    foreach (var p in company.Users)
        //        Console.WriteLine($"User: {p.Name}");

        //    Console.WriteLine("");

        //    // Для загрузки связанных данных мы также можем использовать методы Collection() и Reference. 
        //    // Метод Collection применяется, если навигационное свойство представляет коллекцию
        //    Country country = db.Countries.FirstOrDefault();
        //    db.Entry(country).Collection(t => t.Companies).Load();

        //    Console.WriteLine($"Country: {country.Name}");
        //    foreach (var p in country.Companies)
        //        Console.WriteLine($"Company: {p.Name}");

        //    Console.WriteLine("");

        //    // Если навигационное свойство представляет одиночный объект, то можно применять метод Reference:
        //    Country country2 = db.Countries.FirstOrDefault();
        //    db.Entry(country2).Reference(x => x.Capital).Load();
        //    Console.WriteLine($"{country2.Name} - {country2?.Capital.Name}");
        //}

        private static void InsertLazyTestData(ApplicationContext db)
        {
            // добавляем начальные данные
            CommonUser tom = new CommonUser { Name = "Tom" };
            CommonUser bob = new CommonUser { Name = "Bob" };
            db.CommonUsers.AddRange(tom, bob);
            db.SaveChanges();

            Ticket ticket1 = new Ticket { Subject = "Ticket 1", Supporter = tom }; // , User = bob
            Ticket ticket2 = new Ticket { Subject = "Ticket 2", SupporterId = bob.Id }; // , User = tom
            db.Tickets.AddRange(ticket1, ticket2);
            db.SaveChanges();
        }
        private static void LazyLoadedProps(ApplicationContext db) {
            InsertLazyTestData(db);

            var tickets = db.Tickets.ToList();
            foreach (Ticket ticket in tickets)
                Console.WriteLine($"{ticket.Subject} - {ticket.Supporter?.Name}"); //  - {ticket.User?.Name}
        }
    }
}
