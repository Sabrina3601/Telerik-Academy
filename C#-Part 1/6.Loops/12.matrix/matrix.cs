using System;
//Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix
class matrix
{
    static void Main()
    {
        Console.WriteLine("Enter a number < 20:");
        int N = int.Parse(Console.ReadLine());

        if (N<20)
        {
            for (int i = 1; i <= N; i++)// use nestet for loops and be careful with print
            {
                Console.Write(i);
                for (int j = i + 1; j <= N - 1 + i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Sorry a number must be < 20");
        }
    }
}
