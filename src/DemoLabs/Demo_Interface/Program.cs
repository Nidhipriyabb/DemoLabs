namespace Demo_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IRectangle objRect = new IRectangle();            // COMPILER ERROR

            IRectangle objRect = new Quadrilateral(10, 2);
            Console.WriteLine("Length: {0}, Breadth: {1}, Area: {2}",
                ((Quadrilateral)objRect).Length,
                ((Quadrilateral)objRect).Breadth,
                objRect.Area());
            Console.WriteLine();

            Console.WriteLine("RECTANGLE: Length: {0}, Breadth: {1}, Area: {2}",
                objRect.Length, objRect.Breadth, objRect.Area());

            ISquare objSquare = new Quadrilateral(20);
            Console.WriteLine("SQUARE: Side: {0}, Area: {1}",
                objSquare.Side, objSquare.Area());

        }
    }
}
