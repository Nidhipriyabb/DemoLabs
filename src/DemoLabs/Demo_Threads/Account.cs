namespace Demo_Threads
{
    class Account
    {
        private int balance;


        public Account(int initial)
        {
            this.balance = initial;
        }

        private int withdrawAmount(int amount)
        {
            int retVal;

            // This condition will never be true unless the lock statement is commented out
            if (balance < 0)
            {
                throw new ArgumentException("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out the lock keyword:
            lock (this)
            {
                if (balance >= amount)
                {
                    Console.Write("{0,15} ", this.balance);     // Balance before Withdrawal
                    Console.Write("{0,10} ", amount);           // Amount to be Withdrawn
                    this.balance -= amount;
                    Console.Write("{0,15}", this.balance);      // Balance after Withdrawal
                    Console.WriteLine(":{0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
                    retVal = amount;
                }
                else
                {
                    retVal = 0; // transaction rejected
                }
            }
            return retVal;
        }

        public void DoTransactions()
        {
            System.Random r = new System.Random();
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    withdrawAmount(r.Next(1, 100));
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine("EXCEPTION TYPE: {0}", exp.GetType());
                Console.WriteLine(exp.Message);
            }
        }

    }
}

