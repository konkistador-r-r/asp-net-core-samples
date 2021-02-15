using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFundamentals.Patterns
{
    public sealed class Singleton
    {
        private static Singleton _singleton;
        public static Singleton GetSingleton
        {
            get { return _singleton ?? (_singleton = new Singleton()); }
        }


        public string _name;

        private Singleton()
        {
            _name = "Pattern Name: Singleton";
        }
    }
}
