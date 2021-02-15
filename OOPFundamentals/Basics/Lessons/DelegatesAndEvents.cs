using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lessons
{
    // delegate its a reference type. Use for giving you maximum flexibility to implement any functionality you want at runtime
    class DelegatesAndEvents
    {
        class Delegates
        {
            /* Delegate declarations look somewhat like methods, except they have the delegate modifier, 
             * are terminated with a semi-colon (;), and have no implementation. Delegate declaration defines 
             * the signature of a delegate handler method that this delegate can refer to. The delegate handler method,
             * for the Comparer delegate, can have any name, but must have a first parameter of type object, a second parameter of type object,
             * and return an int type.  */
            // this is the delegate declaration
            public delegate int Comparer(object obj1, object obj2);

            public class Name
            {
                public string FirstName = null;
                public string LastName = null;

                public Name(string first, string last)
                {
                    FirstName = first;
                    LastName = last;
                }
                // this is the delegate method handler
                public static int CompareFirstNames(object name1, object name2)
                {
                    string n1 = ((Name)name1).FirstName;
                    string n2 = ((Name)name2).FirstName;

                    if (String.Compare(n1, n2) > 0)
                    {
                        return 1;
                    }
                    if (String.Compare(n1, n2) < 0)
                    {
                        return -1;
                    }
                    return 0;
                }

                public static int CompareLastNames(object name1, object name2)
                {
                    string n1 = ((Name)name1).LastName;
                    string n2 = ((Name)name2).LastName;

                    if (String.Compare(n1, n2) > 0)
                    {
                        return 1;
                    }
                    if (String.Compare(n1, n2) < 0)
                    {
                        return -1;
                    }
                    return 0;
                }

                public override string ToString()
                {
                    return FirstName + " " + LastName;
                }

            }

            public class SimpleDelegate
            {
                Name[] _names = new Name[5];

                public SimpleDelegate()
                {
                    _names[0] = new Name("Joe", "Mayo");
                    _names[1] = new Name("John", "Hancock");
                    _names[2] = new Name("Jane", "Doe");
                    _names[3] = new Name("John", "Doe");
                    _names[4] = new Name("Jack", "Smith");
                }

                public void Sort(Comparer compare)
                {
                    object temp;

                    for (int i = 0; i < _names.Length; i++)
                    {
                        for (int j = i; j < _names.Length; j++)
                        {
                            // using delegate "compare" just like
                            // a normal method
                            if (compare(_names[i], _names[j]) > 0)
                            {
                                temp = _names[i];
                                _names[i] = _names[j];
                                _names[j] = (Name)temp;
                            }
                        }
                    }
                }

                public void PrintNames()
                {
                    Console.WriteLine("Names: \n");

                    foreach (Name name in _names)
                    {
                        Console.WriteLine(name.ToString());
                    }
                }

                public static void MainMethod()
                {
                    var sd = new SimpleDelegate();

                    //To use a delegate, you must create an instance of it. 
                    // this is the delegate instantiation
                    Comparer cmp = new Comparer(Name.CompareFirstNames);

                    Console.WriteLine("\nBefore Sort: \n");

                    sd.PrintNames();

                    // observe the delegate argument
                    sd.Sort(cmp);

                    Console.WriteLine("\nAfter Sort: \n");

                    sd.PrintNames();

                    /* The delegate, cmp, is then used as a parameter to the Sort() method, which uses it just like a normal method.
                     * Observe the way the delegate is passed to the Sort() method as a parameter in the code below.

                            sd.Sort(cmp);

                     * Using this technique, any delegate handler method may be passed to the Sort() method at run-time. i.e. 
                     * You could define a method handler named CompareLastNames(), instantiate a new Comparer delegate instance with it, 
                     * and pass the new delegate to the Sort() method.
                     */

                    cmp = new Comparer(Name.CompareLastNames);

                    Console.WriteLine("\nBefore Sort: \n");

                    sd.PrintNames();

                    // observe the delegate argument
                    sd.Sort(cmp);

                    Console.WriteLine("\nAfter Sort: \n");

                    sd.PrintNames();
                }
            }
        }

        /* A C# event is a class member that is activated whenever the event it was designed for occurs. 
         * When the event is activated. Anyone interested in the event can register and be notified as soon as the event fires. 
         * At the time an event fires, registered methods will be invoked.*/
        class Events
        {
            /* Events and delegates work hand-in-hand to provide a program's functionality. It starts with a class that declares an event. 
             * Any class, including the same class that the event is declared in, may register one of its methods for the event. This occurs through 
             * a delegate, which specifies the signature of the method that is registered for the event. The delegate may be one of the pre-defined 
             * .NET delegates or one you declare yourself. Whichever is appropriate, you assign the delegate to the event, which effectively registers 
             * the method that will be called when the event fires. */

            // custom delegate
            public delegate void Startdelegate();

            public class Eventdemo : Form
            {
                // the event declaration, which is a member of the Eventdemo class
                // custom event
                public event Startdelegate StartEvent;

                // this method is called when the "clickMe" button is pressed
                public void OnClickMeClicked(object sender, EventArgs ea)
                {
                    MessageBox.Show("You Clicked My Button!");
                }

                public void OnClickMeClicked2(object sender, EventArgs ea)
                {
                    MessageBox.Show("You Twice Clicked My Button!");
                }

                // this method is called when the "StartEvent" Event is fired
                public void OnStartEvent()
                {
                    MessageBox.Show("I Just Started!");
                }

                public void OnClosingEvent(object sender, EventArgs ea)
                {
                    MessageBox.Show("Bye my user!");
                }

                public Eventdemo()
                {
                    var clickMe = new Button()
                                      {
                                          Parent = this,
                                          Text = "Click Me",
                                          Width = 50,
                                          Height = 100,
                                          Location = new Point(
                                              (ClientSize.Width - Width) / 2,
                                              (ClientSize.Height - Height) / 2
                                          )
                                      };

                    //  an event can register by hooking up a delegate for that event.
                    // an EventHandler delegate is assigned
                    // to the button's Click event
                    clickMe.Click += new EventHandler(OnClickMeClicked); //  pre-defined events and delegates
                    clickMe.Click += new EventHandler(OnClickMeClicked); // Can  register delegate with link on already assigned method or
                    clickMe.Click -= new EventHandler(OnClickMeClicked); //  unregister it
                    clickMe.Click += new EventHandler(OnClickMeClicked2);
                    // our custom "Startdelegate" delegate is assigned
                    // to our custom "StartEvent" event.
                    StartEvent += new Startdelegate(OnStartEvent);
                    
                    Closed += OnClosingEvent;

                    // Firing an event looks just like a method call
                    // fire our custom event
                    StartEvent();
                }
            }
        }

        public static void MainMethod()
        {
            Delegates.SimpleDelegate.MainMethod();

            Application.Run(new Events.Eventdemo());

           
        }
    }
}
