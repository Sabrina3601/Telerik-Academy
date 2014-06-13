using System;
using System.Linq;
//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

class minMax
{
    static void Main()
    {
        Console.WriteLine("Enter how many number you want to print");
        int n = int.Parse(Console.ReadLine());
        int[] holder = new int[n];
        for (int i = 0; i < n; i++)// Loops numbers to print
        { 
            holder[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Min number is " + holder.Min()); //use min and max method to find their value
        Console.WriteLine("Max number is " + holder.Max());
    }
}

