using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPFundamentals.Interfaces;

namespace OOPFundamentals.Classes
{
    class Mother:Human, IWork // Inheritance, Interfaces
    {
        public Mother(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Hsex = sex;
            Busy = false;
        }

        public bool Busy{get;set;}
        

        public void Work()
        {
            Console.WriteLine("Mother work in office");
        }

        public override void Go() // ? why not private or protected // Polymorphism
        {
            Console.WriteLine(Name + "идет прихрамывая!");
        }

    }
}
