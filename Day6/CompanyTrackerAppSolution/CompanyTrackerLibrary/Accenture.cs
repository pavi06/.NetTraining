using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTrackerLibrary
{
    public class Accenture : Company , GovtRules
    {
        public const float pfPercent = 24f;
        public const float pfPercentForEmployeeContribution = 12f;
        public Accenture(int id, string name, string department, string designation, double serviceYears, double basicSalary) : base(id, name, department, designation,serviceYears,basicSalary)
        {
            companyType = "Accenture";
        }
        public double EmployeePF()
        {
            return (pfPercent / 100) * BasicSalary;
        }

        public double gratuityAmount()
        {
            return 0.0;
        }

        public string LeaveDetails()
        {
            return "\n---------Leave Details for Accenture------------\n2 Days of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Previlage Leave per year\n";
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            double calculatedSalary = BasicSalary - ((pfPercentForEmployeeContribution / 100) * BasicSalary);
            Console.WriteLine("Employee Salary : " + Math.Round(calculatedSalary, 2));
        }

    }
}
