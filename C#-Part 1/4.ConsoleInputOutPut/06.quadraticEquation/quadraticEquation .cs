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
        if (d<0)
        {
            Console.WriteLine("uravnenieto nqma realni koreni");
        }
        if (d == 0)
        {
            firstX = -b / (2 * a);
            Console.WriteLine("Uravnenieto ima edin dvoen koren:" + firstX);
        }
        if (d>0)
        {
            firstX = (-b + Math.Sqrt(d)) / (2 * a);
            secondX = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine(firstX + " " + secondX);
        }


    }
}

