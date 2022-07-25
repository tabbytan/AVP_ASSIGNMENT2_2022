using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SectionA
{
    public class Employees
    {
        string Nric;
        string FullName;
        string Salutation;
        DateTime Start_Date;
        string Designation;
        string Department;
        string MobileNo;
        string HireType;
        double Salary;
        double MonthlyPayout = 0.0;

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
            this.MonthlyPayout = Salary / 12;


        }

        public static List<Employees> readHRMasterList()
        {
            string text = @"..\HRMasterlist.txt";
            List<string> allines = new List<string>();
            List<Employees> employeelist = new List<Employees>();
            // clean up the text file turn into object
            allines = File.ReadAllLines(text).ToList();
            foreach (string line in allines)
            {
                string[] item = line.Split('|');
                Employees e = new Employees(item[0], item[1], item[2], DateTime.ParseExact(item[3], "dd/mm/yyyy", null), item[4], item[5], item[6], item[7], double.Parse(item[8]));
                employeelist.Add(e);
            }
            return employeelist;
            // debug purposes print employeelist
            // foreach (Employees e in employeelist)
            // {
            //     Console.WriteLine(e);
            // }


        }
        public static void generateInfoForCorpAdmin()
        {
            string filename = @"../CorporateAdmin.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            List<Employees> employeelist = readHRMasterList();
            foreach (Employees Employees in employeelist)
            {
                Console.WriteLine(Employees.FullName + ',' + Employees.Designation + ',' + Employees.Department);
                string totxt = (Employees.FullName + ',' + Employees.Designation + ',' + Employees.Department);
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(totxt);
                }
            }

        }
        public static void generateInfoForProcurement()
        {
            List<Employees> employeelist = readHRMasterList();
            string filename = @"../Procurement.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            foreach (Employees Employees in employeelist)
            {
                Console.WriteLine(Employees.Salutation + ',' + Employees.FullName + ',' + Employees.MobileNo + Employees.Designation + ',' + Employees.Department);
                string totxt = (Employees.Salutation + ',' + Employees.FullName + ',' + Employees.MobileNo + Employees.Designation + ',' + Employees.Department);
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(totxt);
                }
            }
        }
        public static void generateInfoForITDepartment()
        {
            List<Employees> employeelist = readHRMasterList();
            string filename = @"../ITDepartment.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            foreach (Employees Employees in employeelist)
            {
                Console.WriteLine(Employees.Nric + ',' + Employees.FullName + ',' + Employees.Start_Date + ',' + Employees.Department + ',' + Employees.MobileNo);
                string totxt = (Employees.Nric + ',' + Employees.FullName + ',' + Employees.Start_Date + ',' + Employees.Department + ',' + Employees.MobileNo);
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(totxt);
                }
            }
        }


        static void Main(string[] args)
        {
            generateInfoForProcurement();
            generateInfoForCorpAdmin();
            generateInfoForITDepartment();
        }
    }
}