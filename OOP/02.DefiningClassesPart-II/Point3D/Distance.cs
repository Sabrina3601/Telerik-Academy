//Task3
//Write a static class with a static method to calculate the distance between two points in the 3D space.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public static class Distance
    {
        //method that calculates distance between two points
        public static double CalcDistance(Point3d.strPoint3d first, Point3d.strPoint3d second)
        {
             return Math.Sqrt(((first.X - second.X) * (first.X - second.X)) + ((first.Y - second.Y) * (first.Y - second.Y)) + ((first.Z - second.Z) * (first.Z - second.Z)));
        }
    }
}
