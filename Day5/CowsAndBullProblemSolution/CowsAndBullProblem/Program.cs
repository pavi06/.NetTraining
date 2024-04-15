namespace CowsAndBullProblem
{
    internal class Program
    {
        string GenerateWord()
        {
            string word = "";
            bool flag = false;
            do
            {
                if (flag) {
                    Console.WriteLine("Invalid input.Guess the word again.It should contain only 4 characters.");
                }
                else {
                    Console.WriteLine("Guess the word: ");
                    flag = true;
                }
                word = Console.ReadLine();
            }
            while (word.Any(char.IsDigit) || word.Length!=4);
            return word;

        }

        void CompareWords(string sourceWord, string generatedWord, out int cows, out int bulls)
        {
            cows = 0;
            bulls =0;
            sourceWord = sourceWord.ToLower();
            generatedWord= generatedWord.ToLower();
            int[] secretVal = new int[26];
            int[] guessVal = new int[26];
            for (int i = 0; i < generatedWord.Length; i++)
            {
                if (generatedWord[i] == sourceWord[i])
                {
                    cows += 1;
                }
                else
                {
                    secretVal[sourceWord[i] - 'a' ]++;
                    guessVal[generatedWord[i] - 'a']++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                bulls += secretVal[i] < guessVal[i] ? secretVal[i] : guessVal[i];
            }
        }


        void StartGeneratingWordAndCheckIfWOn(string sourceWord) {
            int cows=0, bulls=0;
            do {
                string generatedWord = GenerateWord();
                CompareWords(sourceWord, generatedWord, out cows, out bulls);
                Console.WriteLine("You Entered : "+generatedWord);
                Console.WriteLine("Cows : " + cows + ", Bulls : " + bulls);
                Console.WriteLine("---------------------------------------");
            } 
            while (cows < 4 && bulls < 4);
            Console.WriteLine("Congrats you won!");
        }
        void StartPlaying() {
            string sourceWord = "";
            do
            {
                Console.WriteLine("Provide the secret word to play the game: ");
                sourceWord = Console.ReadLine();
            }
            while (sourceWord.Any(char.IsDigit));
            StartGeneratingWordAndCheckIfWOn(sourceWord);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartPlaying();
        }
    }
}
