using System;
using System.Linq;

namespace DbFirst
{
    // добавление классов вручную имеет свои недостатки
    // может возникнуть проблема при отображении отношений между множества таблиц, связанных различными ключами, на класы.
    // Ну и кроме того, это просто долго и может занять некоторое время.
    // функция Reverse Engineering, которая позволяет автоматически создать все необходимые классы по базе данных.
    // в Package Manager Console выполним следующую команду:
    // Scaffold-DbContext "dbConnectionString" Microsoft.EntityFrameworkCore.SqlServer
    // Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=EFFirstApp;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
    // Пакет "Microsoft.EntityFrameworkCore.SqlServer" представляет функциональность Entity Framework для работы с MS SQL Server, 
    // "Microsoft.EntityFrameworkCore.Tools" и "Microsoft.EntityFrameworkCore.SqlServer.Design" понадобятся для создания классов по базе данных, то есть reverse engineering.
    class Program
    {
        static void Main(string[] args)
        {
            CRUDoperations.ClearTable();

            CRUDoperations.AddData();
            Console.WriteLine("Данные после добавления:");
            CRUDoperations.ReadAllData();

            CRUDoperations.UpdateData();
            Console.WriteLine("\nДанные после редактирования:");
            CRUDoperations.ReadAllData();

            CRUDoperations.DeleteData();
            Console.WriteLine("\nДанные после удаления:");
            CRUDoperations.ReadAllData();

            // Если мы получаем объект в одном месте, а обновляем в другом, то используй db.Users.Update
            var user = CRUDoperations.SelectFirstOrDefault();
            if (user != null)
            {
                Console.WriteLine("\nДанные после редактирования пользователя " + $"{user.Id}.{user.Name} - {user.Age}: ");
                var dbUser = CRUDoperations.SelectUser(user.Id);
                CRUDoperations.ChangeUser(dbUser);
                CRUDoperations.UpdateUser(dbUser);
            }
            CRUDoperations.ReadAllData();

            Console.WriteLine("\nОбновляются только указанные свойства:");
            CRUDoperations.UpdateDataLog();
            CRUDoperations.ReadAllData();

            Console.ReadKey();
        }
    }
}
