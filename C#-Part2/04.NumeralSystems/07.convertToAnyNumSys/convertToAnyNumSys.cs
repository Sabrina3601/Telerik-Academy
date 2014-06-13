//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Collections.Generic;
class convertToAnyNumSys
{
    static int ConvertToDec(string number, int baseFrom)
    {
        int decimalNumber = 0;
        string binary = "";
        for (int i = number.Length - 1; i >= 0; i--)//reverse a binary number
        {
            binary += number[i];
        }
        if (baseFrom>10)
        {
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '0')
                {
                    continue;
                }
                else if (binary[i] == 'A') decimalNumber += 10 * (int)Math.Pow(baseFrom, i); // change a hex value to their decimal representation 
                else if (binary[i] == 'B') decimalNumber += 11 * (int)Math.Pow(baseFrom, i);//and use math.pow
                else if (binary[i] == 'C') decimalNumber += 12 * (int)Math.Pow(baseFrom, i);
                else if (binary[i] == 'D') decimalNumber += 13 * (int)Math.Pow(baseFrom, i);
                else if (binary[i] == 'E') decimalNumber += 14 * (int)Math.Pow(baseFrom, i);
                else if (binary[i] == 'F') decimalNumber += 15 * (int)Math.Pow(baseFrom, i);
                else decimalNumber += int.Parse(binary[i].ToString()) * (int)Math.Pow(baseFrom, i);

            }
        }
        else
        {
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '0')
                {
                    continue;
                }
                decimalNumber += (int)Math.Pow(baseFrom, i);

            }
        }

       

        return decimalNumber;
    }

    static void ConvertFromDec(int number, int baseTo)
    {
        List<int> result = new List<int>();
        if (baseTo>10)
        {
            while (number > 0)
            {
                result.Add(number % baseTo);
                number = number / baseTo;
            }

            result.Reverse();

            foreach (var item in result)
            {
                switch (item)
                {
                    case 10: Console.Write("A");
                        break;
                    case 11: Console.Write("B");
                        break;
                    case 12: Console.Write("C");
                        break;
                    case 13: Console.Write("D");
                        break;
                    case 14: Console.Write("E");
                        break;
                    case 15: Console.Write("F");
                        break;
                    default: Console.Write(item);
                        break;
                }
            }
            Console.WriteLine();
        }
        else
        {
            while (number > 0)
            {
                result.Add(number % baseTo);
                number = number / baseTo;
            }
            result.Reverse();
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.Write("Please enter a number: ");
        string number = (Console.ReadLine()).ToUpper();
        Console.Write("Please enter the numeral system FROM: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Please enter the numeral system TO: ");
        int d = int.Parse(Console.ReadLine());

        if (s < 2 || d < 2 || s > 16 || d > 16)
        {
            Console.WriteLine("The numeral systems must be in the range [2 .. 16]");
        }
        else
        {
            ConvertFromDec(ConvertToDec(number, s), d);
        }
    }
}

