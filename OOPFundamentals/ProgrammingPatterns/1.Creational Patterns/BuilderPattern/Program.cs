using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаете класс Director и строителей для двух наборов HappyMeal 
            Director director = new Director();
            HappyMealBuilder bigHmbuilder = new BigHappyMealBuilder();
            HappyMealBuilder smallHmbuilder = new SmallHappyMealBuilder();
            
            // Конструируете два продукта 
            director.Construct(bigHmbuilder);
            director.Construct(smallHmbuilder);

            // Получаете два продукта
            HappyMealProduct hm1 = bigHmbuilder.GetProduct();
            HappyMealProduct hm2 = smallHmbuilder.GetProduct();

            // Работа с продуктами
            hm1.Show();
            Console.WriteLine();
            hm2.Show();

            // Попрактикуйтесь с более сложными объектами. 
            // Подумайте, где бы вы могли применять данный шаблон. 

            Console.WriteLine();
            Console.WriteLine("BreadBuilder");

            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());


            Console.Read();
        }
    }
}
