namespace Demo_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process objProcess = new Process();

            // explicitly instantiating the delegate variable and passing it to the method
            Console.WriteLine("--- Running the Delegate call example");
            ProgressHandler? objD = null;
            objD += new ProgressHandler(Program.ShowUpdates);               
            objProcess.DoSomethingUsingCallbackDelegate(objD);                       // explicit instance

            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //// implicitly using the delegate variable instantiation.
            //Console.WriteLine("--- Running the Delegate call example");
            //objProcess.DoSomethingUsingCallbackDelegate(Program.ShowUpdates);        // boxing

            //Console.Write("\n\nPress any key to continue...");
            //Console.ReadKey();
            //Console.Clear();

            Console.WriteLine("---- Running the Event example");
            objProcess.OnProgressUpdate 
                += new ProgressHandler(Program.ShowUpdates);     //subscribe to the event!
            objProcess.DoSomethingUsingEvents();

            Console.Write("\n\nPress any key to exit...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ShowUpdates(int percentage)
        {
            Console.WriteLine("\nCompleted: {0} percentage, running on Thread: {1}", 
                percentage, System.Threading.Thread.CurrentThread.ManagedThreadId );
        }
    }
}
