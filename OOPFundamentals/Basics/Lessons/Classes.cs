using System;
using AliasForNamespace = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
   public class Classes
    {
        class OutputClass
        {
            //In C#, there are two types of class members, instance and static.
            string myString;
            public static int _count;
            private static int _myNumber;

            public OutputClass() : this("Default")
            {
                
            }
            // Every class has a constructor, which is called automatically any time an instance of a class is created. 
            // The purpose of constructors is to initialize class members when an instance of the class is created.
            // Constructor do not have return values and always have the same name as the class.  
            public OutputClass(string inputString)
            {
                AliasForNamespace.Console.WriteLine("Constructor of OutputClass have been runing");
                myString = inputString;
            }

            /* Use static constructor to initialize static fields in a class. 
             * A static constructor is called before an instance of a class is created.
             * They are called only once. */
            static OutputClass()
            {
                _count = 0;
            }

            public OutputClass(int myNumber)
            {
                _myNumber = myNumber;
            }

            // Instance Method
            public void printString()
            {
                AliasForNamespace.Console.WriteLine("{0}", myString);
            }

            // Destructor
            //Destructors are places where you could put code to release any resources your class was holding 
            //during its lifetime. 
            ~OutputClass()
            {
                AliasForNamespace.Console.WriteLine("Destructor of OutputClass have been runing");
            }
        }

        public static void ExampleClass()
        {
            // Instance of OutputClass
            var outCl = new OutputClass("This is printed by the output class.");
            var outC2 = new OutputClass(5);
            var outC3 = new OutputClass();


            // Call Output class' method
            outCl.printString();
            outC2.printString();
            outC3.printString();

            // Call static field that previously inicializated by static constructor
            AliasForNamespace.Console.WriteLine(OutputClass._count);

            // AliasForNamespace.GC.Collect(); // Why GC not work because link on object exist because object in method scope
        }
   }

   /* It is possible to split the definition of a class or a struct, or an interface over two or more source files. 
    * Each source file contains a section of the class definition, and all parts are combined when the application is compiled. */
   partial class ClassModifiers
   {
       public string Name = "ClassModifiers";
   }

    partial class ClassModifiers
    {
        public string Name1 = "ClassModifiers";
    }

}

namespace NewNamespace
{
    // In this scope class modifiers private, protected are prohibited
    sealed public class ClassModifiers1
    {
        public string Name1 = "ClassModifiers";

        // In this scope method modifiers virtual are prohibited, protected = private, new is redundant
        protected void HidedMethod()
        {

        }

        private void Method1()
        {

        }

        public void Method2()
        {

        }
    }

    // Inheritance from sealed class is impossible
    class MakeInstanceOfSealedClass// : ClassModifiers1
    {
        private ClassModifiers1 _classModifiers1 = new ClassModifiers1();
    }

    abstract class ClassModifiers2
    {
        public string Name1 = "ClassModifiers";
        public static int i = 0;

        // 4. In abstract classes non-abstract methods must has a body
        protected void HidedMethod()
        {
            Console.WriteLine("non-abstract method");
        }

        protected virtual void VirtualMethod()
        {
            Console.WriteLine("VirtualMethod method");
        }
    }
    // Class cannot be both abstract and sealed
    abstract class ClassAbstract : ClassModifiers2 // or ClassModifiers1 if it not sealed. 
    {
        // 1.field cannot be abstract
        private string _name = "ClassModifiers";

        // 2. Porperty can be abstract
        abstract public string Name { get; set; }

        // 3. Method can be abstract. Abstract method cannot declare a body
        internal abstract void ClaerMethod();
        public abstract void ClaerMethod1();
        protected abstract void ClaerMethod2();
        // abstract method cannot be private. Private method cannot be polymorphic
        // private abstract void ClaerMethod3();

        // Method That Hide can be internal, public, protected, private 
        public new abstract void HidedMethod();

        // Method That Override cannot change access rights such as 
        protected override void VirtualMethod()
        {
            Console.WriteLine("VirtualMethod method");
        }
    }

    // Derived class from abstract class must implement all abstract Porperty, Method, ...
    class MyClass : ClassAbstract
    {
        // Creation of instamce of abstract class is impossible
        //private ClassAbstract _classAbstract = new ClassAbstract();

        public override string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        internal override void ClaerMethod()
        {
            throw new NotImplementedException();
        }

        public override void ClaerMethod1()
        {
            throw new NotImplementedException();
        }

        protected override void ClaerMethod2()
        {
            throw new NotImplementedException();
        }

        public override void HidedMethod()
        {
            throw new NotImplementedException();
        }

        public void AccessToNonAbstractElem()
        {
            base.VirtualMethod();
        }
    }
}

namespace HiddingNamespace
{
    class MyClass
    {
        // If MethodWhichHides is private than nothing to hide in derived class
        protected void HidedMethod()
        {
            Console.WriteLine("Method Which Hides");
        }

        protected void HidedMethod(string str)
        {
            Console.WriteLine("Method Which Hides with parameter");
        }

        protected virtual void VirtualMethod()
        {
            Console.WriteLine("VirtualMethod method");
        }
    }

    abstract class MyClass1 : MyClass
    {
        // MethodThatHide can be internal, public, protected, private, 
        public new abstract void HidedMethod();

        public new void HidedMethod(string str)
        {
            Console.WriteLine("Method Which Hides with parameter");
            Console.WriteLine(str);
        }

        protected new virtual void VirtualMethod()
        {
            Console.WriteLine("VirtualMethod method");
        }

    }

    // You cannot derive from static class
    public static class GlobalStaticFunc
    {
        private static int i = 7;
        //public GlobalStaticFunc() { } // Static classes cannot have instance constructors

        static GlobalStaticFunc() // access modifiers are not allowed on static constructors
        {
        }

        //public int CurrentDate() { } // non-static members cannot declared in a static class	

    }



    abstract class Parent
    {
        protected abstract int Method1();// virtual or abstract members cannot be private

        public abstract int Method2();
    }

    abstract class ChildAbstract : Parent
    {
        protected override int Method1()
        {
            return int.MinValue;
        }
    }

    class ChildClass : Parent
    {
        protected override int Method1()
        {
            return int.MinValue;
        }

        public override int Method2()
        {
            throw new NotImplementedException();
        }
    }
}
