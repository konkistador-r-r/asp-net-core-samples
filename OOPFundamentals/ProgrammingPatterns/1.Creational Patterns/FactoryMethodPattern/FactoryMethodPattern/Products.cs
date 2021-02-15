using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    #region Product & ConcreteProduct
    public abstract class House
    { }

    internal class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    internal class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
    internal class BreakHouse : House
    {
        public BreakHouse()
        {
            Console.WriteLine("Кирпичный дом построен");
        }
    }
    #endregion
}
