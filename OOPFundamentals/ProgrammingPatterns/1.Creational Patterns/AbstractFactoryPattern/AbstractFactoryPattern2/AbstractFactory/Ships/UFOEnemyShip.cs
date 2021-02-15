using System;

namespace AbstractFactoryPattern2.AbstractFactory
{
    internal class UFOEnemyShip : EnemyShip
    {
        IEnemyShipFactory _shipFactory;
        public UFOEnemyShip() {
            Name = "UFO Enemy Ship";
            Speed = 20.0;
            Damage = 20.0;
        }

        public UFOEnemyShip(IEnemyShipFactory shipFactory)
        {
            _shipFactory = shipFactory;
        }

        public override void makeShip()
        {
            Console.WriteLine("Making enemy ship " + Name);

            Weapon = _shipFactory.addGun();
            Engine = _shipFactory.addEngine();
        }
    }
}