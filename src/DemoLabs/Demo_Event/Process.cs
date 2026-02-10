namespace Demo_Event
{

    public delegate void ProgressHandler(int percentage);

    public class Process
    {
        public event ProgressHandler? OnProgressUpdate;

        public void DoSomethingUsingEvents()
        {
            for(int i = 1; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("{0:00} running on Thread: {1}", 
                    i, System.Threading.Thread.CurrentThread.ManagedThreadId);

                if (i % 10 == 0)            // on completion of every 10%, raise the event
                {
                    // check if the Event is "subscribed"
                    if (OnProgressUpdate is not null)
                    {
                        OnProgressUpdate(i);            // Raise the Event
                    }
                }
            }
        }


        public void DoSomethingUsingCallbackDelegate(ProgressHandler? objD)
        {
            for (int i = 1; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("{0:00} running on Thread: {1}",
                    i, System.Threading.Thread.CurrentThread.ManagedThreadId);

                if (i % 10 == 0)
                {
                    // check if delegate is "subscribed"
                    if (objD is not null)
                    {
                        objD(i);            // invoke the method pointed to by the Delegate
                    }
                }

            }
        }

    }
}
