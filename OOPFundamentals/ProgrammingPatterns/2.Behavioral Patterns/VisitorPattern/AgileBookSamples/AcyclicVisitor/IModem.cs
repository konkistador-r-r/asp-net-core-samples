using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.AcyclicVisitor
{
    interface IModem
    {
        bool Dial(string phoneNumber);
        void Send(char c);
        char Receive();
        bool Hangup();

        void Accept(IModemVisitor funcExteder);
    }
}
