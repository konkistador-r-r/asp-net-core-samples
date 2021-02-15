using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrialTest.Model;

namespace TrialTest.Interface
{
    public interface IAdult
    {
        event Human.Money GiveMoney;    // Event [6]
        void Work();                    // Interface [4]
        decimal GiveMoneyFor(Human parent, Human child, Relations relation, decimal sum); // Interface [4]
    }
}
