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
            string val = "";
            while (true) { 
                val = Console.ReadLine();
                if (val == " " || val=="")
                {
                    Console.WriteLine("Invalid Input! Please provide the username properly");
                }
                else {
                    break;
                }
            }
            return val;
        }
        static string CheckUser()
        {
            int n = 0;
            while (n < 3)
            {
                n++;
                string userName = GetUserInput("UserName");
                string password = GetUserInput("Password");
                if (userName=="ABC" && password=="123")
                {
                    return "Hy! your login was successful!";
                }
                else {
                    if (n < 3) {
                        Console.WriteLine($"Oops! your entered password or username is invalid!");
                    }
                    
                }                
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
