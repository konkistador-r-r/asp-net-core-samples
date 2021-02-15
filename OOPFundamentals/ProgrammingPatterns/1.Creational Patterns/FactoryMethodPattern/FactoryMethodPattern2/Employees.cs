using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Создатель доверяет своим подклассам реализацию подходящего конкретного продукта. 
// В этом и заключается суть FactoryMethod.
namespace VirtualConstructorPattern
{
    // абстрактный класс для хранения информации о сотрудниках организации.
    // Продукт - абстрактный класс служащий основой 
    abstract class EmployeeProduct
    {
        public abstract void Status();
        public abstract void Salary();
    }

    // Конкретизируем его в двух подклассах — ManagerEmploye и ProgrammerEmploye
    // Конкретный продукт 1.Менеджер
    class ManagerEmployeeConcreteProduct : EmployeeProduct
    {
        public override void Status()
        {
            Console.WriteLine("Manager");
        }

        public override void Salary()
        {
            Console.WriteLine("1500");
        }
    }

    // Конкретный продукт 2.Программист
    class ProgrammerEmployeeConcreteProduct : EmployeeProduct
    {
        public override void Status()
        {
            Console.WriteLine("Programmer");
        }

        public override void Salary()
        {
            Console.WriteLine("2000");
        }
    }



    // Создатель продукта
    abstract class Creator
    {
        public abstract EmployeeProduct FactoryMethod();
    }

    // Создатель конкретного продукта "Менеджер"
    class ManagerConreteCreator : Creator
    {
        public override EmployeeProduct FactoryMethod()
        {
            return new ManagerEmployeeConcreteProduct();
        }
    }

    // Создатель конкретного продукта "Программист"
    class ProgrammerConreteCreator : Creator
    {
        public override EmployeeProduct FactoryMethod()
        {
            return new ProgrammerEmployeeConcreteProduct();
        }
    }
}
