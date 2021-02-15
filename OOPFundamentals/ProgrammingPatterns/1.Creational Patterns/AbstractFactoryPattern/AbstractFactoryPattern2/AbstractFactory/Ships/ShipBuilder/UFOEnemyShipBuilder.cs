using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern2.AbstractFactory
{
    public class UFOEnemyShipBuilder : EnemyShipBuilder
    {
        protected override EnemyShip makeEnemyShip(string typeOfShip) {
            EnemyShip theEnemyShip = null;
            IEnemyShipFactory shipPartsFactory;

            switch (typeOfShip)
            {
                case "UFO":
                    shipPartsFactory = new UFOEnemyShipFactory();
                    theEnemyShip = new UFOEnemyShip(shipPartsFactory);
                    theEnemyShip.Name = "UFO Grant Ship";
                    break;
                case "UFO BOSS":
                    shipPartsFactory = new UFOBossEnemyShipFactory();
                    theEnemyShip = new BigUFOEnemyShip(shipPartsFactory);
                    theEnemyShip.Name = "UFO Boss Ship";
                    break;
                default:
                    break;
            }

            return theEnemyShip;
        }
    }
}
