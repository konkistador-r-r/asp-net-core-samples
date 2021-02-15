/*
 * Summary
 * 
 * Polymorphism  allows you to invoke derived class methods through a base class reference during run-time.
 * This is handy when you need to assign a group of objects to an array and then invoke each of their methods. 
 * They won't necessarily have to be the same object type. However, if they're related by inheritance, you can 
 * add them to the array as the inherited type. Then if they all share the same method name, that method of each object can be invoked. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//  This relationship between virtual methods and the derived class methods that override them enables polymorphism. 
namespace Lessons
{
    class Polymorphism /* allows you to invoke derived class methods through a base class reference during run-time.
                        * This is handy when you need to assign a group of objects to an array and then invoke each 
                        * of their methods. They won't necessarily have to be the same object type. However, if they're 
                        * related by inheritance, you can add them to the array as the inherited type. Then if they all share 
                        * the same method name, that method of each object can be invoked. */
    {
        private class DrawingObject
        {
            public virtual void Draw() // The virtual modifier indicates to derived classes that they can override this method but not have to!
            {
                Console.WriteLine("I'm just a generic drawing object.");
            }
        }

        private class Line1 : DrawingObject
        {
            public new void Draw() // IF metod hided, or just implement virtual metod of base class with same parametrs 
            {                      // then line object invoke method Draw() like ((DrawingObject)line).Draw() and it`s invoke base class method
                Console.WriteLine("I'm a Line1.");
            }
        }

        private class Line2 : DrawingObject // if derived class do not override the base class virtual method it method will be called
        {
            protected internal void Draw() 
            {
                Console.WriteLine("I'm a Line2.");
            }
        }

        private class Circle : DrawingObject
        {
            public override void Draw() // The override will happen only if a class refers to a base class reference. 
            {
                Console.WriteLine("I'm a Circle.");
            }
        }

        private class Square : DrawingObject // Overriding methods must have the same signature, name and parameters, as the virtual base class method it is overriding.
        {
            public override void Draw()
            {
                Console.WriteLine("I'm a Square.");
            }
        }

        public static void DrawDemo()
        {

            DrawingObject[] dObj = new DrawingObject[5];

            dObj[0] = new Line1();
            dObj[1] = new Line2();
            dObj[2] = new Circle();
            dObj[3] = new Square();
            dObj[4] = new DrawingObject();
            
            foreach (DrawingObject drawObj in dObj)
            {
                drawObj.Draw();
            }

            var line1 = new Line1(); // if modifier isn`t be like in base e.g. class method as "protected void Draw()"  CLR calling base class method Draw
            line1.Draw();
            var line2 = new Line2(); // but if modifier declared as protected internal CLR calling derived class method Draw
            line2.Draw();
            var circle = new Circle();
            circle.Draw();
        }
    }
}
