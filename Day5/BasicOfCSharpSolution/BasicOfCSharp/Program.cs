namespace BasicOfCSharp
{
    internal class Program
    {
        void UnderstandingSequenceStatments()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Hi");
            int num1, num2;
            num1 = 100;
            num2 = 20;
            int num3 = num1 / num2;
            Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        }
        void UnderstandingSelectionWithIf()
        {
            string strName = "Pavi";
            if (strName == "Pavi")
            {
                Console.WriteLine("Welcome Pavi. you are authorized");
                Console.WriteLine("Bingo!!");
            }
            else if (strName == "Shiva")
                Console.WriteLine("You are Shiva not Pavi. Only Basic access");
            else
                Console.WriteLine("I don't know who you are....");

        }

        void UnderstandingSwitchCase()
        {
            Console.WriteLine("Please enter a number for day");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("You dont know the numberof days in a week???");
                    break;
            }
        }

        void UnderstandingIterationWithFor()
        {
            for (int i = 0; i < 5; i = i + 2)
            {
                Console.WriteLine("Hello " + i);

            }
        }
        void UnderstandingIterationWithWhile()
        {
            int count = 10;
            while (count > 0)
            {
                count--;
                if (count == 7)
                    continue;
                Console.WriteLine("The value of count is " + count);
                if (count == 4)
                    break;

            }
        }
        void UnderstandingIterationWithDoWhile()
        {
            int count = -1;
            do
            {
                Console.WriteLine("In Do while the value is  " + count);
                Console.WriteLine("Please enter the number");
                count = Convert.ToInt32(Console.ReadLine());
            } while (count > 0);
        }

        void UnderstandingArray()
        {
            int[] numbers = { 200, 676, 900, 777, 666, 686 };
            int countOfRepeatingNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNumber, secondNumber,thirdNumber;
                firstNumber = numbers[i] / 100;
                secondNumber = (numbers[i] /10) % 10;
                thirdNumber = numbers[i] % 10;
                Console.WriteLine("first digit : " + firstNumber+ " second digit : " + secondNumber+" third digit : " + thirdNumber);
                if (firstNumber == secondNumber && secondNumber == thirdNumber)
                    Console.WriteLine("num with repeated digits : " + numbers[i]);
                countOfRepeatingNumbers++;
            }
            Console.WriteLine("The numbe rof repeating numbers is " + countOfRepeatingNumbers);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.UnderstandingSequenceStatments();
            //program.UnderstandingSelectionWithIf();
            //program.UnderstandingSwitchCase();
            //program.UnderstandingIterationWithFor();
            //program.UnderstandingIterationWithWhile();
            //program.UnderstandingIterationWithDoWhile();
            program.UnderstandingArray();
               
        }
    }
}
