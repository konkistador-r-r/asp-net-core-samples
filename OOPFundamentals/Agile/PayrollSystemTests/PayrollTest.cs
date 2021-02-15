using NUnit.Framework;
using PayrollSystem;
using System;

namespace Tests
{
    public class PayrollTest
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Add/Delete Employee transactions
        [Test]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule); // paid on the last working day of the month

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestAddCommissionedEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 1000.00, 15);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is ComissinedClassification);

            ComissinedClassification cc = pc as ComissinedClassification;
            Assert.AreEqual(1000.00, cc.Salary, .001);
            Assert.AreEqual(15, cc.ComissionRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule); // They are paid every other Friday

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestAddHourlyEmployee()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 13.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification cc = pc as HourlyClassification;
            Assert.AreEqual(13.00, cc.HourlyRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule); // They are paid every Friday.

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void DeleteEmployee()
        {
            int empId = 4;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500, 3.2);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();

            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);
        }
        #endregion

        #region Using of TimeCard, SalesReceipt, ServiceCharge
        [Test]
        public void TestTimeCardTransaction()
        {
            int empId = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            TimeCardTransaction tct = new TimeCardTransaction(new DateTime(2005, 7, 31), 8.0, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            TimeCard tc = hc.GetTimeCard(new DateTime(2005, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }

        [Test]
        public void TestSalesReceiptTransaction()
        {
            int empId = 5;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 1000.00, 15);
            t.Execute();

            SalesReceiptTransaction tct = new SalesReceiptTransaction(new DateTime(2005, 7, 31), 200.0, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is ComissinedClassification);

            ComissinedClassification hc = pc as ComissinedClassification;
            SalesReceipt tc = hc.GetSalesReceipt(new DateTime(2005, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(200.0, tc.Amount);
        }

        [Test]
        public void AddServiceCharge()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            int memberId = 86; // Maxwell Smart
            UnionAffiliation af = new UnionAffiliation(memberId, 99.42);
            e.Affiliation = af;            
            PayrollDatabase.AddUnionMember(memberId, e);

            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, new DateTime(2005, 8, 8), 12.95);
            sct.Execute();

            ServiceCharge sc = af.GetServiceCharges(memberId, new DateTime(2005, 8, 8));
            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Charge, .001);
        }
        #endregion

        #region Change Employee transactions
        [Test]
        public void TestChangeNameTransaction()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob");
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }

        public void TestChangeAddressNameTransaction()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeAddressTransaction cnt = new ChangeAddressTransaction(empId, "Office");
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Office", e.Address
);
        }
        #endregion

        #region Change Payment Classification transactions
        [Test]
        public void TestChangeHourlyTransaction()
        {
            int empId = 3;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Lance", "Home", 2500, 3.2);
            t.Execute();

            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(empId, 27.52);
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(27.52, hc.HourlyRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [Test]
        public void TestChangeSalariedTransaction()
        {
            int empId = 3;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Lance", "Home", 2500, 10);
            t.Execute();

            ChangeSalariedTransaction cht = new ChangeSalariedTransaction(empId, 3000);
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification hc = pc as SalariedClassification;
            Assert.AreEqual(3000, hc.Salary, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
        }

        [Test]
        public void TestChangeCommissionedTransaction()
        {
            int empId = 3;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Lance", "Home", 2500);
            t.Execute();

            ChangeCommissionedTransaction cht = new ChangeCommissionedTransaction(empId, 3000, 20);
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is ComissinedClassification);

            ComissinedClassification hc = pc as ComissinedClassification;
            Assert.AreEqual(3000, hc.Salary, .001);
            Assert.AreEqual(20, hc.ComissionRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
        }
        #endregion

        #region Change Payment Method transactions
        [Test]
        public void TestChangeDirectTransaction()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            ChangeDirectTransaction cht = new ChangeDirectTransaction(empId, "bank123", "account123");
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is DirectMethod);
        }

        [Test]
        public void TestChangeMailTransaction()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            ChangeMailTransaction cht = new ChangeMailTransaction(empId, "address123");
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is MailMethod);
        }

        [Test]
        public void TestChangeHoldTransaction()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            ITransaction cht = new ChangeMailTransaction(empId, "address123");
            cht.Execute();

            cht = new ChangeHoldTransaction(empId);
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
        #endregion

        #region ChangeUnionMember
        [Test]
        public void AddMembership()
        {
            int empId = 8;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            int memberId = 7743; // Some Union
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId, memberId, 99.42);
            cmt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            Affiliation affiliation = e.Affiliation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is UnionAffiliation);

            UnionAffiliation uf = affiliation as UnionAffiliation;
            Assert.AreEqual(99.42, uf.Dues, .001);

            Employee member = PayrollDatabase.GetUnionMember(memberId);
            Assert.IsNotNull(member);
            Assert.AreEqual(e, member);
        }

        [Test]
        public void RemoveMembership()
        {
            int empId = 8;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            int memberId = 7743; // Some Union
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId, memberId, 99.42);
            cmt.Execute();

            ChangeUnaffiliatedTransaction cut = new ChangeUnaffiliatedTransaction(empId);
            cut.Execute();            

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            Affiliation affiliation = e.Affiliation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is NoAffiliation);

            Employee member = PayrollDatabase.GetUnionMember(memberId);
            Assert.IsNull(member);
        }
        #endregion

        #region Paying Employees
        [Test]
        public void PaySingleSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 30); // paid on the last working day of the month
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId, payDate);
            Assert.IsNotNull(pc);
            Assert.AreEqual(payDate, pc.PayDate);
            Assert.AreEqual(1000.00, pc.GrossPay, .001);
            Assert.AreEqual("Hold", pc.GetField("Disposition"));
            Assert.AreEqual(0.0, pc.Deductions, .001);
            Assert.AreEqual(1000.00, pc.NetPay, .001);
        }

        [Test]
        public void PaySingleSalariedEmployeeOnWrongDate()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 29);
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId, payDate);
            Assert.IsNull(pc);
        }

        [Test]
        public void PayingSingleHourlyEmployeeNoTimeCards()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); // Friday
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidateHourlyPaycheck(pt, empId, payDate, 0.0);
        }

        private void ValidateHourlyPaycheck(PaydayTransaction pt, int empid, DateTime payDate, double pay)
        {
            Paycheck pc = pt.GetPaycheck(empid, payDate);
            Assert.IsNotNull(pc);
            Assert.AreEqual(payDate, pc.PayDate);
            Assert.AreEqual(pay, pc.GrossPay, .001);
            Assert.AreEqual("Hold", pc.GetField("Disposition"));
            Assert.AreEqual(0.0, pc.Deductions, .001);
            Assert.AreEqual(pay, pc.NetPay, .001);
        }

        [Test]
        public void PaySingleHourlyEmployeeOneTimeCard()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); // Friday
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
            tc.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidateHourlyPaycheck(pt, empId, payDate, 30.5);
        }

        [Test]
        public void PaySingleHourlyEmployeeOvertimeOneTimeCard()
        {
            int empId = 322;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); // Friday
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 9.0, empId);
            tc.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidateHourlyPaycheck(pt, empId, payDate, (8 + 1.5) * 15.25);
        }

        [Test]
        public void PaySingleHourlyEmployeeOnWrongDate()
        {
            int empId = 2222;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 8); // Thursday
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 9.0, empId);
            tc.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId, payDate);
            Assert.IsNull(pc);
        }

        [Test]
        public void PaySingleHourlyEmployeeTwoTimeCards()
        {
            int empId = 2223;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); // Friday
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
            tc.Execute();

            TimeCardTransaction tc2 = new TimeCardTransaction(payDate.AddDays(-1), 5.0, empId);
            tc2.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidateHourlyPaycheck(pt, empId, payDate, 7 * 15.25);
        }

        [Test]
        public void TestPaySingleHourlyEmployeeWithTimeCardsSpanningTwoPayPeriods()
        {
            int empId = 2224;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); // Friday
            DateTime dateInPreviousPayPeriod = new DateTime(2001, 11, 2);
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
            tc.Execute();

            TimeCardTransaction tc2 = new TimeCardTransaction(dateInPreviousPayPeriod, 5.0, empId);
            tc2.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidateHourlyPaycheck(pt, empId, payDate, 2 * 15.25);
        }

        [Test]
        public void PaySingleCommissionedEmployeeOneSalesReceipt()
        {
            int empId = 326;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 1000, 15);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); // Friday
            SalesReceiptTransaction tct = new SalesReceiptTransaction(payDate, 200.0, empId);
            tct.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            double commissionPay = ((200 * 15) / 100);
            double salaryHalfPay = (1000 / 2);
            var pay = commissionPay + salaryHalfPay;
            ValidateHourlyPaycheck(pt, empId, payDate, pay);
        }

        [Test]
        public void PaySingleCommissionedEmployeeOnWrongDate()
        {
            int empId = 327;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 1000, 15);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 16); // Friday
            SalesReceiptTransaction tct = new SalesReceiptTransaction(payDate, 200.0, empId);
            tct.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId, payDate);
            Assert.IsNull(pc);
        }

        [Test]
        public void PaySingleCommissionedEmployeeTwoSalesReceipts()
        {
            int empId = 328;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 1000, 15);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 7); // Friday
            SalesReceiptTransaction tct = new SalesReceiptTransaction(payDate, 200.0, empId);
            tct.Execute();

            SalesReceiptTransaction tct2 = new SalesReceiptTransaction(payDate.AddDays(-1), 100.0, empId);
            tct.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            double commissionPay = ((200 * 15) / 100) + ((100 * 15) / 100);
            double salaryHalfPay = (1000 / 2);
            var pay = commissionPay + salaryHalfPay;
            ValidateHourlyPaycheck(pt, empId, payDate, pay);
        }

        [Test]
        public void PaySingleCommissionedEmployeeMonthSalary()
        {
            int empId = 329;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 1000, 15);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 7); // Friday
            SalesReceiptTransaction tct = new SalesReceiptTransaction(payDate, 200.0, empId);
            tct.Execute();

            SalesReceiptTransaction tct2 = new SalesReceiptTransaction(payDate.AddDays(-1), 100.0, empId);
            tct.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            double commissionPay = ((200 * 15) / 100) + ((100 * 15) / 100);
            double salaryHalfPay = (1000 / 2);
            var pay = commissionPay + salaryHalfPay;
            ValidateHourlyPaycheck(pt, empId, payDate, pay);

            pt = new PaydayTransaction(payDate.AddDays(14));
            pt.Execute();

            ValidateHourlyPaycheck(pt, empId, payDate, 1000 / 2);


            Paycheck pc = pt.GetPaycheck(empId, payDate);
            var totalMonthSalary = pc.GrossPay;
            pc = pt.GetPaycheck(empId, payDate);
            totalMonthSalary += pc.GrossPay;

            Assert.AreEqual(1000, totalMonthSalary);
        }
        #endregion
    }
}