using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFundamentals.Classes
{
    class Human
    {
        private string _name;
        protected string Name // Encapsulation
        {
            get { return _name; }
            set { _name = value + ", "; }
        }
        protected int Age { get; set; }
        protected Sex Hsex {get; set;}

        public enum Sex
        {
            Mail,
            Femail
        };

        public virtual void Go() { }
    

    }
}
