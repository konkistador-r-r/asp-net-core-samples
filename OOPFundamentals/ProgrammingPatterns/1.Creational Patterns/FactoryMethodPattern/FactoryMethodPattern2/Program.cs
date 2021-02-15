using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualConstructorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var creators = new Creator[2];
            creators[0] = new ManagerConreteCreator();
            creators[1] = new ProgrammerConreteCreator();

            foreach (var creator in creators)
            {
                var product = creator.FactoryMethod();
                product.Status();
                product.Salary();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            Console.Read();
        }
    }
}
