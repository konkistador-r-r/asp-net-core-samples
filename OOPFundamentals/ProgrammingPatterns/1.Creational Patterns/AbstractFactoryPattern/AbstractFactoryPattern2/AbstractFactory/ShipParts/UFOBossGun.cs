using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern2.AbstractFactory
{
    public class UFOBossGun : IWeapon
    {
        public override string ToString() {
            return "40 damage";
        }
    }    
}
