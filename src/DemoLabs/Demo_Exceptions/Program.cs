using System;
using Demo_Exceptions_ClassLib;

using Microsoft.VisualBasic;

namespace Demo_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a;
                System.Console.Write("Enter the first number: ");
                int.TryParse(Console.ReadLine(), out a);

ErrLine:

                Console.Write("Enter the second number: ");
                int.TryParse(Console.ReadLine(), out int b);        // C# 12 inline declaration for OUT parameter

                // Demo_Exceptions_ClassLib.Calculator objCalc = new Demo_Exceptions_ClassLib.Calculator();
                Calculator objCalc = new Calculator();

                if(b == 0)
                {
                    Console.WriteLine("Sorry!  Second number cannot be ZERO");
                    goto ErrLine;
                }

                decimal result = objCalc.Divide(a, b);
                Console.WriteLine("Result = " + result.ToString());
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.WriteLine("--- Something went wrong - CAUGHT BY MAIN()");
                Console.WriteLine("Message: {0}", exp.Message);
                Console.WriteLine("Source: {0}", exp.Source);
                Console.WriteLine("TargetSite: {0}", exp.TargetSite);
                Console.WriteLine("GetType: {0}", exp.GetType());

                while(exp.InnerException is not null)
                {
                    Console.WriteLine("\n\n ----- Inner Exception details");
                    Console.WriteLine("\n\n Message: {0}", exp.Message);
                    Console.WriteLine("\n\n Source: {0}", exp.Source);
                    Console.WriteLine("\n\n TargetSite: {0}", exp.TargetSite);
                    Console.WriteLine("\n\n GetType: {0}", exp.GetType());

                    exp = exp.InnerException;
                }

                Console.WriteLine();
            }


            Console.WriteLine("Thank you for using my App!");
        }
    }
}
