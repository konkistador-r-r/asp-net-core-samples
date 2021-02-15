// In summary, you know how to create a derived/base class relationship. 
// You can control instantiation of your base class and call its methods either implicitly or explicitly. You also understand that a derived class is a specialization of its base class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class Inheritance
    {
        // OOP: Inheritance of base class by derived class. 
        public class ParentClass
        {
            protected string Name = "protected variable";
            //Base classes are automatically instantiated before derived classes. 
            public ParentClass()
            {
                Console.WriteLine("1.Parent Constructor.");
            }

            public void print()
            {
                Console.WriteLine("3.I'm a Parent Class.");
            }
        }
        //ChildClass has exactly the same capabilities as ParentClass. 
        //Because of this, you can also say ChildClass "is" a ParentClass.
        //ChildClass does not have its own print() method, so it uses the ParentClass print() method
        public class ChildClass : ParentClass
        {
            public ChildClass()
            {
                Console.WriteLine("2.Child Constructor." + base.Name);
                
            }
        }

        public static void MainMethod()
        {
            ChildClass child = new ChildClass();
            child.print();

            ChildClass2 child2 = new ChildClass2();
            child2.print();
            ((ParentClass2)child2).print();

            Casting();
        }
        // Remember that a derived class is a specialization of its base class.
        private class ParentClass2
        {
            private string parentString;

            public ParentClass2()
            {
                Console.WriteLine("Parent Constructor.");
            }

            public ParentClass2(string myString)
            {
                parentString = myString;
                Console.WriteLine(parentString);
            }

            public void print()
            {
                Console.WriteLine("3 and 5 print() func of a Parent Class.");
            }
        }
        //Sometimes you may want to create your own implementation of a method that exists in a base class. 
        // Child class modifier cannot be a public if it parent class modifier is private or protected
        private class ChildClass2 : ParentClass2 
        {
            public ChildClass2()
                : base("At 1 Called constructor of base class from derived, its executed before derived class constructor")
            {
                Console.WriteLine("2 called Child Constructor.");
            }
            // new is not mandatory but it explicitly states your intention that you don't want polymorphism to occur.
            public new void print() // Hiding of base class method by new modifier. 
            {
                //Using the base keyword, you can explicitly access any of a base class public or protected class members. 
                base.print(); // Calling base class method from derived class method
                Console.WriteLine("4 print() func of a Child Class.");
            }
        }




        // Derived : Base
        // Селедка : Рыба
        internal class Employee //: System.Object
        {
            public int GetYearsEmployed()
            {
                return 5;
            }

            public virtual String GenProgressReport()
            {
                return "Start level";
            }
            public static Employee GetPromoutedToManager(String name)
            {
                var manager = new Manager();
                return manager;
            }

        }
        // Derived : BASE
        // Селедка : Рыба
        // sealed - means that any class cannot inherit them
        internal sealed class Manager : Employee
        {
            public override string GenProgressReport()
            {
                return base.GenProgressReport() + "From derrived";
            }
        }
        //Error: cannot derive from sealed type 'Lessons.Inheritance.Manager'
        //public class Supervisor : Manager
        //{
            
        //}

        public static void Casting()
        {
            Employee e;
            int year;
            //Employee = Manager
            // Рыба = Селедка,но не Селедка = Рыба[ Manager e = new Employee();]
            e = new Manager();
            // Manager = Employee
            e = Employee.GetPromoutedToManager("Joe");
            year = e.GetYearsEmployed();
            e.GenProgressReport();
        }
    }
}
