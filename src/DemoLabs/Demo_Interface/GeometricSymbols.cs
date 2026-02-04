using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Demo_Interface
{
    public interface IRectangle
    {
        int Length { get; }
        int Breadth { get; }
        decimal Area();
    }

    public interface ISquare
    {
        int Side { get; }
        decimal Area();
    }

    public enum Shapes
    {
        Square,
        Rectangle
    }

    class Quadrilateral : IRectangle, ISquare
    {
        int side1, side2, side3, side4;
        Shapes shape;

        public Quadrilateral(int side)
        {
            side1 = side2 = side3 = side4 = side;
            shape = Shapes.Square;
        }

        public Quadrilateral(int length, int breadth)
        {
            side1 = side3 = length;
            side2 = side4 = breadth;
            shape = Shapes.Rectangle;
        }

        public int Side
        {
            get { return side1; }
        }

        public int Length
        {
            get { return side1; }
        }

        public int Breadth
        {
            get
            {
                return side2;
            }
        }

        public decimal Area()
        {
            if( shape == Shapes.Square )
            {
                return this.Side * this.Side;
            }
            else if ( shape == Shapes.Rectangle)
            {
                return this.Length * this.Breadth;
            }

            return -1;
        }
    }
}
