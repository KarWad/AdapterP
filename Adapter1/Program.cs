using System;
using System.Collections.Generic;

namespace Adapter1
{
    public class BillingSystem
    {
        private ITarget employeeSource;

        public BillingSystem(ITarget employeeSource)
        {
            this.employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            List<string> employee = employeeSource.GetEmployeeList();
            //To DO: Implement you business logic

            Console.WriteLine("######### Employee List ##########");
            foreach (var item in employee)
            {
                Console.Write(item);
            }

        }
    }
    public interface ITarget
    {
        List<string> GetEmployeeList();
    }
    public class HRSystem
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new string[] { "100", "Karolina", "Team Leader" };
            employees[1] = new string[] { "101", "David", "Developer" };
            employees[2] = new string[] { "102", "Michał", "Developer" };
            employees[3] = new string[] { "103", "Anna", "Tester" };

            return employees;
        }
    }
    public class EmployeeAdapter : HRSystem, ITarget
    {
        public List<string> GetEmployeeList()
        {
            List<string> employeeList = new List<string>();
            string[][] employees = GetEmployees();
            foreach (string[] employee in employees)
            {
                employeeList.Add(employee[0]);
                employeeList.Add(",");
                employeeList.Add(employee[1]);
                employeeList.Add(",");
                employeeList.Add(employee[2]);
                employeeList.Add("\n");
            }

            return employeeList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITarget Itarget = new EmployeeAdapter();
            BillingSystem client = new BillingSystem(Itarget);
            client.ShowEmployeeList();

            Console.ReadKey();

        }
    }
}