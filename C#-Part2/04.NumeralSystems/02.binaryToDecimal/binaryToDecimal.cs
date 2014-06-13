//Write a program to convert binary numbers to their decimal representation.

using System;
using System.Collections.Generic;

class binaryToDecimal
{
    static int toDecimal(string binaryNum)
    {
        int decimalNumber = 0;
        string binary = "";
        for (int i =  binaryNum.Length-1; i >=0; i--)//reverse a binary number
		{
            binary += binaryNum[i];
		}

        for (int i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '0')
            {
                continue;
            }   
            decimalNumber += (int)Math.Pow(2, i);
            
        }
        return decimalNumber;
    }
    static void Main()
    {
        Console.Write("Enter a binary number:"); // entera binary number
        string binary = Console.ReadLine();
        
        Console.WriteLine(toDecimal(binary));
    }
}

