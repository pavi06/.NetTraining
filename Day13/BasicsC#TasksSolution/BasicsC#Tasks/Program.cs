namespace BasicsC_Tasks
{
    internal class Program
    {
        //int GetResultFromDatabaseServer()
        //{
        //    return new Random().Next();
        //}

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //    Program program = new Program();
        //    int number = program.GetResultFromDatabaseServer();
        //    Console.WriteLine("This is the random number from main" + new Random().Next());
        //    Console.WriteLine("This is the random number from server " + number);

        //}

        //async Task<int> GetResultFromDatabaseServer()
        //{
        //    Thread.Sleep(10000);
        //    return new Random().Next();
        //}

        //static async Task Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //    Program program = new Program();
        //    var number = program.GetResultFromDatabaseServer();
        //    Console.WriteLine("This is the random number from main" + new Random().Next());
        //    Console.WriteLine("This is the random number from server " + number.Result);
        //    var number1 = await program.GetResultFromDatabaseServer();
        //    Console.WriteLine(number1);
        //}

        void PrintNumbers()
        {
            //lock (this)
            //{ Thread safe code, only one thread will read/use at that time. Only if it is done , other can enter into it

            //}
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            //3 threads. -> order cannot be maintained
            Program program = new Program();
            Console.WriteLine("Before the thread call");
            Thread t1 = new Thread(program.PrintNumbers);
            t1.Name = "You";
            Console.WriteLine("Before the thread call2");
            Thread t2 = new Thread(program.PrintNumbers);
            t2.Name = "Me";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread call");
        }
    }
}
