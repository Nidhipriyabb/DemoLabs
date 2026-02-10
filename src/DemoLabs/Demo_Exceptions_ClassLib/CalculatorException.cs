using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Exceptions_ClassLib
{
    // SHOULD HAVE THREE CONSTRUCTORS:
    // (A) with default error message
    // (B) with the error message
    // (C) with error message and innerException
    public class CalculatorException : System.ApplicationException // System.Exception
    {
        private const string DEFAULTERRORMESSAGE
            = "Something went wrong in the Calculator";

        public CalculatorException() : this(DEFAULTERRORMESSAGE) 
        { 
        }

        public CalculatorException(string message) 
            : base(message)
        {
        }

        public CalculatorException(string message,  Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
