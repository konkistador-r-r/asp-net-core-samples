using System;

namespace AbstractFactoryPattern2.SimpleFactory
{
    internal class UFOEnemyShip : EnemyShip
    {
        public UFOEnemyShip() {
            Name = "UFO Enemy Ship";
            Speed = 20.0;
            Damage = 20.0;
        }
    }
}