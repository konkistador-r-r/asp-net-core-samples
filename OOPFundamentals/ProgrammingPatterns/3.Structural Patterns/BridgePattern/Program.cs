using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Мост (Bridge) - структурный шаблон проектирования, который позволяет отделить абстракцию от реализации таким образом, 
 * чтобы и абстракцию, и реализацию можно было изменять независимо друг от друга.
 * 
 * https://metanit.com/sharp/patterns/4.6.php
 */
namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // создаем нового программиста, он работает с с++
            Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            Console.WriteLine();
            // пришел новый заказ, но теперь нужен c#
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();

            // in future use new method
            freelancer.NewMethod();

            Console.Read();
        }
    }

    // Мы можем развивать независимо две параллельные иерархии. 
    // Устраняются зависимости между реализацией и абстракцией во время компиляции, и мы можем менять конкретную реализацию во время выполнения.

    #region 1st hierarchy
    // Abstraction: определяет базовый интерфейс и хранит ссылку на объект Implementor. 
    abstract class Programmer
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        public Programmer(ILanguage lang)
        {
            language = lang;
        }
        public virtual void DoWork()
        {
            // Выполнение операций в Abstraction делегируется методам объекта Implementor
            language.Build();
            language.Execute();
        }

        public abstract void EarnMoney();

        public void NewMethod() {
            Console.WriteLine("Any change 2");
        }
    }

    // FreelanceProgrammer и CorporateProgrammer представляют уточненные абстракции.
    // RefinedAbstraction: уточненная абстракция, наследуется от Abstraction и расширяет унаследованный интерфейс
    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Получаем оплату за выполненный заказ");
        }
    }
    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Получаем в конце месяца зарплату");
        }
    }
    #endregion

    #region 2nd hierarchy
    // Implementor: определяет базовый интерфейс для конкретных реализаций. Как правило, Implementor определяет только примитивные операции. 
    // Более сложные операции, которые базируются на примитивных, определяются в Abstraction
    //  в роли Implementor - интерфейс ILanguage, который представляет язык программирования. В методе DoWork() класса Programmer вызываются методы объекта ILanguage.
    interface ILanguage
    {
        void Build();
        void Execute();
    }

    // ConcreteImplementorA и ConcreteImplementorB: конкретные реализации, которые унаследованы от Implementor
    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора C++ компилируем программу в бинарный код");
        }

        public void Execute()
        {
            Console.WriteLine("Запускаем исполняемый файл программы");
        }
    }
    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора");
        }

        public void Execute()
        {
            Console.WriteLine("JIT компилирует программу бинарный код");
            Console.WriteLine("CLR выполняет скомпилированный бинарный код");
            Console.WriteLine("Any change 1");
        }
    }
    #endregion
}
