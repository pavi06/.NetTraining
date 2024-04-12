using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2
{
    internal class Arrays
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            numbers[0] = 102;
            numbers[1] = 23;
            for (int i = 2; i < 5; i++)
            {
                numbers[i]=i+1;
            }
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            int count = numbers.Length-1;
            //while (count >= 0)
            //{
            //    Console.WriteLine(numbers[count]);
            //    count--;
            //}

            do
            {
                Console.WriteLine(numbers[count]);
                count--;
            } while (count >= 0);
        }
    }
}
