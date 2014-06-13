using System;

class rectangleArea 
{
    static void Main()
    {
        Console.WriteLine("Enter a width of recanle");
        int width = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a height of recanle");
        int height = int.Parse(Console.ReadLine());

        int rectangleArea = width * height; // formula for rectangle's Area 
        Console.WriteLine("The area of rectangle is " + rectangleArea);
    }
}
