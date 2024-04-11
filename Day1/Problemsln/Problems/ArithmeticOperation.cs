namespace Problems
{
    internal class ArithmeticOperation
    {
        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Product(double num1, double num2)
        {

            return num1 * num2;
        }

        static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Division operation cannot be performed since anything divide by zero will leads to infinity!\nIf you want to perform division operation then provide the non-zero number");
                return -1;
            }
            return num1 / num2;

        }

        static double Remainder(double num1, double num2)
        {

            return num1 % num2;
        }

        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double GetNumber()
        {
            double num;
            Console.WriteLine("Enter a number : ");
            while (!double.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Invalid value. Enter a number");
            return num;
        }
        static void Calculate()
        {
            double num1 = GetNumber();
            double num2 = GetNumber();
            double sum = Add(num1, num2);
            double sub = Subtract(num1, num2);
            double prod = Product(num1, num2);
            double div = Divide(num1, num2);
            if (div == -1)
            {
                PrintCalculatedVal(num1, num2, sum, sub, prod);
            }
            else
            {

                div = Math.Round(div, 2, MidpointRounding.ToEven);
                double rem = Remainder(num1, num2);
                rem = Math.Round(rem, 2, MidpointRounding.ToEven);
                PrintCalculatedVal(num1, num2, sum, sub, prod, div, rem);

            }
        }
        private static void PrintCalculatedVal(double num1, double num2, double sum, double sub, double prod)
        {
            Console.WriteLine($"Entered numbers are :  {num1} and {num2} \nSum : {sum}\nDifference : {sub}\nProduct : {prod}");
        }

        private static void PrintCalculatedVal(double num1, double num2, double sum, double sub, double prod, double div, double rem)
        {
            Console.WriteLine($"Entered numbers are :  {num1} and {num2} \nSum : {sum}\nDifference : {sub}\nProduct : {prod}\nDivision : {div}\nRemainder : {rem}");
        }

        static void Main(string[] args)
        {
            Calculate();
        }
    }
}
