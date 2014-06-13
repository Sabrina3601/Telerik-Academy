//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
using System.Collections.Generic;
class generateRandomValue
{
    static void Main()
    {
        Random rnd = new Random();
        int[] numbers = new int[10];
        for (int i = 0; i < 10; i++)
        {
            numbers[i] = rnd.Next(101)+100;
        }
        foreach (int print in numbers)
        {
            Console.WriteLine(print);
        }
    }
}

