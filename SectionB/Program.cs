using System;
using System.Collections.Generic;
using Employees = Employee.Employees;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
namespace SectionB
{
    class Program
    {
        public enum HireType
        {
            PartTime,
            FullTime,
            Hourly
        }
        public static List<Employees> processPayroll(List<Employees> employeelist)
        {
            // updated list
            List<Employees> NewEmployeeList = new List<Employees>();
            foreach (Employees Employees in employeelist)
            {
                switch (Enum.Parse(typeof(HireType), Employees.HireType))
                {
                    case HireType.FullTime:
                        Employees.MonthlyPayout = Employees.Salary * 1;
                        Console.WriteLine($"{Employees.FullName} ({Employees.Nric})");
                        Console.WriteLine($"{Employees.Designation}");
                        Console.WriteLine($"FullTime Payout: ${Employees.MonthlyPayout}");
                        Console.WriteLine("------------------------------------------------------------");
                        NewEmployeeList.Add(Employees);
                        break;
                    case HireType.Hourly:
                        Employees.MonthlyPayout = Employees.Salary * 0.25;
                        Console.WriteLine($"{Employees.FullName} ({Employees.Nric})");
                        Console.WriteLine($"{Employees.Designation}");
                        Console.WriteLine($"{HireType.Hourly.ToString()} Payout: ${Employees.MonthlyPayout}");
                        Console.WriteLine("------------------------------------------------------------");
                        NewEmployeeList.Add(Employees);
                        break;
                    case HireType.PartTime:
                        Employees.MonthlyPayout = Employees.Salary * 0.5;
                        Console.WriteLine($"{Employees.FullName} ({Employees.Nric})");
                        Console.WriteLine($"{Employees.Designation}");
                        Console.WriteLine($"{(HireType)0}Payout: ${Employees.MonthlyPayout}");
                        Console.WriteLine("------------------------------------------------------------");
                        NewEmployeeList.Add(Employees);
                        break;
                }
            }
            int totalpay = NewEmployeeList.Sum(x => ((int)x.MonthlyPayout));
            int totalpeople = NewEmployeeList.Count();
            Console.WriteLine($"Total Payroll Amount: ${totalpay} to be paid to {totalpeople} employees");
            return NewEmployeeList;
        }
        public async static Task updateMonthlyPayoutToMasterlist(List<Employees> employeelist)
        {
            List<Employees> NewEmployeeList = await Task.Run(() => processPayroll(employeelist));
            string filename = @"../HRMasterlistB.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            foreach (Employees Employees in NewEmployeeList)
            {
                // Console.WriteLine(Employees.Nric + '|' + Employees.FullName + '|' + Employees.Start_Date + '|' + Employees.Department + '|' + Employees.MobileNo);
                string totxt = (Employees.Nric + '|' + Employees.FullName + '|' + Employees.Salutation + '|' + Employees.Start_Date.ToShortDateString() + '|' + Employees.Designation + '|' + Employees.Department + '|' + Employees.MobileNo + '|' + Employees.Salary + '|' + Employees.MonthlyPayout);
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(totxt);
                }
            }
        }
        static async Task Main(string[] args)
        {
            // SectionA.Program.readHRMasterList();
            await updateMonthlyPayoutToMasterlist(SectionA.Program.readHRMasterList());
        }
    }
}



