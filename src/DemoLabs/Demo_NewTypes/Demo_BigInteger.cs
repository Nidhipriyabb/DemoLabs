namespace Demo_NewTypes
{
    internal class Demo_BigInteger
    {
        internal static void RunThis()
        {
            // Int8  byte
            // Int16 short
            // Int32 int
            // Int64 long

            int number = 1000;

            Console.WriteLine($"Factorial of {number} : {GetFactorialUsingLong(number)}");
            Console.WriteLine( number );

            Console.WriteLine($"Factorial of {number} : {GetFactorialUsingBigInt(number)}");
        }

        private static Int64 GetFactorialUsingLong(long num)
        {
            return num == 0 ? 1 : num * GetFactorialUsingLong(num - 1);
        }

        private static System.Numerics.BigInteger GetFactorialUsingBigInt(System.Numerics.BigInteger num)
        {
            return num == 0 ? 1 : num * GetFactorialUsingBigInt(num - 1);
        }

    }
}
