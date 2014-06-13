using System;

namespace Abstraction
{
    class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius cannot be negative.");
            }
            this.Radius = radius;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
