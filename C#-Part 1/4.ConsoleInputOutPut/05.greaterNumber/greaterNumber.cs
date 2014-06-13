using System;

class greaterNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a first number:");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a second number:");
        int secondNumber = int.Parse(Console.ReadLine());

        int result = Math.Max(firstNumber, secondNumber); //check bigger number
        Console.WriteLine("bigger number is " + result);
    }
}

