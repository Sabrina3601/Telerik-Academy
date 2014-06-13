using System;
//Write a program that prints all the numbers from 1 to N.

class printNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int N = int.Parse(Console.ReadLine());
        for (int i = 1; i <= N; i++)// Loops 1 to N
        {
            Console.WriteLine(i);
        }
    }
}

