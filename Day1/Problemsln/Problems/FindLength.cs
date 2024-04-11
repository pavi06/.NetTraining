using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class FindLength
    {
        static int GetLength(string s)
        {
            int i = 0;
            foreach (char c in s)
            {
                i++;
            }
            return i;
        }
        static string GetInput()
        {
            Console.WriteLine("Enter the string for which you need to find the length : ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string s = GetInput();
            int length = GetLength(s);
            Console.WriteLine($"The length of the string {s} is : {length}");
        }
    }
}
