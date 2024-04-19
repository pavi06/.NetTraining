namespace BasicOfCSharp
{
    internal class Program
    {
        public class BaseClass
        {
            public void DoWork() { WorkField++; }
            public int WorkField = 0;
        }

        public class DerivedClass : BaseClass
        {
            public new void DoWork() { WorkField--; }
            public new int WorkField = 3;
        }

        public partial class Coords
        {
            private int x;
            private int y;

            public Coords(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public partial class Coords
        {
            public void PrintCoords()
            {
                Console.WriteLine("Coords: {0},{1}", x, y);
            }
        }

        public abstract class PersonalInfo
        {
            public string name = "Pavi";
            public int age=20;
            public abstract void DisplayPersonalInfo();
            public void Display() {
                Console.WriteLine("Inside the abstract class");
            }

        }

        public class DisplayInfo : PersonalInfo
        {
            public override void DisplayPersonalInfo()
            {
                Console.WriteLine($"Name : {name}");
                Console.WriteLine($"Age : {age}");
            }
        }

        void UnderstandingJaggedArray()
        {
            string[][] posts = new string[4][];
            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine("Please enter the number of columns");
                int count = Convert.ToInt32(Console.ReadLine());
                posts[i] = new string[count];
                for (int j = 0; j < count; j++)
                {
                    Console.WriteLine($"Please enter the post {i + 1} value");
                    posts[i][j] = Console.ReadLine();
                }
            }
            Console.WriteLine("Posts");
            for (int i = 0; i < posts.Length; i++)
            {
                for (int j = 0; j < posts[i].Length; j++)
                    Console.Write(posts[i][j] + " ");
                Console.WriteLine("---------------------");
            }
        }

        int Divide(int num1, int num2)
        {
            try
            {
                int result = num1 / num2;
                return result;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("You are trying to divide by zero. Its not worth");
            }
            finally
            {
                //always get executed after returning the value too.
                Console.WriteLine("Release the divide method resource");
            }
            Console.WriteLine("Your division did not go well");
            return 0;

        }

        public static void Main(string[] args)
        {
            //DerivedClass d1 = new DerivedClass();
            //d1.DoWork();
            //Console.WriteLine(d1.WorkField);
            //Coords myCoords = new Coords(10, 15);
            //myCoords.PrintCoords();

            //DisplayInfo info = new DisplayInfo();
            //info.DisplayPersonalInfo();

            //Student student = new Student() { Name = "Ramu", Id = 101 };
            //student[0] = "C";
            //student[1] = "Java";
            //student[2] = "C#";
            //Console.WriteLine(student);

            //two dimensional array
            //Student[] students = new Student[3];
            //students[0] = new Student() { Name = "Ramu", Id = 101 };
            //students[0][0] = "C";
            //students[0][1] = "Java";
            //students[0][2] = "C#";
            //Console.WriteLine(students[0]["Java"]);
            //Program program = new Program();
            //program.UnderstandingJaggedArray();


            //int num1, num2, result;
            //try
            //{
            //    num1 = Convert.ToInt32(Console.ReadLine());
            //    num2 = Convert.ToInt32(Console.ReadLine());
            //    result = num1 / num2;
            //    Console.WriteLine(result);
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine(fe.Message);
            //    Console.WriteLine("The given data could not be converted to number.");
            //}
            //catch (DivideByZeroException dbze)
            //{
            //    Console.WriteLine("You are trying to divide by zero. Its not worth");
            //}
            //Console.WriteLine("Bye bye");

            int num1, num2, result;
            try
            {
                num1 = Convert.ToInt32(Console.ReadLine());
                num2 = Convert.ToInt32(Console.ReadLine());
                result = new Program().Divide(num1, num2);
                Console.WriteLine(result);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("The given data could not be converted to number.");
            }
            Console.WriteLine("Bye bye");
        }
    
    }
}
