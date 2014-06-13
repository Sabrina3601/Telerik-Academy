using System;
//Write a program that calculates the greatest common divisor (GCD) of given two numbers.
//Use the Euclidean algorithm (find it in Internet).


class euclideanAlgorithm 
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter secomd number:");
        double y = double.Parse(Console.ReadLine());
        //use formula. Look wikipedia
        while (x != y)
        {
            if (x > y)
            {
                x = x - y;
            }
            else
            {
                y = y - x;
            }
        }
        Console.WriteLine("GCD = " + x);
       
    }
}

