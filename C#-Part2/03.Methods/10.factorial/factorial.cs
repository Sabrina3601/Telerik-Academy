//Write a program to calculate n! for each n in the range [1..100]. 
//Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;
using System.Numerics;

class factorial
{

    static BigInteger Factorial(int number)
    {
        BigInteger save = 1;
        BigInteger factorial = 0;
        for (int i = number; i <= 100; i++)
        {
            for (int j = i; j > 0; j--)
            {
                save *= j;
            }
            factorial += save;
            save = 1;
        }
        return factorial;
    }
    static void Main()
    {
        Console.WriteLine("Give a number between 1 and 100");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(  Factorial(number) );
    }
}

