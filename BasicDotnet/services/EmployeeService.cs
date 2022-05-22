using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicDotnet.helpers;

namespace BasicDotnet.services {

    public class EmployeeService
    {

        private List<models.Employee> _employees = new List<models.Employee>();


        //readonly
        public List<models.Employee> Employees { 
            get {
                return _employees;
            } 
        } 

        public void AddEmployee(string employeeCode,
            string employeeName,
            string startWorking,
            bool stillWorking,
            decimal salary,
            string userID,
            string email,
            string password,
            int userType)
        {
            _employees.Add(new models.Employee(
                employeeCode,
                employeeName,
                startWorking,
                stillWorking,
                salary,
                userID,
                email, 
                password,
                userType));

        }

        public void PrintConsole(models.Employee[] employees)
        {

            for(int i=0;i< employees.Length;i++)
            {
                var _employee = employees[i];

                string[] fields = new string[]{

                    ConsoleFormatter.field(
                        models.Employee.EMPLOYEE_CODE_LEN,
                        _employee.EmployeeCode,
                        ConsoleFormatter.ALIGN_LEFT,
                        ' ',
                        "|"),

                    ConsoleFormatter.field(
                        models.Employee.EMPLOYEE_NAME_LEN,
                        _employee.EmployeeName,
                        ConsoleFormatter.ALIGN_LEFT,
                        ' ',
                        "|"),

                     ConsoleFormatter.field(
                        models.Employee.START_WORKING_LEN,
                        _employee.StrStartWorking(),
                        ConsoleFormatter.ALIGN_CENTER,
                        ' ',
                        "|"),

                      ConsoleFormatter.field(
                        models.Employee.STILL_WORKING_LEN,
                        _employee.Str2StillWorking,
                        ConsoleFormatter.ALIGN_CENTER,
                        ' ',
                        "|"),

                      ConsoleFormatter.field(
                        models.Employee.SALARY_LEN,
                        _employee.StrSalary(),
                        ConsoleFormatter.ALIGN_RIGHT,
                        ' ',
                        "|"),
                };

                Console.Write(ConsoleFormatter.row(fields));

            }
        }


        public models.Employee[] SearchEmployees(string keyword)
        {
            List<models.Employee> results = new List<models.Employee>();
            for (int i = 0; i < _employees.Count; i++)
            {
                if (_employees[i].EmployeeName.ToLower().Contains(keyword.ToLower())  ||
                    _employees[i].EmployeeCode.ToLower().Contains(keyword.ToLower()) )
                  
                {
                    results.Add(_employees[i]);
                }
            }
            return results.ToArray();
        }

    }

   
}
