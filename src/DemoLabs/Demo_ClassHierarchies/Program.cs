namespace Demo_ClassHierarchies
{
    internal class Program
    {

        static void ShowInfoByOverload(Rectangle objRect)
        {
            Console.WriteLine("---- calling the Overloaded version for Rectangle");
            Console.WriteLine("Area of Rectangle with Length: {1}, Breadth: {2} is {0}",
                objRect.Area(), objRect.Length, objRect.Breadth);
            Console.WriteLine("Perimeter of Rectangle: {0}", objRect.Perimeter);
            Console.WriteLine();
        }

        static void ShowInfoByOverload(Square objSquare)
        {
            Console.WriteLine("---- calling the Overloaded version for Square");
            Console.WriteLine("Area of Square with Side: {1} is {0}",
                objSquare.Area(), objSquare.Side);
            Console.WriteLine("Perimeter of Square: {0}", objSquare.Perimeter);
            Console.WriteLine();
        }


        static void ShowInfoUsingInheritance(Quadrilateral objQuad)
        {
            Console.WriteLine("---- calling the Inheritence version");
            if (objQuad.GetType() == typeof(Square))
            {
                Square objSquare = (Square)objQuad;         // unboxing
                Console.WriteLine("Area of Square with Side: {1} is {0}",
                    objSquare.Area(), objSquare.Side);
                Console.WriteLine("Perimeter of Square: {0}", objSquare.Perimeter);
            }
            // else if ( objQuad.GetType() == typeof(Rectangle) )
            else if ( objQuad is Rectangle )        // IS (type checking operator)
            {
                // Rectangle objRect = (Rectangle)objQuad;
                Rectangle? objRect = objQuad as Rectangle;      // AS Operator is a TYPE SAFE CONVERSION
                if (objRect is not null)
                {
                    Console.WriteLine("Area of Rectangle with Length: {1}, Breadth: {2} is {0}",
                        objRect.Area(), objRect.Length, objRect.Breadth);
                    Console.WriteLine("Perimeter of Rectangle: {0}", objRect.Perimeter);
                    Console.WriteLine();
                }
            }
        }


        static void Main(string[] args)
        {
            Rectangle objRect = new Rectangle(10, 5);
            //Console.WriteLine("Area of Rectangle with Length: {1}, Breadth: {2} is {0}", 
            //    objRect.Area(), objRect.Length, objRect.Breadth);
            //Console.WriteLine("Perimeter of Rectangle: {0}", objRect.Perimeter);
            //Console.WriteLine();
            ShowInfoByOverload(objRect);
            ShowInfoUsingInheritance(objRect);      // implicitly boxing

            // object o = objRect;                     // explicitly boxing
            // ShowInfoUsingInheritance(o);


            Square objSquare = new Square(20);
            //Console.WriteLine("Area of Square with Side: {1} is {0}",
            //    objSquare.Area(), objSquare.Side);
            //Console.WriteLine("Perimeter of Square: {0}", objSquare.Perimeter);
            //Console.WriteLine();
            ShowInfoByOverload(objSquare);
            ShowInfoUsingInheritance(objSquare);


            GeometricSymbols objGeo;
            objGeo = new Square(30);
            Console.WriteLine("Area of GeometricSymbol (Square) with Side: {1} is {0}",
                objGeo.Area(), ((Square)objGeo).Side);
            Console.WriteLine("Perimeter of Rectangle: {0}", ((Square)objGeo).Perimeter);


        }
    }

}
