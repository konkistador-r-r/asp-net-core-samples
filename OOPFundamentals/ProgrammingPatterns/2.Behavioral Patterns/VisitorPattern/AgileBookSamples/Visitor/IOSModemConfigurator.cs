using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.Visitor
{
    class IOSModemConfigurator : IModemVisitor
    {
        public void Visit(HayesModem modem)
        {
            modem.Configuration = 1.45;
        }

        public void Visit(ZoomModem modem)
        {
            modem.Configuration = 22;
        }

        public void Visit(ErnieModem modem)
        {
            modem.Configuration = "&s4=4&D=8";
        }

        public void Visit(NewModem modem)
        {
            dynamic obj = new System.Dynamic.ExpandoObject();
            obj.Data = 10;
            modem.Configuration = obj;
        }
    }
}
