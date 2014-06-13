using System;

class numbersSum
{
    static void Main()
    {
        Console.WriteLine("Enter first intiger");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second intiger");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter third intiger");
        int thirdNumber = int.Parse(Console.ReadLine());

        int sum = firstNumber + secondNumber + thirdNumber;
        Console.WriteLine("The sum is: " + sum); //print sum

    }
}

