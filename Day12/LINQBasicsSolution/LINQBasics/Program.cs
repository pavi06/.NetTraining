namespace LINQBasics
{

    internal class Program
    {

        //signature should be same.
        //creating a type that refferes to a method
        //public delegate int calcDel(int n1, int n2);
        //public delegate int calcDel(int n1, int n2);

        //public delegate T calcDel<T>(T n1, T n2);//creating a generic  type that refferes to a method
        //void Calculate(calcDel<int> cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //}
        //public int Add(int num1, int num2)
        //{
        //    return (num1 + num2);
        //}

        //void Calculate(Func<int, int, int> cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //}


        //public delegate int calcDel1(int n1, int n2);
        //void Calculate1(calcDel1 cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The difference of {n1} and {n2} is {result}");
        //}
        //public int Subtract(int num1, int num2)
        //{
        //    return (num1 - num2);
        //}

        static void Main(string[] args)
        {
            //Delegateeee

            //passing method as a parameter
            //calcDel c1 = new calcDel(program.Add);
            //calcDel<int> c1 = new calcDel<int>(program.Add);
            //calcDel<int> c1 = delegate (int num1, int num2)//You can do if you are always going to use the ref to use the method
            //{
            //    return (num1 + num2);
            //};

            //calcDel<int> c1 = (int num1, int num2) => (num1 + num2);


            //predefined delegate type; func -> return val, predicate -> bool val , action -> no return type
            //Func<int, int, int> c1 = (num1, num2) => (num1 + num2);
            //program.Calculate(c1);

            //calcDel1 c = new calcDel1(program.Subtract);


            //program.Calculate1(c);
            //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
            ////select * from numbers where num>80
            //// var another = from n in numbers where n > 80 select n;
            ///LINQ

            //var another = numbers.Where(n => n > 80);
            //foreach (int n in another)
            //    Console.WriteLine(n);



            List<string> names = new List<string>() { "Pavi", "Roke", "Viji", "Pazh", "Sai"};
            List<string> orderedNames = names.OrderBy(n => n).ToList();
            foreach (var name in orderedNames) {
                Console.WriteLine(name);
            }

            //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };

            //Console.WriteLine("Even catcher");
            //int[] evenNumebrs = numbers.EvenCatch();
            //foreach (int n in evenNumebrs)
            //    Console.WriteLine(n);

            //Console.WriteLine("Odd catcher");
            //int[] oddNumebrs = numbers.OddCatch();
            //foreach (int n in oddNumebrs)
            //    Console.WriteLine(n);

            //string message = "Hello World";
            //message = message.Reverse();
            //Console.WriteLine(message);
        }
    }

    //Extension methods
    //No parameter is passed  but consider the obj this as parameter.
    public static class StringMethods
    {
        public static string Reverse(this string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
    public static class NumberExtension
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
                if (num % 2 == 0)
                    result.Add(num);
            return result.ToArray();
        }
        public static int[] OddCatch(this int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
                if (num % 2 != 0)
                    result.Add(num);
            return result.ToArray();
        }
    }
}
