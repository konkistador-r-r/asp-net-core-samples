using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    #region Original code

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();

        protected List<string> ingridients;
        public virtual List<string> GetIngridients() { return ingridients; }
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        {
            ingridients = ingridients ?? new List<string>();
            SetIngridients();
        }

        public override int GetCost()
        {
            return 10;
        }

        public void SetIngridients()
        {
            ingridients.Add("Итальянский хлеб");
        }

    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza() : base("Болгарская пицца")
        {
            ingridients = ingridients ?? new List<string>();
            SetIngridients();
        }
        public override int GetCost()
        {
            return 8;
        }

        public void SetIngridients()
        {
            ingridients.Add("Болгарский хлеб");
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            // copy all data if it is not possible to access them
            this.pizza = pizza;
            this.ingridients = pizza.GetIngridients();
        }
    }

    #endregion

    #region Change

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p) : base(p.Name + ", с томатами", p)
        {
            SetIngridients();
        }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }

        public void SetIngridients()
        {
            ingridients.Add("помидоры");
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p) : base(p.Name + ", с сыром", p)
        {
            SetIngridients();
        }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }

        public void SetIngridients()
        {
            ingridients.Add("сыр");
        }
    }

    #endregion
}
