using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    #region Creator & ConcreteCreators
    public enum DeveloperType { Panel, Wood, Break }
    // абстрактный класс строительной компании
    public abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public House Create();

        public static Developer Create(DeveloperType type, string name)
        {
            switch (type)
            {
                case DeveloperType.Panel:
                    return new PanelDeveloper(name);
                case DeveloperType.Wood:
                    return new WoodDeveloper(name);
                case DeveloperType.Break:
                    return new BreakDeveloper(name);
                default:
                    throw new Exception("Type is not exists");
            }
        }
    }

    // строит панельные дома
    internal class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    // строит деревянные дома
    internal class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    // строит кирпичные дома
    internal class BreakDeveloper : Developer
    {
        public string Name { get; set; }

        public BreakDeveloper(string n) : base(n) { }

        public override House Create()
        {
            return new BreakHouse();
        }
    }
    #endregion
}
