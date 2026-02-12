namespace Demo_Threads
{

    // Asynchronous code
    class Demo3
    {
        public static void DoThis(object? obj)
        {
            Console.WriteLine("-- called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("-- received: {0}", obj);
        }

        public static void RunThis()
        {
            Console.WriteLine("Running in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            // ParameterizedThreadStart objD = new ParameterizedThreadStart(Demo3.DoThis);
            // Thread t = new Thread(objD);
            Thread t1 = new Thread(new ParameterizedThreadStart(Demo3.DoThis));
            t1.Start(10);        // obj

            Console.WriteLine("Doing something else in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            Thread t2 = new Thread(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("-- anonymous method called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            });
            t2.Start();


            t1.Join();
            t2.Join();

            Console.WriteLine("--- back in the main Thread {0}", Thread.CurrentThread.ManagedThreadId);

        }
    }
}
