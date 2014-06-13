using System;

class trapezoidArea 
{
    static void Main()
    {
        Console.WriteLine("Give side a on trapezoid");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Give side b on trapezoid");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Give height h on trapezoid");
        int h = int.Parse(Console.ReadLine());

        int area = ((a + b) / 2) * h; // forumla for trapezoid's Area
        Console.WriteLine("Trapezodi's area is " + area);
    }
}

