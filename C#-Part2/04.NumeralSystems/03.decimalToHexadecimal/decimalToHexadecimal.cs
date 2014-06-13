//Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;
class decimalToHexadecimal
{
    static List<string> ToBinary(int number)
    {
        List<string> inBinary = new List<string>();
        int element = 0;
        while (number > 0)
        {
            element = number % 16;
            if (element < 10) inBinary.Add(element.ToString());//change number 10 to 15 with their hex value
            else if (element == 10) inBinary.Add("A");
            else if (element == 11) inBinary.Add("B");
            else if (element == 12) inBinary.Add("C");
            else if (element == 13) inBinary.Add("D");
            else if (element == 14) inBinary.Add("E");
            else if (element == 15) inBinary.Add("F");
            number = number / 16;
        }
        inBinary.Reverse();
        return inBinary;
    }
    static void Main()
    {
        int number = int.Parse(Console.ReadLine()); //enter a number
        List<string> inBinary = ToBinary(number);
        for (int i = 0; i < inBinary.Count; i++)
        {
            Console.Write(inBinary[i]);
        }
        Console.WriteLine();
    }
    
}

