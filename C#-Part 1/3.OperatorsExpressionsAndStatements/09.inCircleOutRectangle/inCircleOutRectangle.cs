using System;

class inCircleOutRectangle
{
    static void Main()
    {
        Console.WriteLine("Give a point x");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Give a point y");
        double y = double.Parse(Console.ReadLine());
        double radius = 5;
        bool circle = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= radius * radius; //it's a math formula
        bool retangle = (((x < -1) || (x > 5)) || ((y > 1) || (y < -1)));

        if (circle == true && retangle == false)
        {
            Console.WriteLine("The given point is in circle only");
        }
        if (circle == false && retangle == true)
        {
            Console.WriteLine("The given point is in rectangle only");
        }
        if (circle == true && retangle == true)
        {
            Console.WriteLine("The given point is in circle and rectangle in the same time"); // The given point is in only if both of value is true
        }
        if (circle == false && retangle == false)
        {
            Console.WriteLine("The given point outside of circle and rectangle in the same time ");
        }
    }
}

