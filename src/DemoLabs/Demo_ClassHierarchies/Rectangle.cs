using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_ClassHierarchies
{
    public class Rectangle : Quadrilateral
    {
        public int Length
        {
            get
            {
                return base.side1;
            }
            set
            {
                base.side1 = base.side3 = value;
            }
        }

        public int Breadth
        {
            get
            {
                return base.side2;
            }
            set
            {
                base.side2 = base.side4 = value;
            }
        }


        public Rectangle(int length, int breadth)
        {
            base.side1 = base.side3 = length;
            side2 = side4 = breadth;
        }


        public override decimal Area()
        {
            return this.Length * this.Breadth;
        }
    }
}
