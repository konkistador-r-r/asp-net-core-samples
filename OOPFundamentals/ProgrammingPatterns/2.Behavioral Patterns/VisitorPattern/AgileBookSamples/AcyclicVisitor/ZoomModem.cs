using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.AcyclicVisitor
{
    class ZoomModem : IModem
    {
        public int Configuration;
        public ZoomModem() { Configuration = 0; }
        public bool Dial(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool Hangup()
        {
            throw new NotImplementedException();
        }

        public char Receive()
        {
            return (char)0;
        }

        public void Send(char c)
        {
            throw new NotImplementedException();
        }

        public void Accept(IModemVisitor funcExteder)
        {
            if (funcExteder is IZoomModemVisitor)
                (funcExteder as IZoomModemVisitor).Visit(this);
        }
    }
}
