namespace AbstractFactoryPattern2.AbstractFactory
{
    public abstract class EnemyShipBuilder
    {
        protected abstract EnemyShip makeEnemyShip(string typeOfShip);

        public EnemyShip orderTheShip(string typeOfShip) {
            EnemyShip theEnemyShip = makeEnemyShip(typeOfShip);

            theEnemyShip.makeShip();
            theEnemyShip.displayEnemyShip();
            theEnemyShip.followHeroShip();
            theEnemyShip.enemyShipShoots();

            return theEnemyShip;
        }
    }
}