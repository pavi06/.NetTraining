using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProblems
{
    internal class ExcelSheetColumnTitleProblem
    {
        public async Task<string> GetColumnTitleAsync(long colNum)
        {
            string res = "";
            while (colNum > 0)
            {
                long rem = (colNum -1 ) % 26 ;
                res += Convert.ToString(Convert.ToChar(rem + 65));
                colNum = (colNum -1 ) / 26;
            }
            char[] charArray = res.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public async Task<long> GetUserInput()
        {
            long colNum = 0;
            Console.WriteLine("Enter the Column Number : ");
            while (!long.TryParse(Console.ReadLine(), out colNum))
            {
                Console.WriteLine("Invalid input. Enter the Column Number Again : ");
            }
            return colNum;
        }
        public static async Task Main(string[] args)
        {
            ExcelSheetColumnTitleProblem columnTitleProblem = new ExcelSheetColumnTitleProblem();
            long columnNumber = await columnTitleProblem.GetUserInput();
            string title = await columnTitleProblem.GetColumnTitleAsync(columnNumber);
            Console.WriteLine("Column Title : " + title);
        } 
    }
}
