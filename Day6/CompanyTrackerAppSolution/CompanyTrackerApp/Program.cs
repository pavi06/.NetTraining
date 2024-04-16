using System.ComponentModel.Design;
using System.Xml.Linq;
using CompanyTrackerLibrary;

namespace CompanyTrackerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cts employee = new Cts(101,"Pavi", "HR" , "Senior Engineer", 12, 1000);
            GovtRules govtRules = employee;
            employee.DisplayDetails();

            string leaveDetails = govtRules.LeaveDetails();
            Console.WriteLine(leaveDetails);

            Console.WriteLine("Do you wanted to see the PF Amount?\nEnter Y/N");
            string userInputToGetPFCalculated = Console.ReadLine();
            if(userInputToGetPFCalculated.ToUpper() == "Y")
                Console.WriteLine("PF Amount: "+Math.Round(govtRules.EmployeePF(),2));

            Console.WriteLine("\nWould you like to see the Gratitude Amount?\nEnter Y/N");
            string userInputToGetGRatitudeCalculated = Console.ReadLine();
            double gratitudeAmountCal=0.0;
            if (userInputToGetGRatitudeCalculated.ToUpper() == "Y")
            {
                gratitudeAmountCal = govtRules.gratuityAmount();
                if (gratitudeAmountCal == 0.0 && employee.companyType=="Accenture")
                    Console.WriteLine("Gratuity is Not Applicable");
                else if (gratitudeAmountCal == 0.0)
                    Console.WriteLine("Oops! You didn't earned any gratuity amount.");
                else
                    Console.WriteLine("Gratuity Amount : " + Math.Round(govtRules.gratuityAmount(), 2));
            }
        }
    }
}
