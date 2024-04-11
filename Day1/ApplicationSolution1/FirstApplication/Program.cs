
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstApplication
{
    internal class Program
    {
        static int Add(int num1, int num2) {
            //raise Exception if value goes out of limit
            checked
            {
                int result = num1 + num2;
                return result;
            }
;        }

        static int Takenum()
        {
            int num;
            Console.WriteLine("Enter the the number");
            //tryparse takes 2 param bool and out 
            //Exception is handled
            while (int.TryParse(Console.ReadLine(), out num) == false)
                Console.WriteLine("Invalid value. Please enter a number");
            //null collaing
            //num = int.Parse(Console.ReadLine()??"0");
            //string data = Console.ReadLine();
            //num = int.Parse(data == null ? "0" : data);

            //if toint32 work fine no need of null check
            //num = Convert.ToInt32(Console.ReadLine());
            return num;
        }

        static void Calculating()
        {
            int num1 = Takenum();
            int num2 = Takenum();
            int sum = Add(num1,num2);
            PrintCalculatedVal(sum,"Sum");
        }

        private static void PrintCalculatedVal(int sum,string ops)
        {
            Console.WriteLine($"The {ops} is {sum}");
        }


        static bool ConvertName(string name, out string msg)
        {
            //Outparameter can be used with any method and any no of out param can be used
            msg = "";
            if (name is null)
                return false;
            msg = "Welcome " + name + " !!!";
            return true;
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //int num1 = 10,num2=100,num3=3;
            ////interpolation
            //Console.WriteLine($"The value of num1 is {num1} and value of num2 is {num2}");
            //Console.WriteLine($"The sum of two nums is {num1+num2}");
            ////concatenation
            //Console.WriteLine($"The value of num3 is {num3}");

            //--------------------------------------------------------------
            //string name;
            //Console.WriteLine("Enter your name: ");
            //name= Console.ReadLine();
            //Console.WriteLine($"Hello {name}");
            //int age;
            //Console.WriteLine("Enter your age: ");
            //age = int.Parse(Console.ReadLine());
            ////readline will read as age string so its not compatable with int thus parse it

            //string val = "25";
            //age = Convert.ToInt32(val);
            //age++;
            ////bit-slow-process
            //Console.WriteLine($"Your age last year is {age}");


            //-------------------------------------------------------------
            //float fNum1,fNum2;
            //int iNum2;
            //Console.WriteLine("Please enter a number");
            //fNum1 = Convert.ToSingle(Console.ReadLine());//unboxing -> ref(heap) to val(mem)

            //iNum2 = (int)fNum1;//explicit casting -> high to low
            //fNum2 = iNum2 - 10;//implicit casting
            //Console.WriteLine($"The number is {fNum1}");
            //Console.WriteLine($"int val {iNum2}");
            //string num3 = iNum2.ToString();//boxing

            //----------------------------------------------------------------------
            //int n = int.MaxValue;
            //n++;
            //Console.WriteLine(n);

            //--------------------------------------------------------------------------
            Calculating();

            //-------------------------------------------------------------------------
            //Nullable int
            //int? num2 = null;
            //num2 = num2 ?? 0;
            //Console.WriteLine(num2);


            //--------------------------------------------------------------------
            //Out parameter
            //return Value first and then out parameter
            //string message;
            //bool result = ConvertName("Pavi", out message);
            //if (result == true)
            //    Console.WriteLine(message);
            //else
            //    Console.WriteLine("Invalid name");

        }
    }
}
