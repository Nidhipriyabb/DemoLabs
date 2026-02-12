using System;
using System.Threading;

namespace Demo_Threads
{
    // Synchronous Code
    class Demo1
    {
        public static void DoThis()
        {
            Console.WriteLine("-- called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public static void RunThis()
        {
            Console.WriteLine("Running in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            DoThis();

            Console.WriteLine("Doing something else in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

    }
}
