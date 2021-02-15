using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeWaysToExtendAClass
{
    // Let's add braking functionality, or a Break() method, with containment
    public class CarContainer
    {
        public Car Car;

        public CarContainer(Car c)
        {
            this.Car = c;
            Console.WriteLine("\nCreated container for {0}", this.Car.Name);
        }

        public void Brake()
        {
            this.Car.Velocity--;
            Console.WriteLine("Braked {0} to velocity {1} (with containment)",
                this.Car.Name, this.Car.Velocity);
        }
    }
}
