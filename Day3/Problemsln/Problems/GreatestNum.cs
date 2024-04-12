using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class GreatestNum
    {
        static double getInput()
        {
            double num = 0;
            Console.WriteLine("Enter the the number : ");
            while (!double.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Invalid value.\nEnter a number : ");
            return num;
        }
        static double FindGreatest()
        {
            double num;
            double greatestNum = double.MinValue;
            do
            {
                num = getInput();
                if (num > greatestNum)
                {
                    greatestNum = num;
                }
            } while (num >= 0);
            return greatestNum;
        }

        static void Main(string[] args)
        {
            double greatest = FindGreatest();
            Console.WriteLine($"Greatest Value : {greatest}");
        }
    }
}
