using System;
using System.Threading;

namespace Demo_Threads
{
    class Demo4
    {
        public static void RunThis()
        {
            Console.WriteLine("{0,15} {1,10} {2,15} {3}", 
                "op balance", "withdrawn", "cl balance", "THREAD ID");

            Account acc = new Account(1000);

            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
    }
}
