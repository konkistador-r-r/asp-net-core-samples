namespace AbstractFactoryPattern2.SimpleFactory
{
    internal class EnemyShipFactory
    {
        public EnemyShip makeEnemyShip(string newShipType) {
            EnemyShip newShip = null;

            switch (newShipType)
            {
                case "U":
                    newShip = new UFOEnemyShip();
                    break;
                case "R":
                    newShip = new RocketEnemyShip();
                    break;
                case "B":
                    newShip = new BigUFOEnemyShip();
                    break;
                default:
                    break;
            }

            return newShip;
        }
    }
}