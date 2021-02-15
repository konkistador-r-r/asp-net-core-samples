using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFundamentals.Polimorphizm
{
    class FigureExample
    {
        public virtual void Draw()
        {
            Console.WriteLine("Figure");
        }
    }

    class Triangle : FigureExample
    {
        public override void Draw()
        {
            Console.WriteLine("Triangle");
        }
    }

    class Cycle : FigureExample
    {
        public override void Draw()
        {
            Console.WriteLine("Cycle");
        }
    }
}
