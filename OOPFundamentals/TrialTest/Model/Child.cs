using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrialTest.Model
{
    class Child : Human
    {
        public Child(string name, int age, Sex gemder) : base(name, age, gemder)
        {
            
        } // Inheritance [2]
        
        public event Money NeedMoney; // Events [6]
        public decimal InvokeNeedMoney(Human parent, Relations relation, decimal sum)  // Events [6]
        {
            Money handler = NeedMoney;
            return handler(parent,this,relation, sum);
        } 

        public override void Walk()
        {
            Console.WriteLine("Child: {0}, walks", Name);
        } // Polimorphism [3]
    }
}
