using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern2.AbstractFactory
{
    // This is where we define all of the parts the ship
    // will use by defining the methods
    class UFOBossEnemyShipFactory : IEnemyShipFactory
    {
        public IEngine addEngine()
        {
            return new UFOBossEngine();
        }

        public IWeapon addGun()
        {
            return new UFOBossGun(); // Specific to Boss UFO
        }
    }
}
