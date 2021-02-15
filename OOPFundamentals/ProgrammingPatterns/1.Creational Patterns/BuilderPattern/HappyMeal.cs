using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* А теперь, чтобы лучше понять суть паттерна Builder, рассмотрим практический пример, 
 * в котором вы будете собирать объект HappyMeal — знаменитый детский набор, предлагаемый в сети закусочных McDonald’s. 
 * В первом случае вы соберете бюджетный вариант HappyMeal (маленькая порция пепси-колы, гамбургер, картошка и игрушка), 
 * а во втором — BigHappyMeal (гамбургер вы замените на бигмак и увеличите порцию напитка).
 */

namespace BuilderPattern
{
    // Начнем с реализации продукта: 
    class HappyMealProduct
    {
        // содержит информацию о составе HappyMeal
        private ArrayList _parts = new ArrayList();

        // Добавляете информацию о новой составной части 
        public void Add(string part)
        {
            _parts.Add(part);
        }

        // Выводит информацию о всем наборе 
        public void Show()
        {
            Console.WriteLine(" Happy Meal Parts ——-");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }

    // Теперь реализуем Строитель:
    // "Строитель — абстрактный интерфейс для создания объекта HappyMeal по частям" 
    abstract class HappyMealBuilder
    {
        // предназначены для конструирования какой-то части вашего объекта.
        public abstract void BuildBurger();
        public abstract void BuildPepsi();
        public abstract void BuildFries();
        public abstract void BuildToy();
        // возвращает сконструированный вами HappyMeal
        public abstract HappyMealProduct GetProduct();
    }

    //  Теперь реализуйте свой первый конкретный Строитель, создающий большой HappyMeal:
    // Строитель для большого // HappyMeal 
    class BigHappyMealBuilder : HappyMealBuilder
    {
        private HappyMealProduct _happyMeal = new HappyMealProduct();
        public override void BuildBurger()
        {
            _happyMeal.Add("BigMac");
        }
        public override void BuildPepsi()
        {
            _happyMeal.Add("Pepsi 0.7");
        }
        public override void BuildFries()
        {
            _happyMeal.Add("BigFries");
        }
        public override void BuildToy()
        {
            _happyMeal.Add("Two toys");
        }
        public override HappyMealProduct GetProduct()
        {
            return _happyMeal;
        }
    }

    //  С маленьким HappyMeal все делается аналогично:
    // Строитель для маленького HappyMeal 
    class SmallHappyMealBuilder : HappyMealBuilder
    {
        private HappyMealProduct _happyMeal = new HappyMealProduct();
        public override void BuildBurger()
        {
            _happyMeal.Add("Hamburger");
        }
        public override void BuildPepsi()
        {
            _happyMeal.Add("Pepsi 0.3");
        }
        public override void BuildFries()
        {
            _happyMeal.Add("SmallFries");
        }
        public override void BuildToy()
        {
            _happyMeal.Add("One toy");
        }
        public override HappyMealProduct GetProduct()
        {
            return _happyMeal;
        }
    }

    // Пришло время реализовать класс Director, который будет отвечать за конструирование объектов:
    class Director
    {
        // Конструирование объекта по частям 
        public void Construct(HappyMealBuilder builder)
        {
            builder.BuildBurger();
            builder.BuildPepsi();
            builder.BuildFries();
            builder.BuildToy();
        }
    }

    /* Как видно из фрагмента листинга, все действие сосредоточено вокруг метода Construct. 
     * В него вы передаете объект HappyMealBuilder, после чего начинаете пошаговую сборку, 
     * поочередно вызывая каждый из Build-методов.
     */
}
