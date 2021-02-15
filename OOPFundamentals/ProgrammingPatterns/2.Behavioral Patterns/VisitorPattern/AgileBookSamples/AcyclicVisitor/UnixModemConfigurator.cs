using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.AcyclicVisitor
{
    class UnixModemConfigurator : IHayesModemVisitor, IZoomModemVisitor, IErnieModemVisitor, INewModemVisitor
    {
        public void Visit(HayesModem modem)
        {
            modem.Configuration = 0.45;
        }

        public void Visit(ZoomModem modem)
        {
            modem.Configuration = 2;
        }

        public void Visit(ErnieModem modem)
        {
            modem.Configuration = "&s1=4&D=3";
        }

        public void Visit(NewModem modem)
        {
            dynamic obj = new System.Dynamic.ExpandoObject();
            obj.Data = "5";
            modem.Configuration = obj;
        }
    }
}
