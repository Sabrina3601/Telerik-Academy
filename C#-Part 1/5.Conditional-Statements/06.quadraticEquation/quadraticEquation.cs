//Write a program that enters the coefficients a, b and c of a quadratic equation
//a*x2 + b*x + c = 0
//and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
using System;

class quadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter number a:");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number b:");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number c:");
        int c = int.Parse(Console.ReadLine());

        int d = ((b * b) - (4 * a * c)); // use mathematic formula
        double firstX;
        double secondX;
        //now find root
        if (d < 0)
        {
            Console.WriteLine("equation has 0 roots");
        }
        if (d == 0)//if has 1 root
        {
            firstX = -b / (2 * a);
            Console.WriteLine("equation has 1 root:" + firstX);
        }
        if (d > 0)//if has 2 roots
        {
            firstX = (-b + Math.Sqrt(d)) / (2 * a);
            secondX = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("equation has 2 roots:" + firstX + " " + secondX);
        }
    }
}
