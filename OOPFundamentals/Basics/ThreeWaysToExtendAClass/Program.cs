using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeWaysToExtendAClass
{
    // https://www.codeproject.com/Articles/24948/Three-Ways-To-Extend-A-Class
    // WHEN the developer is not allowed to change the original class. 
    // Techniques like adding the methods to the original class or making it eat an interface are not possible options. So a developer needs to do something else.
    //
    // The reasons for a software developer not being able to change the original source code can be numerous:
    // * the source class is part of a commercial package
    // *  licensing issue that prohibits a developer from changing the code
    //
    // OOP gives us 3 ways: Containment (adding a layer of abstraction) and Inheritance (possibility of inheriting the "knowledge" of the original class and add new functionality),
    // C# 3.0 gives yet another option called Extension Methods
    //
    // To summarize, here are the three ways of functional class extension when applying changes to original class is not possible:
    // * Containment (OOP concept)
    // * Inheritance(OOP concept)
    // * Extension Methods(C# 3.0 concept)


    class Program
    {
        static void Main(string[] args)
        {
            //// Oriiginal class Car usage
            //Car c = new Car("Mazda");
            //c.Accelerate();
            //// c.Break(); // Can't do this, because this Car does not know how to brake!

            //// Extension of Oriiginal class using Containment
            //Car c = new Car("Mazda");
            //CarContainer c1 = new CarContainer(c);
            //c1.Car.Accelerate();
            //c1.Brake(); // this car knows how to break.

            //// Extension of Oriiginal class using Inheritance
            //ChildCar c2 = new ChildCar("Mazda");
            //c2.Accelerate();
            //c2.Brake(); // This car knows how to break too.

            // Extension of Oriiginal class using Extension Methods
            Car c3 = new Car("Mazda");
            c3.Accelerate();
            c3.BrakeAction(); // This car knows how to break too.

            Console.ReadLine();
        }
    }
}
