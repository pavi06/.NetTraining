using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class WordWithLeastVowelCout
    {
        static int vowelCount(string s)
        {
            int count = 0;
            foreach (char c in s.ToLower())
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    count++;
                }
            }
            return count;

        }

        static Dictionary<string, int> checkWordWithLeastVowelCount(string s, out int minCount)
        {
            minCount = int.MaxValue;
            Dictionary<string, int> wordWithVowelCount = new Dictionary<string, int>();
            foreach (string word in s.Split(','))
            {
                int vowCount = vowelCount(word);
                if (vowCount <= minCount)
                {
                    minCount = vowCount;
                }
                wordWithVowelCount.Add(word, vowCount);
            }
            return wordWithVowelCount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the list of words separated by comma: ");
            string s = Console.ReadLine();
            int minCount = 0;
            Dictionary<string, int> words = checkWordWithLeastVowelCount(s, out minCount);
            Console.WriteLine("Word with minimum vowel count:");
            foreach (var word in words)
            {
                if (word.Value == minCount)
                {
                    Console.Write(word.Key + ",");
                }

            }
            Console.WriteLine($" - {minCount}");

        }
    }
}
