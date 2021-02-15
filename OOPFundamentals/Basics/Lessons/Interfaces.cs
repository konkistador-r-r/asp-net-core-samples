using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    /* The only thing it contains are declarations of events, indexers, methods and/or properties. Cannot contains field
     * The reason interfaces only provide declarations is because they are inherited by classes and structs, 
     * which must provide an implementation for each interface member declared. */
    // the interface only specifies the signature of methods that an inheriting class or struct must implement.
    
    delegate void Notifier();
    interface IInterfaces
    {
        //string someField = 25; - Cannot contains field
        int Numbers { get; set; }
        void MethodToImplement();
        void ParentInterfaceMethod();
        event Notifier notifier;
    }

    

    // Interfaces may also inherit other interfaces. 
    interface IDerivedFromIInterfaces : IInterfaces
    {
        //public static int i = 0; // interfaice can`t contain fields
        new void MethodToImplement(); // What Reason
    }

    interface IInterfaces2
    {
        void MethodToImplement(); // Why no error
    }

    class InterfaceImplementer : IDerivedFromIInterfaces, IInterfaces2
    {
        private InterfaceImplementer()
        {
            notifier+=new Notifier(InterfaceImplementer_notifier);
        }

        private void InterfaceImplementer_notifier()
        {
            Console.WriteLine("notifier event was fired");
        }

        public event Notifier notifier;

        public int Numbers
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void MethodToImplement()
        {
            Console.WriteLine("MethodToImplement() called.");
        }

        public void ParentInterfaceMethod()
        {
            Console.WriteLine("ParentInterfaceMethod() called.");
            notifier();
        }

       
        public static void MainMethod()
        {
            var iImp = new InterfaceImplementer();
            iImp.MethodToImplement();
            iImp.ParentInterfaceMethod();
        }
    }

    
}
