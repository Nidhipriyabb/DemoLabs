namespace Demo_Exceptions_ClassLib
{
    // MEMBERS of a Type are by default PRIVATE
    // Members of a Namespace are by default INTERNAL
    public class Calculator
    {

        public int Add(int x, int y)
        {
            return x + y; 
        }

        public int Divide(int x, int y)
        {
            Console.WriteLine("----- Divide was called!");
            int result = -1;

            //if(y == 0)
            //{
            //    throw new CalculatorException("Sorry!  Second Argument cannot be ZERO");
            //}

            try
            {
                result = x / y;
            }
            catch(System.DivideByZeroException exp)
            {
                // throw new ArgumentException("Sorry!  Second Argument cannot be ZERO");
                // throw new CalculatorException("Sorry!  Second Argument cannot be ZERO");
                throw new CalculatorException(
                    message: "Sorry!  Second Argument cannot be ZERO",
                    innerException: exp);
            }
            catch (System.Exception exp)
            {
                Console.WriteLine();
                Console.WriteLine("\t--- Something went wrong in the ClassLibrary!");
                Console.WriteLine("\tMessage: {0}", exp.Message);
                Console.WriteLine("\tSource: {0}", exp.Source);
                Console.WriteLine("\tTargetSite: {0}", exp.TargetSite);
                Console.WriteLine("\tGetType: {0}", exp.GetType());
                Console.WriteLine();

            }

            result = x / y;
            return result; 
        }
    }
}
