//Write a method that reverses the digits of given decimal number.
//Example: 256  652

using System;

class reverseDigit
{

    static string Reverse(decimal number) 
    {
        
        string strNum = number.ToString();
        string reverseNum = "";
        for (int i = strNum.Length-1; i >= 0; i--)
        {
            reverseNum += strNum[i].ToString();
        }
        return reverseNum;
    }

    static void Main()
    {
        Console.WriteLine("Give a number to reverse");
        decimal number = decimal.Parse(Console.ReadLine());
        Console.WriteLine(  Reverse(number) );;
    }
}

