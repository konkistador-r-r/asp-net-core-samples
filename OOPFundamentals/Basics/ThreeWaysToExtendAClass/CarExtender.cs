using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeWaysToExtendAClass
{
    public static class CarExtender
    {
        public static void BrakeAction(this Car c)
        {
            c.Velocity--;
            Console.WriteLine("Braked {0} to velocity {1} (with extension method)", c.Name, c.Velocity);
        }
    }
}
