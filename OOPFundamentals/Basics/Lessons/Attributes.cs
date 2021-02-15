/* Attributes are C# language elements that decorate program elements with additional metadata that describes the program. 
 * This metadata is then evaluated at different places, such as runtime or design time for various purposes. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
// Attribute targets are specified by prefixing the attribute name with the target and separating it with a colon (:)
[assembly: CLSCompliant(true)] // An attribute that helps ensure assemblies adhere to the Common Language Specification (CLS)

namespace Lessons
{
    class Attributes
    {
        /* generate a compiler warning because of the uint type parameter declared on the NonClsCompliantMethod() method. 
         * If you change the CLSCompliantAttribute attribute to false or change the type of the NonClsCompliantMethod() 
         * method to a CLS compliant type, such as int, the program will compile without warnings:
         CLS compliance checking will not be performed on 'Lessons.Attributes.NonClsCompliantMethod(uint)' because it is not visible 
         * from outside this assembly */
        [CLSCompliant(true)]
        public static void NonClsCompliantMethod(uint nclsParam)
        {
            Console.WriteLine("Called NonClsCompliantMethod().");
        }

        [Obsolete]
        public void MyFirstdeprecatedMethod()
        {
            Console.WriteLine("Called MyFirstdeprecatedMethod().");
        }

        [ObsoleteAttribute]
        public void MySecondDeprecatedMethod()
        {
            Console.WriteLine("Called MySecondDeprecatedMethod().");
        }

        //[Obsolete("You shouldn't use this method anymore.", true)] - error occurs
        [Obsolete("You shouldn't use this method anymore.")]      // - warning occurs
        public void MyThirdDeprecatedMethod()
        {
            Console.WriteLine("Called MyThirdDeprecatedMethod().");
        }

        // There are two types of parameters that can be used on attributes, positional and named.
        // Positional parameters are used when the attribute creator wishes the parameters to be required.
        // The DllImportAttribute attribute has one positional parameter, "User32.dll", and one named parameter, EntryPoint="MessageBox".
        // Positional parameters are always specified before any named parameters. When there are named parameters, they may appear in any order.
        [DllImport("User32.dll", EntryPoint = "MessageBox")]
        static extern int MessageDialog(int hWnd, string msg, string caption, int msgType);

        // make the program thread safe for COM
        [STAThread]
        public static void MainMethod()
        {
            uint myUint = 0;
            NonClsCompliantMethod(myUint);

            Attributes attrDemo = new Attributes();

            attrDemo.MyFirstdeprecatedMethod();
            attrDemo.MySecondDeprecatedMethod();
            attrDemo.MyThirdDeprecatedMethod();

            MessageDialog(0, "MessageDialog Called!", "DllImport Demo", 0);
        }
    }
}


/*
 
    Attribute Target	  Can be Applied To
            all	            everything
            assembly	    entire assembly
            class	        classes
            constructor	    constructors
            delegate	    delegates
            enum	        enums
            event	        events
            field	        fields
            interface	    interfaces
            method	        methods
            module	        modules (compiled code that can be part of an assembly)
            parameter	    parameters
            property	    properties
            returnvalue	    return values
            struct          structures
 
 */