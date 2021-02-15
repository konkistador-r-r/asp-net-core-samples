using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.Visitor
{
    interface IModemVisitor
    {
        void Visit(HayesModem modem);
        void Visit(ZoomModem modem);
        void Visit(ErnieModem modem);
        void Visit(NewModem modem);
    }
}
