using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Demo_ClassHierarchies
{
    public class Square : Quadrilateral
    {
        public int Side
        {
            get
            {
                return base.side1;
            }
            set
            {
                base.side1 = base.side2 = base.side3 = base.side4 = value;
            }
        }


        public Square(int side) 
        {
            base.side1 = base.side2 = base.side3 = base.side4 = side;
        }

        public override decimal Area()
        {
            return this.Side * this.Side;
        }
    }
}
