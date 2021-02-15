using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrialTest2.DAL;

namespace TrialTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataStore();
            var context = new DataAccess(db);
            var fathers = context.GetAllFathers();
            var mothers = context.GetAllMothers();
            var daughters = context.GetAllFDaughters();

            Console.WriteLine(Environment.NewLine + "Mothers");
            foreach (Mother mother in mothers)
            {
                Console.WriteLine(mother.Name +"`s daughter:" + mother.Daughter.Name);
            }

            Console.WriteLine(Environment.NewLine + "Fathers");
            foreach (Father father in fathers)
            {
                Console.WriteLine(father.Name + "`s daughter:" + father.Daughter.Name);
            }

            Console.WriteLine(Environment.NewLine + "Daughters");
            foreach (Daughter daughter in daughters)
            {
                Console.WriteLine(daughter.Name + "`s father:" 
                    + context.GetFather(daughter.FatherId).Name
                    + " and mother:" + context.GetMother(daughter.MotherId).Name);
            }

            var m = new Mother("Lulu Lapasaman", 30, Sex.Female);
            context.AddMother(m);

            Console.ReadLine();
        }
    }
}
