//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

using System;

class calculateSum
{
    static void Main()
    {
        Console.WriteLine("Give a sequence of numbers spearated by spaces.");
        string numbers = Console.ReadLine();
        string[] arrayOfNum = numbers.Split(' ');
        int sum = 0;
        for (int i = 0; i < arrayOfNum.Length; i++)
        {
            sum += int.Parse(arrayOfNum[i]);
        }
        Console.WriteLine(sum);
    }
}

