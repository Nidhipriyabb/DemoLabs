using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_ClassHierarchies
{
    public abstract class Quadrilateral : GeometricSymbols
    {
        protected int side1, side2, side3, side4;

        public int Perimeter 
        {
            get
            {
                return side1 + side2 + side3 + side4;
            }
        }
    }
}
