using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrialTest.Model;

namespace TrialTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generics [7], Inheritance [2]
            // Create objects
            var mother = new Society<Human>(new Human("Mary", 30, Sex.Female));
            var father = new Society<Human>(new Human("Alex", 35, Sex.Male));
            var daughter = new Child("Ann", 15, Sex.Female);
            var boyfriend = new Child("Jack", 20, Sex.Male);

            // Objects relations [0]
            mother.Relationships[Relations.Daughter.ToString()] = daughter.Id;
            father.Relationships[Relations.Daughter.ToString()] = daughter.Id;
            daughter.Relationships[Relations.Mother.ToString()] = mother.Id;
            daughter.Relationships[Relations.Father.ToString()] = father.Id;

            // Father is responsible for daugter money needs
            daughter.NeedMoney += new Human.Money(father.GiveMoneyFor);     // Event [6]

            // When Daughter asks father for money - he gives her
            decimal need = 100.00M;
            var givedMoney = daughter.InvokeNeedMoney(father, Relations.Daughter, need);    // Event [6]
            // But father give her money rely on old rule
            if (givedMoney != decimal.Zero)
            {
                Console.WriteLine("father gives daughter {0}", givedMoney);
            }

            Society<Human>.GroupWalking(new List<Human>(){ mother, father, daughter });   // Polymorphism [3]

            // Child growth and become at full in touch with society
            var adultDaughter = Society<Human>.InTouch(daughter, 15);                   // Work with classes
            var adultBoyfriend = Society<Human>.InTouch(boyfriend, 15);

            // New adult relations
            adultDaughter.Relationships[Relations.Boyfriend.ToString()] = adultBoyfriend.Id;    // Attribute[5]
            adultBoyfriend.Relationships[Relations.Girlfriend.ToString()] = adultDaughter.Id;

            var theyMarry = Society<Human>.GetMarried(adultDaughter, adultBoyfriend);           // Attribute[5]
            Console.WriteLine("They " + (theyMarry ? "have" : "have not") + " been married");

            adultDaughter.Relationships[Relations.Husband.ToString()] = adultBoyfriend.Id;      // Attribute[5]
            adultBoyfriend.Relationships[Relations.Wife.ToString()] = adultDaughter.Id;

            // Requirement
            //Daughter can`t worh :  daughter.Work
            mother.Work();
            father.Work();
            adultDaughter.Work();

            Console.ReadLine();
        }
    }
}
