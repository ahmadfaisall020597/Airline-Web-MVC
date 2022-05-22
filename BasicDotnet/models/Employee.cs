using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.models
{
    //inherits from User
    public class Employee : User
    {

        public const int EMPLOYEE_CODE_LEN = 20;
        public const int EMPLOYEE_NAME_LEN = 20;
        public const int START_WORKING_LEN = 15;
        public const int STILL_WORKING_LEN = 20;
        public const int SALARY_LEN =12;


        /*
         priviledge access

         (E)mployee => public
         (e)employee => private, protected
         (_e)mployee => private

         */
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime StartWorking { get; set; }
        public bool StillWorking { get; set; }
        public decimal Salary { get; set; }

        public Employee(string employeeCode, 
            string employeeName,
            string startWorking,
            bool stillWorking,
            decimal salary,
            string userID,
            string email,
            string password,
            int userType) : base(userID, email, password, userType) { 

            EmployeeCode = employeeCode;
            EmployeeName = employeeName;
            StartWorking = DateTime.Parse(startWorking);
            StillWorking = stillWorking;
            Salary = salary;


        }

        //property readonly // getter only
        public string Str2StillWorking
        {
            get
            {
                return(StillWorking ? "Masih Bekerja" : "Tidak Bekerja Lagi");
            }
        }

        public string StrStillWorking()
        {
            return (StillWorking ? "Masih Bekerja" : "Tidak Bekerja Lagi");
        }
        
        public string StrStartWorking()
        {
            return StartWorking.ToString("yyyy-MM-dd");
        }

        public string StrSalary()
        {
            return Salary.ToString("#,###");
        }
    }
}
