using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
namespace Employee
{
    public class Employees
    {
        public string Nric { get; set; }
        public string FullName { get; set; }
        public string Salutation { get; set; }
        public DateTime Start_Date { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string MobileNo { get; set; }
        public string HireType { get; set; }
        public double Salary { get; set; }
        public double MonthlyPayout = 0.0;

        public override string ToString()
        {
            return Nric + FullName + Salutation + Start_Date + Designation + Department + MobileNo + HireType + Salary + MonthlyPayout;
        }

        public Employees(string Nric, string FullName, string Salutation, DateTime Start_Date, string Designation, string Department, string MobileNo, string HireType, double Salary)
        {
            this.Nric = Nric;
            this.FullName = FullName;
            this.Salutation = Salutation;
            this.Start_Date = Start_Date;
            this.Designation = Designation;
            this.Department = Department;
            this.MobileNo = MobileNo;
            this.HireType = HireType;
            this.Salary = Salary;


        }
    }
}