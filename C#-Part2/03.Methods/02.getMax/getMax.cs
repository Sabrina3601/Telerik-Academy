//Write a method GetMax() with two parameters that returns the bigger of two integers.
//Write a program that reads 3 integers from the console
//and prints the biggest of them using the method GetMax().

using System;

class getMax
{

    static int GetMax(int first, int second) 
    {
        if (first>second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int biggest = GetMax(firstNumber, secondNumber);
        biggest = GetMax(biggest,thirdNumber);
        Console.WriteLine("The biggest number is "+ biggest);
    }
}

