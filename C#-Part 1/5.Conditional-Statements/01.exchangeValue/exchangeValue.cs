//Write an if statement that examines two integer variables
//and exchanges their values if the first one is greater than the second one.
using System;

class exchangeValue
{
    static void Main()
    {
        Console.WriteLine("Enter a first number");
        int first = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a second number");
        int second = int.Parse(Console.ReadLine());
        int third;
        if (first>second)//check which is bigger
        {
            third = first;
            first = second;
            second = third;//exchange values
            Console.WriteLine("Exchange values of first and second number: first = {0}; second = {1}", first, second);
        }
        else
        {
            Console.WriteLine("Can't do exchange of numbers because second number is biger than first number");
        }
    }
}

