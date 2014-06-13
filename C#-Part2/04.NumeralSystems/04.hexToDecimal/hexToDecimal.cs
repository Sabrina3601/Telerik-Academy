//Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class decimalToHexadecimal
{
    static int toDecimal(string hexNum)
    {
        int decimalResult = 0;
        string decimalNum = "";
        for (int i = hexNum.Length - 1; i >= 0; i--)//reverse a decimal number
        {
            decimalNum += hexNum[i];
        }

        for (int i = 0; i < decimalNum.Length; i++)
        {
            if (decimalNum[i] == '0')
            {
                continue;
            }
            else if (decimalNum[i] == 'A') decimalResult += 10 * (int)Math.Pow(16, i); // change a hex value to their decimal representation 
            else if (decimalNum[i] == 'B') decimalResult += 11 * (int)Math.Pow(16, i);//and use math.pow
            else if (decimalNum[i] == 'C') decimalResult += 12 * (int)Math.Pow(16, i);
            else if (decimalNum[i] == 'D') decimalResult += 13 * (int)Math.Pow(16, i);
            else if (decimalNum[i] == 'E') decimalResult += 14 * (int)Math.Pow(16, i);
            else if (decimalNum[i] == 'F') decimalResult += 15 * (int)Math.Pow(16, i);
            else decimalResult += int.Parse(decimalNum[i].ToString()) * (int)Math.Pow(16, i);

        }
        return decimalResult;
    }
    static void Main()
    {
        Console.Write("Enter a hex number:"); // enter a hexn numbre
        string hexNum = Console.ReadLine();

        Console.WriteLine(toDecimal(hexNum));
    }

}

