using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class AverageProblem
    {
        static double GetInput()
        {
            double num;
            Console.WriteLine("Enter a number : ");
            while (!double.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Invalid value. Enter a number");
            return num;
        }
        static bool checkDivisibility(double num)
        {

            if (num % 7 != 0)
            {
                return false;
            }
            return true;
        }
        static double FindAverage(out string msg)
        {
            double num, total = 0, count = 0;
            do
            {
                num = GetInput();
                if (checkDivisibility(num))
                {
                    if (num != 0)
                        count++;
                    total += num;

                }
            } while (num >= 0);
            if (count == 0)
            {
                msg = "None of the entered numbers are divisible by 7. So Average cannot be found!";
                return -1;
            }
            msg = "";
            return total / count;
        }

        static void Main(string[] args)
        {
            string msg = "";
            double avg = FindAverage(out msg);
            if (avg == -1)
            {
                Console.WriteLine(msg);
            }
            else
            {
                Console.WriteLine($"Average of numbers that are divisible by 7 : {avg}");
            }
        }
    }
}
