using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTrackerLibrary
{
    public class Cts : Company, GovtRules
    {
        public const float pfPercent = 12f;
        public const float pfPercentForEmployeeContribution = 3.67f;
        public Cts(int id, string name, string department , string designation , double serviceYears, double basicSalary) : base(id, name, department, designation, serviceYears, basicSalary)
        {
            companyType = "CTS";
        }
        public double EmployeePF()
        {
            return (pfPercent / 100) * BasicSalary;
        }

        public double gratuityAmount()
        {
            if (ServiceCompleted > 20)
            {
                return 3 * BasicSalary;
            }
            else if (ServiceCompleted > 10)
            {
                return 2 * BasicSalary;
            }
            else if (ServiceCompleted > 5)
            {
                return BasicSalary;
            }
            else {
                return 0.0;
            }
        }

        public string LeaveDetails()
        {
            return "\n-----------------Leave Details for CTS------------------\n1 day of Casual Leave per month\n12 days of Sick Leave per year\n10 days of Privilege Leave per year\n";
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            double calculatedSalary = BasicSalary - ((pfPercentForEmployeeContribution / 100)*BasicSalary);
            Console.WriteLine("Employee Salary : " + Math.Round(calculatedSalary, 2));
        }
    }
}
