using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShapesProject
{
    public class Triangle: Shape
    {
        public Triangle(double width, double height)
            : base(width,height)
        {
        }

        public override double CalculateSurface()
        {
            return Height * Width / 2.0;
        }
    }
}
