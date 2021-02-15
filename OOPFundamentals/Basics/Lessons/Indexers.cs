/* Indexers allow your class object to be used just like an array. On the inside of a class, 
 * you manage a collection of values any way you want. These objects could be a finite 
 * set of class members, another array, or some complex data structure. Regardless of the 
 * internal implementation of the class, its data can be obtained consistently through the use of indexers. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class Indexers
    {
        enum Numbers
        {
            Odd,
            Even
        }

        private string[] myNotes; // declare

        public Indexers(int size)
        {
            myNotes = new string[size]; // create

            // this section not mandatory
            for (int i = 0; i < size; i++)
            {
                myNotes[i] = "empty";
            }
        }

        // An indexer is also similar to a property.
        private string this[int pos]
        {
            get { return myNotes[pos]; }
            set { myNotes[pos] = value; }
        }

        public static void Display()
        {
            int size = 10;
            var myInd = new Indexers(size);

            myInd[9] = "Some Value";
            myInd[3] = "Another Value";
            myInd[5] = "Any Value";

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("myInd[{0}]: {1}", i, myInd[i]);
            }
        }


        class OvrIndexer
        {
            private string[] myData;
            private int arrSize;

            public OvrIndexer(int size)
            {
                arrSize = size;
                myData = new string[size];

                for (int i = 0; i < size; i++)
                {
                    myData[i] = "empty";
                }
            }

            public string this[int pos]
            {
                get
                {
                    return myData[pos];
                }
                set
                {
                    myData[pos] = value;
                }
            }

            public string this[string data]
            {
                get
                {
                    int count = 0;

                    for (int i = 0; i < arrSize; i++)
                    {
                        if (myData[i] == data)
                        {
                            count++;
                        }
                    }
                    return count.ToString();
                }
                set
                {
                    for (int i = 0; i < arrSize; i++)
                    {
                        if (myData[i] == data)
                        {
                            myData[i] = value;
                        }
                    }
                }
            }

            public int this[Numbers numberIs]
            { 
                get
                {
                    string value;
                    var count = 0;
                    for(var i = 0; i < arrSize;i++)
                    {
                        switch (numberIs)
                        {
                            case Numbers.Odd:
                                if (i % 2 != 0)
                                {
                                    count++;
                                    value = myData[i] + ";";
                                }
                                break;

                            case Numbers.Even:
                                if (i % 2 == 0)
                                {
                                    count++;
                                    value = myData[i] + ";";
                                }
                                break;
                        }
                    }
                    return count;
                }
            }

        }

        public static void Display2()
        {
            int size = 10;
            var myInd = new OvrIndexer(size);

            myInd[9] = "Some Value";
            myInd[3] = "Another Value";
            myInd[5] = "Any Value";

            myInd["empty"] = "no value";

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("myInd[{0}]: {1}", i, myInd[i]);
            }

            Console.WriteLine("\nNumber of \"no value\" entries: {0}", myInd["no value"]);

            Console.WriteLine("\nCount of ODD massive elements: {0}", myInd[Numbers.Odd]);
            Console.WriteLine("\nCount of Even massive elements: {0}", myInd[Numbers.Even]);
        }
    }
}
