namespace Demo_Strings
{
    // 1. String Interpolation
    // 2. String Builder
    // 3. String is Immutable

    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "hello world";
            Console.WriteLine( s );
            Console.WriteLine( "{0}", s );
            Console.WriteLine( "{0}", s.ToUpper() );
            Console.WriteLine("{0,30}", s.ToUpper());
            Console.WriteLine();

            Console.WriteLine($"{s.ToUpper()}");
            Console.WriteLine($"{s.ToUpper(), 30}");
            Console.WriteLine();

            decimal salary = 300.75m;
            Console.WriteLine( salary );
            Console.WriteLine( "{0:C, 15}", salary );
            Console.WriteLine( $"{salary:C, 15}" );

            int x = 10 + 20 + 3;
            string y = "hello" + " " + "world";


            string output;
            Console.WriteLine( "Running the legacy string building mode" );
            output = m(1);
            Console.WriteLine();

            Console.WriteLine("Running the String.Format version");
            output = m(2);
            Console.WriteLine();

            Console.WriteLine("Running the String Interpolation version");
            output = m(3);
            Console.WriteLine();

            Console.WriteLine("Running the String Builder version");
            output = m(4);
            Console.WriteLine();

            // Strings are IMMUTABLE
            string greet = "hello world";
            // greet[4] = 'x'                           // 1. cannot change a member
            string greet2 = greet;                      // 2. does not provide a reference <- gives COPY
            greet2 = "another world";
            Console.WriteLine( greet2 );        // "another world"
            Console.WriteLine(greet);           // "hello world"

        }

        private static string m(int mode)
        {

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string retVal = string.Empty;

            for (int i = 0; i < 10000; i++)
            {
                // retVal += "hello world\n";

                // retVal += "hello world " + i + 1 + "\n";         // "01", "11", "21", "31" ....

                if (mode == 1)
                {
                    // legacy version
                    retVal += "hello world " + (i + 1) + "\n";       // 1, 2, 3, 4 ...
                }
                else if (mode == 2)
                {
                    // string.Format version
                    retVal += string.Format("hello world {0}\n", i + 1); // more efficient
                }
                else if (mode == 3)
                {
                    // String Interpolation version
                    retVal += $"hello world {i + 1}\n";
                }
                else if (mode == 4)
                {
                    sb.AppendFormat("hello world {0}\n", i + 1);
                }
            }

            if (mode == 4)
            {
                retVal = sb.ToString();         // extract the string from the StringBuilder
            }

            stopwatch.Stop();
            Console.WriteLine("Elapsed TICKS: {0}", stopwatch.ElapsedTicks);

            return retVal;
        }
    }
}
