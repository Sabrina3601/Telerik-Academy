//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//		Create appropriate methods.
//		Provide a simple text-based menu for the user to choose which task to solve.
//		Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;

class sloveTasks
{

    static int Reverse(int number)
    {
        string strNumber = number.ToString();
        string reverseStrNum = "";
        for (int i = strNumber.Length; i > 0; i--)
        {
            reverseStrNum += strNumber[i].ToString();
        }
        int reverseNumber = int.Parse(reverseStrNum);
        return reverseNumber;

    }
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Reverse(number));


    }
}

