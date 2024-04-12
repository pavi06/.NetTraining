using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Problems2
{
    class AccessCardProgram
    {
        /// <summary>
        /// Method to check if the string contains any alphabets
        /// </summary>
        /// <param name="cardno"> cardno of string type</param>
        /// <returns> return true if alphabet is available else return false</returns>
        static bool IsAlphabet(string cardno) { 
            for(int i = 0; i < cardno.Length; i++)
            {
                if (Char.IsLetter(cardno[i])) { 
                return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Function to check the card is valid are not
        /// </summary>
        /// <param name="sum">total sum obtained after adding all digit</param>
        /// <returns>return true if the card is valid else return false</returns>
        static bool CheckValid(double sum) {
            if (sum % 10 == 0)
            {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Method to traverse each digit of the cardno and perform calculation
        /// </summary>
        /// <param name="cardno">cardno of string type</param>
        /// <returns>return the validity of the card</returns>
        static bool CheckCardIsValidOrNot(string cardno) {
            Console.WriteLine($"Your Card number : {cardno}");
            int j = 0;
            double totalSum = 0;
            for (int i = cardno.Length - 1; i >= 0; i--) {
                if (j % 2 == 0)
                {
                    totalSum += double.Parse(cardno[i].ToString());
                }
                else {
                    int digit = int.Parse(cardno[i].ToString())*2;
                    while (digit > 0) {
                        totalSum += (digit % 10);
                        digit /= 10;
                    }
                }
                j++;
            }
            return CheckValid(totalSum);
             
        }
        static void Main(string[] args) {
            Console.WriteLine("Enter you Access card number : ");
            string cardno = string.Empty;
            while (true)
            {
                cardno = Console.ReadLine();
                if (IsAlphabet(cardno) || cardno.Length <16 || cardno.Length > 16 || double.Parse(cardno) < 0)
                {
                    Console.WriteLine("Invalid Value! Please enter you Access card number properly.It should contain 16 digits");
                }
                else {
                    break;
                }   
            }
            if (CheckCardIsValidOrNot(cardno))
            {
                Console.WriteLine("Success!! Your card is Valid!");
            }
            else
            {
                Console.WriteLine("Sorry !! Your card is InValid!");
            }
        }
    }
}
