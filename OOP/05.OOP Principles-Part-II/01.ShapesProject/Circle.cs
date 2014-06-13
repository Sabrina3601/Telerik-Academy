﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShapesProject
{
    public class Circle:Shape
    {
        public Circle(double diameter)
            : base(diameter, diameter)
        {
        }

        public override double CalculateSurface()
        {
            return (Width / 2 * Height / 2) * Math.PI;
        }
    }
}
