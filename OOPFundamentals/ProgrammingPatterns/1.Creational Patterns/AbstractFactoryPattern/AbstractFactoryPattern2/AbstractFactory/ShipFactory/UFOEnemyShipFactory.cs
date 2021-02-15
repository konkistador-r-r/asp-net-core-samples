using System;

namespace AbstractFactoryPattern2.AbstractFactory
{
    internal class UFOEnemyShipFactory : IEnemyShipFactory
    {
        public IEngine addEngine()
        {
            return new UFOEngine(); // Specific to regular UFO
        }

        public IWeapon addGun()
        {
            return new UFOGun();
        }
    }
}