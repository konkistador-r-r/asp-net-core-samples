using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public interface IPayrollDatabase
    {
        void AddEmployee(Employee employee);
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
        ArrayList GetAllEmployeeIds();
    }

    public class PayrollDatabase
    {
        public static PayrollDatabase instance;

        private static Hashtable employees = new Hashtable();
        private static Dictionary<int, List<TimeCard>> timeCards = new Dictionary<int, List<TimeCard>>();
        private static Dictionary<int, List<SalesReceipt>> salesReceipts = new Dictionary<int, List<SalesReceipt>>();
        private static Dictionary<int, List<ServiceCharge>> serviceCharges = new Dictionary<int, List<ServiceCharge>>();
        private static Hashtable unionMember = new Hashtable();

        #region Employee
        public void AddEmployee(Employee employee)
        {
            employees[employee.Id] = employee;
        }
        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }
        public static void DeleteEmployee(int id)
        {
            if (employees.ContainsKey(id))
            {
                employees.Remove(id);
            }
        }
        public static IEnumerable<Employee> GetAllEmployee() {
            foreach (var value in employees.Values)
            {
                yield return value as Employee;
            }            
        }
        #endregion

        #region TimeCard
        public static void AddTimeCard(int empId, TimeCard timeCard)
        {
            if (!timeCards.ContainsKey(empId))
            {
                timeCards[empId] = new List<TimeCard>();
            }
            timeCards[empId].Add(timeCard);
        }
        public static TimeCard GetTimeCard(int empId, DateTime date)
        {
            return timeCards[empId]?.Find(c=>c.Date == date) as TimeCard;
        }
        public static void DeleteTimeCard(int empId, DateTime date)
        {
            if (timeCards.ContainsKey(empId))
            {
                timeCards[empId].Remove(timeCards[empId].Find(c => c.Date == date) as TimeCard);
            }
        }
        public static List<TimeCard> GetTimeCards(int empId)
        {
            return timeCards.ContainsKey(empId) ? timeCards[empId] : new List<TimeCard>();
        }
        #endregion

        #region SalesReceipt
        public static void AddSalesReceipt(int empId, SalesReceipt receipt)
        {
            if (!salesReceipts.ContainsKey(empId))
            {
                salesReceipts[empId] = new List<SalesReceipt>();
            }
            salesReceipts[empId].Add(receipt);
        }
        public static SalesReceipt GetSalesReceipt(int empId, DateTime date)
        {
            return salesReceipts[empId]?.Find(c => c.Date == date) as SalesReceipt;
        }
        public static void DeleteSalesReceipt(int empId, DateTime date)
        {
            if (salesReceipts.ContainsKey(empId))
            {
                salesReceipts[empId].Remove(salesReceipts[empId].Find(c => c.Date == date) as SalesReceipt);
            }
        }
        public static List<SalesReceipt> GetSalesReceipts(int empId)
        {
            return salesReceipts.ContainsKey(empId) ? salesReceipts[empId] : new List<SalesReceipt>();
        }
        #endregion

        #region ServiceCharges
        public static void AddServiceCharges(int memberId, ServiceCharge charge)
        {
            if (!serviceCharges.ContainsKey(memberId))
            {
                serviceCharges[memberId] = new List<ServiceCharge>();
            }
            serviceCharges[memberId].Add(charge);
        }
        public static ServiceCharge GetServiceCharges(int memberId, DateTime date)
        {
            return serviceCharges[memberId]?.Find(c => c.Date == date) as ServiceCharge;
        }
        public static void DeleteServiceCharges(int memberId, DateTime date)
        {
            if (serviceCharges.ContainsKey(memberId))
            {
                serviceCharges[memberId].Remove(serviceCharges[memberId].Find(c => c.Date == date) as ServiceCharge);
            }
        }
        #endregion

        #region UnionMember
        public static void AddUnionMember(int memberId, Employee employee)
        {
            unionMember[memberId] = employee;
        }
        public static Employee GetUnionMember(int memberId)
        {
            return unionMember.ContainsKey(memberId) ? unionMember[memberId] as Employee : null;
        }
        public static void RemoveUnionMember(int memberId)
        {
            if (unionMember.ContainsKey(memberId))
            {
                unionMember.Remove(memberId);
            }
        }
        #endregion
    }
}
