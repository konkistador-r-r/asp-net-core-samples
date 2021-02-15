using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator // The Decorator attaches additional responsibilities to an object dynamically. 
{
    public class FireOptions {
        public int Accuracy { get; set; }
        public int Volume { get; set; }
        public int Convenience { get; set; }        
    }

    public abstract class AutomaticGun
    {
        public FireOptions FireOptions { get; protected set; }
        public abstract void Fire();

        public abstract string GetGunDescription();
    }

    public class M16 : AutomaticGun
    {
        private string description;
        public M16() {
            FireOptions = new FireOptions {
                Accuracy = 1,
                Volume = 1,
                Convenience = 1
            };

            description = "Real gun";
        }

        public override void Fire()
        {
            Console.WriteLine("Fire with following options \nAccuracy:{0}\nVolume:{1}\nConvenience:{2}", FireOptions.Accuracy, FireOptions.Volume, FireOptions.Convenience);
        }

        public override string GetGunDescription()
        {
            return description;
        }
    }

    public class AutomaticGunDecorator : AutomaticGun
    {
        protected AutomaticGun gun;
        public AutomaticGunDecorator(AutomaticGun gun) {
            this.gun = gun;            
        }

        public override void Fire()
        {
            gun.Fire();
        }

        public override string GetGunDescription()
        {
            return gun.GetGunDescription();
        }
    }

    public class ApplyLaserSight : AutomaticGunDecorator
    {
        public ApplyLaserSight(AutomaticGun gun) : base(gun)
        {
            this.FireOptions = new FireOptions
            {
                Accuracy = gun.FireOptions.Accuracy + 5,
                Volume = gun.FireOptions.Volume,
                Convenience = gun.FireOptions.Convenience
            };
        }

        public override void Fire()
        {
            //base.Fire();
            Console.WriteLine("Fire with following options \nAccuracy:{0}\nVolume:{1}\nConvenience:{2}", FireOptions.Accuracy, FireOptions.Volume, FireOptions.Convenience);
        }
    }

    public class ApplySilencer : AutomaticGunDecorator
    {
        public ApplySilencer(AutomaticGun gun) : base(gun)
        {
            this.FireOptions = new FireOptions
            {
                Accuracy = gun.FireOptions.Accuracy,
                Volume = gun.FireOptions.Volume - 1,
                Convenience = gun.FireOptions.Convenience
            };
        }

        public override void Fire()
        {
            //base.Fire();
            Console.WriteLine("Fire with following options \nAccuracy:{0}\nVolume:{1}\nConvenience:{2}", FireOptions.Accuracy, FireOptions.Volume, FireOptions.Convenience);
        }
    }

    public class ApplyButt: AutomaticGunDecorator
    {
        public ApplyButt(AutomaticGun gun) : base(gun)
        {
            this.FireOptions = new FireOptions
            {
                Accuracy = gun.FireOptions.Accuracy,
                Volume = gun.FireOptions.Volume,
                Convenience = gun.FireOptions.Convenience + 10
            };
        }

        public override void Fire()
        {
            //base.Fire();
            Console.WriteLine("Fire with following options \nAccuracy:{0}\nVolume:{1}\nConvenience:{2}", FireOptions.Accuracy, FireOptions.Volume, FireOptions.Convenience);
        }
    }
}
