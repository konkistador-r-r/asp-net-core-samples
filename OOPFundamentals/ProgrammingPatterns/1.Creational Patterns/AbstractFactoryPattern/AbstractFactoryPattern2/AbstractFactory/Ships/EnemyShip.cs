using System;

namespace AbstractFactoryPattern2.AbstractFactory
{
    public abstract class EnemyShip
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public double Damage { get; set; }

        // These can be changed easily by assigning new parts
        // in UFOEnemyShipFactory or UFOBossEnemyShipFactory
        public IWeapon Weapon;
        public IEngine Engine;

        public abstract void makeShip();

        public override string ToString() {
            string infoOnShip = string.Format("The {0} has a top speed of {1} and an attack power of {2}", Name, Engine, Weapon);
            return infoOnShip;
        }

        public void followHeroShip()
        {
            Console.WriteLine(Name + " is following the hero at " + Engine);
        }

        public void displayEnemyShip()
        {
            Console.WriteLine(Name + " is on the screen");
        }

        public void enemyShipShoots()
        {
            Console.WriteLine(Name + " attacks and does " + Weapon);
        }
    }
}