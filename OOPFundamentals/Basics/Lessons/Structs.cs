/* A struct is a value type. To help understand the struct, it's helpful to make a comparison with classes. 
 * While a struct is a value type, a class is a reference type. Value types hold their value in memory where they are declared, 
 * but reference types hold a reference to an object in memory. If you copy a struct, C# creates a new copy of the object
 * and assigns the copy of the object to a separate struct instance. However, if you copy a class, C# creates a new copy of the reference
 * to the object and assigns the copy of the reference to the separate class instance. Structs can't have destructors, but classes can have destructors. 
 * Another difference between a struct and class is that a struct can't have implementation inheritance, but a class can.
 * Although a struct can't have implementation inheritance, it can have interface inheritance */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class Structs
    {
        // Defining a struct
        struct RectangleStruct
        {
            private string _structAnchor;// = String.Empty; // Struct cannot have instance field initializers
            //private int f = 5;
            //public readonly int Idd = 345;

            public const int Id = 345;
            public static int StaticField = 345;
            

            private int m_width;
            public int Width
            {
                get
                {
                    return m_width;
                }
                set
                {
                    m_width = value;
                }
            }
            
            private int m_height;
            public int Height
            {
                get
                {
                    return m_height;
                }
                set
                {
                    m_height = value;
                }
            }

            // public RectangleStruct() {} // Structs cannot contain explicit parameterless constructors


            // Overloading struct Constructors
            /* The default constructor is implicitly defined by C# and you can't implement the default constructor yourself.  
             * The default constructor initializes all struct fields to default values. i.e. integrals are 0, floating points are 0.0, 
             * and booleans are false. If you need custom constructor overloads, you can add new constructors, as long as they have one or more parameters. */
            
            // If overloaded constructor declared, here shoul inizialized all fields insted of some like in class realization.
            public RectangleStruct(int width, int height, string structAnchor)
            {
                m_width = width;
                m_height = height;
                _structAnchor = structAnchor;
            }

            // Adding a Method to a struct
            public RectangleStruct Add(RectangleStruct rect)
            {
                // create instance of rectangle struct with default constructor
                var newRect = new RectangleStruct();

                // add matching axes and assign to new Rectangle struct
                newRect.Width = Width + rect.Width; 
                newRect.Height = Height + rect.Height;

                // return new Rectangle struct
                return newRect;
            }

        }

        class RectangleClass
        {
            private string _classAnchor;

            public RectangleClass(string classAnchor)
            {
                _classAnchor = classAnchor;
            }
            public int Width { get; set; }

            public int Height { get; set; }
        }

        public static void AccessToStructs()
        {
            // Using a Struct
            var rectangleStruct = new RectangleStruct(11, 33, "RectangleStruct") { Width = 1, Height = 3, };
            var rectangleStruct2 = new RectangleStruct { Width = 1, Height = 3, };
            Console.WriteLine("rectangleStruct: {0}:{1}", rectangleStruct.Width, rectangleStruct.Height);

            
            
            // Calling a struct Method
            var rectangleStruct3 = rectangleStruct.Add(rectangleStruct2);
            Console.WriteLine("rectangleStruct: {0}:{1}", rectangleStruct3.Width, rectangleStruct3.Height);

            var rectangleClass = new RectangleClass("RectangleClass") { Width = 1, Height = 3, };
            Console.WriteLine("rectangleClass: {0}:{1}", rectangleClass.Width, rectangleClass.Height);
        }
    }
}
