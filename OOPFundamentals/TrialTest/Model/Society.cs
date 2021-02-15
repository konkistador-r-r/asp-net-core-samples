using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrialTest.Interface;

namespace TrialTest.Model
{
    [Flags] // Value type
    public enum Relations 
    {
        Mother = 0x0,        //From 16 to 2:    //                          | 0000
        Father = 0x1,                           //                          | 0001
        Daughter = 0x2,                         //                          | 0010
        Son = 0x4,                              //                          | 0100
        Sister = 0x8,                           //                          | 1000
        Brother = 0x10,                         //                        1 | 0000
        Husband = 0x20,                         //     2 | 0 =>          10 | 0000
        Wife = 0x40,                            //     4 | 0 =>         100 | 0000
        Girlfriend = 0x80,                      // 0 | 8 | 0 => 0000 | 1000 | 0000
        Boyfriend = 0x100                       // 1 | 0 | 0 => 0001 | 0000 | 0000
    }


    internal class SocialAttitude : Attribute     // Attribute[5]
    {
        public Relations Couple { get; set; }
        public Relations Married { get; set; }
    }

    // Attribute[5], Inheritance [2], interface [4]
    [SocialAttitude(Couple = Relations.Girlfriend | Relations.Boyfriend, Married = Relations.Husband | Relations.Wife)]
    class Society<THuman> : Human, IAdult where THuman : Human                 // Generics [7]
    {
        public Society(THuman human) : base(human.Name, human.Age, Sex.Female, human.Id)
        {

        } // Inheritance [2]

        public override void Walk()
        {
            Console.WriteLine("Adult: {0}, walks", Name);
        } // Polymorphism [3]

        public event Money GiveMoney; // Event [6]
        public decimal InvokeGiveMoney(Human person1, Human person2, Relations relation, decimal sum)
        {
            Money handler = GiveMoney;
            return handler(person1, person2, relation, sum);
        } // Event [6]

        public void Work()
        {
            Console.WriteLine("Adult: {0}, works", Name);
        } // Interface [4]

        public decimal GiveMoneyFor(Human parent, Human child, Relations relation, decimal sum)
        {
            if (parent.Relationships[relation.ToString()] == child.Id)
            {
                switch (child.Age < 15)
                {
                    case true:
                        return decimal.Parse(parent.Age.ToString());

                    case false:
                        return sum;
                    default:
                        return decimal.Zero;
                }
            }
            return decimal.Zero;
        } // Event [6], Interface [4]

        public static void GroupWalking(List<THuman> humans)
        {
            humans.ForEach(h=>h.Walk());
        } // Polymorphism [3]

        public static Society<THuman> InTouch(THuman human, int adultAge)
        {
            return human.Age >= adultAge ? new Society<THuman>(human) : null;
        } // Work with classes

        public static bool GetMarried(THuman pearson1, THuman pearson2)
        {
            bool canMarry1 = false;
            bool canMarry2 = false;
            var relationships1 = new Relations();
            var relationships2 = new Relations();
            
            // Read Attribute [5]
            Type p1 = pearson1.GetType();
            var attributes1 = p1.GetCustomAttributes(typeof(SocialAttitude), true);
            foreach (SocialAttitude attribute in attributes1)
            {
                relationships1 = attribute.Couple;
            }

            Type p2 = pearson2.GetType();
            var attributes2 = p2.GetCustomAttributes(true);
            foreach (SocialAttitude attribute in attributes2)
            {
                relationships2 = attribute.Couple;
            }

            // If they meaning about couple identical
            if (!relationships1.Equals(relationships2)) 
                return false;

            foreach (String r in pearson1.Relationships.Keys)
            {
                if (relationships1.HasFlag((Relations)Enum.Parse(typeof(Relations), r)))
                {
                    if (pearson1.Relationships[r] == pearson2.Id)
                    {
                        canMarry1 = true;
                    }
                }
            }

            foreach (String r in pearson2.Relationships.Keys)
            {
                if (relationships1.HasFlag((Relations)Enum.Parse(typeof(Relations), r)))
                {
                    if (pearson2.Relationships[r] == pearson1.Id)
                    {
                        canMarry2 = true;
                    }
                }
            }

            return canMarry1 & canMarry2;
        }
    }
}