using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeWaysToExtendAClass
{
    public class ChildCar : Car
    {
        public ChildCar(string name): base(name) { }

        public void Brake()
        {
            this.Velocity--;
            Console.WriteLine("Braked {0} to velocity {1} (with child class)",
                this.Name, this.Velocity);
        }
    }
}
