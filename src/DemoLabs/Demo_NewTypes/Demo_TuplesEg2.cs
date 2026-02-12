using System.Diagnostics;

namespace Demo_NewTypes
{
    internal class Demo_TuplesEg2
    {
        internal static void RunThis()
        {
            Demo1();

            Demo2();
        }

        private static void Demo1()
        {
            Point[] triangle = new Point[3];
            triangle[0] = new Point { x = 2, y = 0 };           // triangle Point A
            triangle[1] = new Point { x = 10, y = 5 };           // triangle Point B
            triangle[2] = new Point { x = 10, y = 18 };           // triangle Point C

            Point[] triangle2 = new Point[3]
            {
                new Point { x = 2, y = 0 },           // triangle Point A
                new Point { x = 2, y = 0 },           // triangle Point B
                new Point { x = 2, y = 0 }           // triangle Point C
            };
        }

        private static void Demo2()
        {
            Tuple<int, int, int> triangle = new Tuple<int, int, int>(2, 5, 18);
            Console.WriteLine("Triangle {0}", triangle);
            Console.WriteLine("Perimeter: {0}", triangle.Item1 + triangle.Item2 + triangle.Item3);
            Console.WriteLine("Type: {0}", triangle.GetType());
            Console.WriteLine();

            Tuple<Point, Point, Point> triangle3D
                = new Tuple<Point, Point, Point>
                (
                    new Point { x = 2, y = 5 },           // triangle Point A
                    new Point { x = 5, y = 10 },          // triangle Point B
                    new Point { x = 2, y = 34 }           // triangle Point C
                );
            Console.WriteLine("Co-ordinates of the 3D Triangle");
            Console.WriteLine("Point A: {0} {1}", triangle3D.Item1.x, triangle3D.Item1.y);
            Console.WriteLine("Point B: {0} {1}", triangle3D.Item2.x, triangle3D.Item2.y);
            Console.WriteLine("Point C: {0} {1}", triangle3D.Item3.x, triangle3D.Item3.y);
            Console.WriteLine();
            Console.WriteLine($"Point A: {triangle3D.Item1}");
            Console.WriteLine($"Point A: {triangle3D.Item2}");
            Console.WriteLine($"Point A: {triangle3D.Item3}");
            Console.WriteLine();
        }
    }


    struct Point
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return String.Format($"( x: {this.x}, y: {this.y} )");
        }
    }

}
