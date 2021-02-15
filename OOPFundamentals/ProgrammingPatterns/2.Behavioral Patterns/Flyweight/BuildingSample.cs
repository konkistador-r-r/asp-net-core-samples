using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flyweight.BuildingSample
{
    class Client
    {
        public static void Run(CancellationTokenSource cts) {
            double longitude = 37.61;
            double latitude = 55.74;

            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            HouseFactory houseFactory = new HouseFactory();
            for (int i = 0; i < 50000; i++)
            {
                cts.Token.ThrowIfCancellationRequested();

                House panelHouse = houseFactory.GetHouse("Panel");
                //House panelHouse = new PanelHouse();
                if (panelHouse != null)
                    panelHouse.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }

            for (int i = 0; i < 50000; i++)
            {
                cts.Token.ThrowIfCancellationRequested();

                House brickHouse = houseFactory.GetHouse("Brick"); // 38 sec
                                                                   //House brickHouse = new BrickHouse(); // 42 sec
                if (brickHouse != null)
                    brickHouse.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            Console.WriteLine(elapsedTime);
        }
    }

    abstract class House
    {
        protected int stages; // количество этажей - внутреннее состояние

        public abstract void Build(double longitude, double latitude); // принимает широту и долготу расположения дома - внешнее состояние
    }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Построен панельный дом из 16 этажей; координаты: {0} широты и {1} долготы",
                latitude, longitude);
        }
    }
    class BrickHouse : House
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Построен кирпичный дом из 5 этажей; координаты: {0} широты и {1} долготы",
                latitude, longitude);
        }
    }

    class HouseFactory
    {
        Dictionary<string, House> houses = new Dictionary<string, House>();
        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (houses.ContainsKey(key))
                return houses[key];
            else
                return null;
        }
    }
}
