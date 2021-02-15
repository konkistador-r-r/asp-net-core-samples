using System;

namespace AbstractFactoryPattern2.AbstractFactory
{
    internal class BigUFOEnemyShip : EnemyShip
    {
        IEnemyShipFactory _shipFactory;
        public BigUFOEnemyShip()
        {
            Name = "Big UFO Enemy Ship";
            Speed = 10.0;
            Damage = 40.0;
        }

        public BigUFOEnemyShip(IEnemyShipFactory shipFactory)
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