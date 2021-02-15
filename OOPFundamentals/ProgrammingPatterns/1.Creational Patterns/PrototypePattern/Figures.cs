using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrototypePattern
{
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    [Serializable]
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    [Serializable]
    class Rectangle : IFigure
    {
        int width;
        int height;
        public Point Point { get; set; }
        public Rectangle(int x, int y, int w, int h)
        {
            width = w;
            height = h;
            this.Point = new Point { X = x, Y = y };
        }

        public IFigure Clone()
        {
            //return new Rectangle(this.Point.X, this.Point.Y, this.width, this.height);
            return ObjectCopier.Clone<Rectangle>(this);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", height, width);
        }
    }

    [Serializable]
    class Circle : IFigure
    {
        int radius;
        public Point Point { get; set; }
        public Circle(int x, int y, int r)
        {
            radius = r;
            this.Point = new Point { X = x, Y = y };
        }    

        public IFigure Clone()
        {
            return ObjectCopier.Clone<Circle>(this);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0}", radius);
        }
    }
}
