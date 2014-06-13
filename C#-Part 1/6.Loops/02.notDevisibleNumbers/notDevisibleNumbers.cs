using System;
//Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

class notDevisibleNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int N = int.Parse(Console.ReadLine());
        for (int i = 1; i <= N; i++)// Loops 1 to N
        {
            if (i %21 != 0)
            {
                Console.WriteLine(i);
            }
           
        }
    }
}

