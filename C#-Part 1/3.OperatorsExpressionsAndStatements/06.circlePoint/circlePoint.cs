using System;

class circlePoint
{
    static void Main()
    {
        Console.WriteLine("Give a point x");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Give a point y");
        double y = double.Parse(Console.ReadLine());
        double radius = 5;

        if ((x * x) + (y * y) <= radius * radius) //Math formula to check if given point is in circle
        {
            Console.WriteLine("Given point is within a circle");
        }
        else
        {
            Console.WriteLine("Given point is out of circle");
        }
    }
}
