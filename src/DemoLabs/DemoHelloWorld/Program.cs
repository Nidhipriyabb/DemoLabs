namespace DemoHelloWorld
{

    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <seealso cref="Program.GetNumber(string)"/>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int i = 10;             // example of inline comment
            Console.WriteLine("The value of i is: " + i);

            /*  example of block comment */
            int a = GetNumber("Enter the first number :");
            int b = GetNumber("Enter the second number :");
            int result = Add( a, b );

            Console.WriteLine("Sum of {0} and {1} is {2}", a, b, result);
        }

        /// <summary>
        /// Calculates the sum of two integers.
        /// </summary>
        /// <param name="a">The first integer to add.</param>
        /// <param name="b">The second integer to add.</param>
        /// <returns>The sum of the two specified integers.</returns>
        static int Add(int a, int b )
        { 
            return a + b;
        }


        /// <summary>
        /// Reads a line of input from the console after displaying the specified prompt and attempts to parse it as an
        /// integer.
        /// </summary>
        /// <remarks>If the user enters a non-integer value, a FormatException will be thrown. If the user
        /// presses Enter without typing any input, the method returns -1.</remarks>
        /// <param name="prompt">The message to display to the user before reading input from the console.</param>
        /// <returns>The integer value parsed from the user's input. Returns -1 if no input is provided.</returns>
        /// <exception cref="System.FormatException" />
        /// <example>
        ///     int a = GetNumber("Enter a number: ");
        /// </example>
        private static int GetNumber(string prompt)
        {
            Console.Write(prompt);
            string? input_var = Console.ReadLine();
            if (input_var is not null && input_var != "")
            {
                return int.Parse(input_var);
            }

            return -1;
        }
    }
}
