using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class UserCheck
    {
        static string GetUserInput(string msg)
        {
            Console.WriteLine($"Enter the {msg} : ");
            return Console.ReadLine();
        }
        static string CheckUser()
        {
            int n = 0;
            while (n < 3)
            {
                n++;
                string name = GetUserInput("Password");
                string password = GetUserInput("UserName");
                if (name == "ABC" && password == "123")
                {
                    return "Hy! your login was successful!";
                }
                Console.WriteLine($"Oops! your entered password or username is invalid!");
            }
            return "Oops! The number of attempts exceeded! Try again later";


        }
        static void Main(string[] args)
        {
            string s = CheckUser();
            Console.WriteLine(s);

        }
    }
}
