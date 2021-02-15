using NUnit.Framework;
using System;

namespace NullObjectPatterntTest
{
    public class Tests
    {
        [Test]
        public void TestNull()
        {
            Employee e = DB.GetEmployee("Bob");
            if (e.IsTimeToPay(new DateTime()))
                Assert.Fail();
            Assert.AreSame(Employee.NULL, e);
        }
    }
}