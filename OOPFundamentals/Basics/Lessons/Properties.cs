/* Traditional Encapsulation Without Properties
 * Languages that don't have properties will use methods (functions or procedures) for encapsulation. 
 * The idea is to manage the values inside of the object, state, avoiding corruption and misuse by calling code. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class Properties //Properties provide the opportunity to protect a field in a class by reading and writing to it through the property
    {
        private class Customer
        {
            private int m_id = -1;
            public int GetID()
            {
                return m_id;
            }

            public void SetID(int id)
            {
                m_id = id;
            }

            private string m_name = string.Empty;
            public string GetName()
            {
                return m_name;
            }

            public void SetName(string name)
            {
                m_name = name;
            }
        }

        public static void CustomerManagerWithAccessorMethods()
        {
            Customer cust = new Customer();

            cust.SetID(1);
            cust.SetName("Hulio Lopez");

            Console.WriteLine("ID: {0}, Name: {1}", cust.GetID(), cust.GetName());
        }

        /* Encapsulating Type State with Properties
         * The practice of accessing field data via methods was good because it supported the object-oriented concept 
         * of encapsulation. For example, if the type of m_id or m_name changed from an int type to byte, calling code
         * would still work. Now the same thing can be accomplished in a much smoother fashion with properties */
        public class Customer2
        {
            private int m_id = -1;
            // Auto-Implemented Properties or short form
            // public int ID { get; } // Type can be changed later to  public byte/double/long ID { get; set; }
            public string Name { get; set; }
            //private int m_id = -1;

            public Customer2(int id, string name)
            {
                m_id = id;
                Name = name;
            }
            // wide form
            public int ID
            {
                get // Properties can be made read-only. This is accomplished by having only a get accessor
                // for write-only properties create only set accessor
                {
                    return m_id;
                }
            }

            //private string m_name = string.Empty;
            //public string Name
            //{
            //    get
            //    {
            //        return m_name;
            //    }
            //    set
            //    {
            //        m_name = value;
            //    }
            //}
        }

        public static void CustomerManagerWithProperties()
        {
            var cust = new Customer2(1, "Amelio Rosales");
            //cust.ID = 2; // Error Property or indexer cannot be assigned to -- it is read only
            Console.WriteLine("ID: {0}, Name: {1}", cust.ID, cust.Name);
        }

    }
}
