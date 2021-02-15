using System;
using System.Collections.Generic;
using System.Text;

namespace NullObjectPatterntTest
{
    public class DB
    {
        public static Employee GetEmployee(string s)
        {
            return Employee.NULL;
        }
    }
}
