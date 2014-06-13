using System;
//Write a program that reads a number N and calculates the sum of the first N members
//of the sequence of Fibonacci:
//0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
//Each member of the Fibonacci sequence (except the first two) is a sum of the previous
//two members.

class fibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter first N numbers of Fibonacci numbers:");
        uint N = uint.Parse(Console.ReadLine());
        uint saveNumber = 0;
        uint saveSecondNumber = 1;
        uint result=1;
        //use loops to fined fibonacci numbers and get sum
        for (uint i = 0; i < N; i++)
        {
            result += (saveSecondNumber + saveNumber);
            saveNumber = saveSecondNumber;
            saveSecondNumber = result;
        }
        Console.WriteLine("Sum of first {0} Fibonacci numbers: {1} ", N, result);
    }
}

