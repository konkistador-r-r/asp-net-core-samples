using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryPattern
{
    // создадим абстрактную фабрику CarFactory,
    // содержащую семейство из двух объектов — автомобиля и двигателя для него. 
    abstract class CarFactory
    {
        public abstract AbstractCar CreateCar();
        public abstract AbstractEngine CreateEngine();
        // В результате у нас появился абстрактный класс с двумя методами, 
        // обеспечивающими получение соответствующих абстрактных объектов.
    }

    // Теперь реализуем первую конкретную фабрику, создающую класс, 
    // описывающий автомобиль BMW и двигатель для него
    class BmwFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new BmwCar();
        }

        public override AbstractEngine CreateEngine()
        {
            return new BmwEngine();
        }
    }
    
    // Сделаем то же самое для автомобиля марки Audi, 
    // чтобы у нас возникла вторая конкретная фабрика:
    class AudiFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new AudiCar();
        }
        public override AbstractEngine CreateEngine()
        {
            return new AudiEngine();
        }
    }
    
    // Теперь опишем абстрактный класс для наших автомобилей. 
    // В данном случае у них будет один метод, позволяющий узнать максимальную скорость машины. 
    // С его помощью мы обратимся и ко второму объекту — двигателю:
    abstract class AbstractCar
    {
        public abstract void MaxSpeed(AbstractEngine engine);
    }
    
    // Все двигатели, в свою очередь, будут содержать один параметр — максимальную скорость. 
    // Эта простая общедоступная переменная позволит сократить объем программы в данном примере:
    abstract class AbstractEngine
    {
        public int MaxSpeed;
    }
    
    // Реализуем класс для автомобиля BMW:
    class BmwCar : AbstractCar
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("Макcимальная скорость: " + engine.MaxSpeed);
        }
    }
    
    // А затем определяем параметры его двигателя: 
    class BmwEngine : AbstractEngine
    {
        public BmwEngine()
        {
            MaxSpeed = 200;
        }
    }
    
    // Проделаем то же самое для класса, описывающего автомобиль Audi:
    class AudiCar : AbstractCar
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("Макcимальная скорость: " + engine.MaxSpeed);
        }
    }

    // Задаем двигатель для него:
    class AudiEngine : AbstractEngine
    {
        public AudiEngine()
        {
            MaxSpeed = 180;
        }
    }
}
