using System;

namespace AbstractFactoryPattern2.SimpleFactory
{
    internal class BigUFOEnemyShip : EnemyShip
    {
        public BigUFOEnemyShip()
        {
            Name = "Big UFO Enemy Ship";
            Speed = 10.0;
            Damage = 40.0;
        }
    }
}