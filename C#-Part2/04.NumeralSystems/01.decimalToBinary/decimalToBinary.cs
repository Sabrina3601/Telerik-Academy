//Write a program to convert decimal numbers to their binary representation.

using System;
using System.Collections.Generic;

class decimalToBinary
{
    static List<int> ToBinary(int number)
    {
        List<int> inBinary = new List<int>();
        while (number > 0)
        {
            inBinary.Add(number % 2); // that is one of option to convert decimal to binary num
            number = number / 2;
        }
        inBinary.Reverse();
        return inBinary;
    }
    static void Main()
    {
        int number = int.Parse(Console.ReadLine()); // enter a number
        List<int> inBinary = ToBinary(number);
        for (int i = 0; i < inBinary.Count; i++)
        {
            Console.Write(inBinary[i]);
        }
        Console.WriteLine();
    }
}

