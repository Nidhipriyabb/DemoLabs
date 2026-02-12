namespace Demo_Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demo1.RunThis();         // synchronous example

            // Demo2.RunThis();         // shows ThreadStart & no join
            // Demo3.RunThis();         // shows ParameterisedThreadStart and Join

            Demo4.RunThis();

            Console.WriteLine();
            Console.WriteLine("--- exiting main()");
        }
    }
}
