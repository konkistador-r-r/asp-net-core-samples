using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class CarSample
    {
        interface IMovable // IStrategy
        {
            void Move();
        }

        class PetrolMove : IMovable // ConcreteStrategy1
        {
            public void Move()
            {
                Console.WriteLine("Перемещение на бензине");
            }
        }

        class ElectricMove : IMovable // ConcreteStrategy2
        {
            public void Move()
            {
                Console.WriteLine("Перемещение на электричестве");
            }
        }

        class Car
        {
            protected int passengers; // кол-во пассажиров
            protected string model; // модель автомобиля
            public IMovable Movable { private get; set; } // ContextStrategy

            public Car(int num, string model, IMovable mov)
            {
                this.passengers = num;
                this.model = model;
                Movable = mov; // Aggregation
            }

            public void Move()
            {
                Movable.Move();
            }
        }

        public static void Test() {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();

            Console.WriteLine();
            auto.Movable = new ElectricMove();
            auto.Move();
        }
    }
}
