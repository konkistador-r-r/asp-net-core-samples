using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DelayedTyper
{
    public class ActiveObjectEngine
    {
        ArrayList itsCommands = new ArrayList();

        public void AddCommand(Command c) {
            itsCommands.Add(c);
        }

        public void Run() {
            while (itsCommands.Count > 0) {
                Command c = (Command)itsCommands[0];
                itsCommands.RemoveAt(0);
                c.Execute();
            }
        }
    }
}
