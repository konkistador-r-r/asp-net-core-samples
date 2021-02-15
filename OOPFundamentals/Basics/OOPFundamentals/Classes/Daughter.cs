using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPFundamentals.Interfaces;

namespace OOPFundamentals.Classes
{
    class Daughter:Human // Inheritance
    {
        private int _health;
        public Daughter(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Hsex = sex;
            _health = 100;
        }

        public override void Go() // ? why not private or protected // Polymorphism
        {
            Console.WriteLine(Name + "идет в припрыжку!");
        }

        public void BecomeHungry(int value)
        {
            _health -= value;
        }

        public void Eat()
        {
            _health += 20;
        }

        public int GetHealth()
        {
            return _health;
        }
    }
}
