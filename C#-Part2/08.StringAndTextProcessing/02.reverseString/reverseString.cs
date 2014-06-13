//Write a program that reads a string, reverses it and prints the result at the console.

using System;

class reverseString
{
    static void Main()
    {
        Console.WriteLine("Give a string");
        string input = Console.ReadLine();
        char[] reverse = input.ToCharArray();
        Array.Reverse(reverse);
        Console.WriteLine(reverse);
    }
}

