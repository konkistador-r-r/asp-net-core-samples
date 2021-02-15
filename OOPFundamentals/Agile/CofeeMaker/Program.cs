using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMakerAPI api = new M4CoffeeMakerAPI();
            M4UserInterface ui = new M4UserInterface(api);
            M4HotWaterSource hws = new M4HotWaterSource(api);
            M4ContainmentVessel cv = new M4ContainmentVessel(api);

            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);

            while (true)
            {
                ui.Poll();
                hws.Poll();
                cv.Poll();
            }
        }
    }
}
