namespace Demo_NewTypes
{
    internal class Demo_DynamicType
    {
        internal static void RunThis()
        {
            Demo1();
            Demo2();
            Demo3();
        }

        private static void Demo1()
        {
            Console.WriteLine("---- Demo of a typical C# developer writing code");

            Calculator calc = new Calculator();
            int result = calc.Add(10, 20);                          // establish compile-time binding.
            Console.WriteLine($"Sum of 10 and 20 = {result}");
            Console.WriteLine();
        }


        private static void Demo2()
        {
            Console.WriteLine("---- Demo showing how Reflection can help invoke the method");

            // establish a run-time binding to invoke the method call
            object objCalc = new Calculator();
            Type calcType = objCalc.GetType();
            object? resultObject = calcType.InvokeMember("Add",      // name of the method to be invoked
                System.Reflection.BindingFlags.InvokeMethod,        // type of method
                null,
                objCalc,                                            // for the object 
                new object[] { 10, 20 });                           // arguments of the method
            if (resultObject is not null)
            {
                int result = (int)resultObject;
                Console.WriteLine($"Sum of 10 and 20 = {result}");
                Console.WriteLine();
            }
        }


        private static void Demo3()
        {
            Console.WriteLine("---- Demo of Dynamic Type");

            dynamic calc = new Calculator();
            int result = calc.Add(10, 30);
            Console.WriteLine($"Sum of 10 and 20 = {result}");
            Console.WriteLine();
        }

    }

    internal class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

}
