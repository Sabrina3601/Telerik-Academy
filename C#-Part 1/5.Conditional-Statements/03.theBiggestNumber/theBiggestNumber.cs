//Write a program that finds the biggest of three integers using nested if statements.
using System;

class theBiggestNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a first number");
        double numberFirst = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a second number");
        double numberSecond = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a third number");
        double numberThird = double.Parse(Console.ReadLine());
        // just check which is the bigger number with if statements
        if (numberFirst > numberSecond && numberFirst > numberThird) 
        {
            Console.WriteLine(numberFirst + " is the biggest number");
        }
        else if (numberSecond > numberFirst && numberSecond > numberThird)
        {
            Console.WriteLine(numberSecond + " is the biggest number");
        }
        else if (numberThird > numberFirst && numberThird > numberSecond)
        {
            Console.WriteLine(numberThird + " is the biggest number");
        }
    }
}
