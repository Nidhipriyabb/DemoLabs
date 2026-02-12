using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Demo_Threads
{

    // Asynchronous code
    class Demo2
    {
        public static void DoThis()
        {
            Console.WriteLine("-- called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            System.Threading.Thread.Sleep(3000);

            // NOTE: this output appears after EXITING MAIN!!
            //       since no .JOIN() was invoked for the thread
            Console.WriteLine("-- after waking up in DoThis, on Thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public static void RunThis()
        {
            Console.WriteLine("Running in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            // ThreadStart objD = new ThreadStart(Demo2.DoThis);
            // Thread t = new Thread(objD);

            Thread t1 = new Thread(new ThreadStart(Demo2.DoThis));
            t1.Start();

            Console.WriteLine("Doing something else in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("--- in the RunThis() method on Thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
