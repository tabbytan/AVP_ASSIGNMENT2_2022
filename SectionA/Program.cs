using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Employee;

namespace SectionA
{
    public delegate void Del(List<Employees> list);
    public class Program
    {
        public static List<Employees> readHRMasterList()
        {
            string text = @"..\HRMasterlist.txt";
            List<string> allines = new List<string>();
            List<Employees> employeelist = new List<Employees>();
        try {
            // clean up the text file turn into object
            allines = File.ReadAllLines(text).ToList();
        }
        catch(Exception e){
            Console.WriteLine(e.Message+" file does not exist");
            Environment.Exit(0);
        }
        try{
            foreach (string line in allines)
            {
                string[] item = line.Split('|');
                Employees e = new Employees(item[0], item[1], item[2], DateTime.ParseExact(item[3], "dd/mm/yyyy", null), item[4], item[5], item[6], item[7], double.Parse(item[8]));
                employeelist.Add(e);
            }
        }
        catch(Exception f){
            Console.WriteLine(f.Message + "Parsing error please check the masterfile");
        }
        
        
        return employeelist;
         
            
        
        
            // debug purposes print employeelist
            // foreach (Employees e in employeelist)
            // {
            //     Console.WriteLine(e);
            // }
        }
        public static void generateInfoForCorpAdmin(List<Employees> employeelist)
        {
            string filename = @"../CorporateAdmin.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            foreach (Employees Employees in employeelist)
            {
                // Console.WriteLine(Employees.FullName + ',' + Employees.Designation + ',' + Employees.Department);
                string totxt = (Employees.FullName + ',' + Employees.Designation + ',' + Employees.Department);
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(totxt);
                }
            }

        }
        public static void generateInfoForProcurement(List<Employees> employeelist)
        {
            string filename = @"../Procurement.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            foreach (Employees Employees in employeelist)
            {
                // Console.WriteLine(Employees.Salutation + ',' + Employees.FullName + ',' + Employees.MobileNo + Employees.Designation + ',' + Employees.Department);
                string totxt = (Employees.Salutation + ',' + Employees.FullName + ',' + Employees.MobileNo + Employees.Designation + ',' + Employees.Department);
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(totxt);
                }
            }
        }
        public static void generateInfoForITDepartment(List<Employees> employeelist)
        {
            string filename = @"../ITDepartment.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            foreach (Employees Employees in employeelist)
            {
                // Console.WriteLine(Employees.Nric + ',' + Employees.FullName + ',' + Employees.Start_Date + ',' + Employees.Department + ',' + Employees.MobileNo);
                string totxt = (Employees.Nric + ',' + Employees.FullName + ',' + Employees.Start_Date.ToShortDateString() + ',' + Employees.Department + ',' + Employees.MobileNo);
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(totxt);
                }
            }
        }
        static void Main(string[] args)
        {
            Del del1 = new Del(generateInfoForITDepartment);
            Del del2 = new Del(generateInfoForCorpAdmin);
            Del del3 = new Del(generateInfoForProcurement);
            Del multidelegate = del1 + del2 + del3;
            multidelegate(readHRMasterList());
        }
    }



}
