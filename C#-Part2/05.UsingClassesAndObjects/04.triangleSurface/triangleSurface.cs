//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.


using System;

class triangleSurface
{
    static double GetSurfaceBySideAndAltitude(int a, int h)
    {
        double surface = (a * h) / 2; // S = a*h /2
        return surface;
    }

    static double GetSurfaceByThreeSide(int a, int b, int c)
    {
        double p = (a * b * c)/2;
        double result = Math.Sqrt(p*(p-a)*(p-b)*(p-c)); 
        return result;
    }
    static double GetSurfaceByTwoSideAndAngle(int a, int b, int angle)
    {
        double surface = (a * b * Math.Sin(Math.PI * angle / 180)) / 2; // S=(a*b*sin(y)) / 2
        return surface;
    }
    static void Main()
    {
        Console.WriteLine("Surface of triangle is: {0}", GetSurfaceBySideAndAltitude(3,6));
        Console.WriteLine("Surface of triangle is: {0}", GetSurfaceByThreeSide(3,4,5));
        Console.WriteLine("Surface of triangle is: {0}", GetSurfaceByTwoSideAndAngle(3, 4, 60));
    }
}

