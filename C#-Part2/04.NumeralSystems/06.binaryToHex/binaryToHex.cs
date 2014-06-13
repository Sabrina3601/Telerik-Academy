//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class binaryToHex
{
    static int toDecimal(string binaryNum)
    {
        int decimalNumber = 0;
        string binary = "";
        for (int i = binaryNum.Length - 1; i >= 0; i--)//reverse a binary number
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

    static string ToHex(string binaryNum)
    {
        string hexResult = "";
        for (int i = 0; i < binaryNum.Length; i+=4)
        {
            string hex = "";
            hex += binaryNum.Substring(i, 4);
            int decimalNum = toDecimal(hex); // call a method to find a decimal value

            if (decimalNum == 10) hexResult += "A";
            else if (decimalNum == 11) hexResult += "B";
            else if (decimalNum == 12) hexResult += "C";
            else if (decimalNum == 13) hexResult += "D";
            else if (decimalNum == 14) hexResult += "E";
            else if (decimalNum == 15) hexResult += "F";
            else hexResult += decimalNum.ToString();

        }
        return hexResult;
    }

    static void Main()
    {
        Console.Write("Enter a binary number:"); //enter a binary number
        string binaryNum = Console.ReadLine();

        Console.WriteLine(ToHex(binaryNum));
    }
}

