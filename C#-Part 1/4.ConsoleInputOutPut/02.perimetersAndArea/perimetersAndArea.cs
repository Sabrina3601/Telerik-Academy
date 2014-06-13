using System;

class perimetersAndArea
{
    static void Main()
    {
        Console.WriteLine("Enter a radius of circle:");
        double r = double.Parse(Console.ReadLine());
        double perimeter = 2 * r * Math.PI;
        double area = r * r * Math.PI;

        Console.WriteLine("Perimeter = {0:0.00}", perimeter); //print perimeter
        Console.WriteLine("Area = {0:0.00}", area); //print area
    }
}

