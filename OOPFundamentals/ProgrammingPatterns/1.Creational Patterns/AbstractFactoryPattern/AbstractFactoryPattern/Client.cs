using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryPattern
{
    // Теперь мы создадим класс Client, где покажем, как осуществляется работа с абстрактной фабрикой. 
    class Client
    {
        private AbstractCar _abstractCar;
        private AbstractEngine _abstractEngine;
        // В конструктор такого класса будут передаваться все конкретные фабрики, 
        // которые и начнут создавать объекты автомобиль и двигатель.
        // Следовательно, в конструктор класса Client допустимо передать любую конкретную фабрику, 
        // работающую с любыми марками автомобилей.
        public Client(CarFactory carFactory)
        {
            _abstractCar = carFactory.CreateCar();
            _abstractEngine = carFactory.CreateEngine();
        }

        // А метод Run позволит узнать максимальную скорость конкретной машины. 
        public void Run()
        {
            _abstractCar.MaxSpeed(_abstractEngine);
        } 
    }
}
