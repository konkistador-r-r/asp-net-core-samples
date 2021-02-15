using System;

namespace AbstractFactoryPattern2.SimpleFactory
{
    public abstract class EnemyShip
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public double Damage { get; set; }

        public override string ToString()
        {
            string infoOnShip = string.Format("The {0} has a top speed of {1} and an attack power of {2}", Name, Speed, Damage);
            return infoOnShip;
        }
    }
}