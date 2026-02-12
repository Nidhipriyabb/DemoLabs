namespace Demo_NewTypes
{
    internal class Demo_ComplexNumber
    {
        internal static void RunThis()
        {
            Console.WriteLine("--- Demo of Complex DataType (ValueType)");

            System.Numerics.Complex numberComplex 
                = new System.Numerics.Complex(real: 1, imaginary: 2);

            Console.WriteLine(numberComplex);
            Console.WriteLine($"Real: {numberComplex.Real}");
            Console.WriteLine($"Imaginary: {numberComplex.Imaginary}");
            Console.WriteLine($"Phase: {numberComplex.Phase}");
            Console.WriteLine($"Magnitude: {numberComplex.Magnitude}");
            Console.WriteLine();
        }
    }
}
