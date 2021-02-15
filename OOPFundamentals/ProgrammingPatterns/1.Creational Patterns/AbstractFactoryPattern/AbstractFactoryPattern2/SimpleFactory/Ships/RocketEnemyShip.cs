namespace AbstractFactoryPattern2.SimpleFactory
{
    internal class RocketEnemyShip : EnemyShip
    {
        public RocketEnemyShip()
        {
            Name = "Rocket Enemy Ship";
            Speed = 30.0;
            Damage = 20.0;
        }
    }
}