using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flyweight.CircleSample
{
    /*
        We will demonstrate this pattern by drawing 20 circles of different locations but we will create only 5 objects. 
        Only 5 colors are available so color property is used to check already existing Circle objects. 
    */
    public static class Client
    {
        private static String[] _colors = { "Red", "Green", "Blue", "White", "Black" };
        private static Random rand = new Random(1);
        public static void Run(CancellationTokenSource cts)
        {
            for (int i = 0; i < 20; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetCircle(getRandomColor());
                circle.SetX(getRandomX());
                circle.SetY(getRandomY());
                circle.SetRadius(100);
                circle.Draw();
            }
        }

        private static String getRandomColor()
        {
            return _colors[rand.Next(0, 4)];
        }
        private static int getRandomX()
        {
            return rand.Next(0, 100);
        }
        private static int getRandomY()
        {
            return rand.Next(0, 100);
        }
    }

    public interface IShape
    {
        void Draw();
    }

    public class Circle : IShape
    {
        private String color; // intrinsic state
        private int x; // extrinsic state 
        private int y; // extrinsic state 
        private int radius; // extrinsic state 

        public Circle(String color)
        {
            this.color = color;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void SetRadius(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine("Circle: Draw() [Color : " + color + ", x : " + x + ", y :" + y + ", radius :" + radius);
        }
    }

    public class ShapeFactory
    {
        private static Dictionary<string, IShape> circleMap = new Dictionary<string, IShape>();

        public static IShape GetCircle(String color)
        {
            IShape circle;
            if (!circleMap.TryGetValue(color, out circle))
            {
                circle = new Circle(color);
                circleMap.Add(color, circle);
                Console.WriteLine("Creating circle of color : " + color);
            }
            return circle;
        }
    }
}
