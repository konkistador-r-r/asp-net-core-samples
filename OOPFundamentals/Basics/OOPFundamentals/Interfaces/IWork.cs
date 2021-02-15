using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFundamentals.Interfaces
{
    interface IWork
    {
        bool Busy { get; set; }
        void Work();
    }
}
