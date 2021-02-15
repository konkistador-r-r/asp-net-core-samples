using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrialTest.Model
{
    public enum Sex
    {
        Male,
        Female,
    }

    public class Human
    {
        public delegate decimal Money(Human pearson1, Human pearson2, Relations relation, decimal sum); // Event [6]

        private readonly Guid _id; 
        public Guid Id
        {
            get { return _id; }
        }               //Encapsulation [1]
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Gender { get; set; }
        public Dictionary<string, Guid> Relationships = new Dictionary<string, Guid>(); // Relations [0]

        public Human(string name, int age, Sex gemder, Guid id = new Guid())
        {
            _id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Age = age;
            Gender = gemder;
        }

        public virtual void Walk()
        {
            Console.WriteLine("Go");
        }       // Inheritance [2], Polymorphism [3]

        
    }
}
