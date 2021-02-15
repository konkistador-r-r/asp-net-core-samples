using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.AcyclicVisitor
{
    class ErnieModem : IModem
    {
        public string Configuration;
        public ErnieModem() { Configuration = string.Empty; }
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
            if (funcExteder is IErnieModemVisitor)
                (funcExteder as IErnieModemVisitor).Visit(this);
        }
    }
}
