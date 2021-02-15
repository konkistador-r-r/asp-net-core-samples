using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.AcyclicVisitor
{
    interface IModemVisitor
    {
    }

    interface IHayesModemVisitor : IModemVisitor
    {
        void Visit(HayesModem modem);
    }

    interface IZoomModemVisitor : IModemVisitor
    {
        void Visit(ZoomModem modem);
    }

    interface IErnieModemVisitor : IModemVisitor
    {
        void Visit(ErnieModem modem);
    }

    interface INewModemVisitor : IModemVisitor
    {
        void Visit(NewModem modem);
    }
}
