//Write a method that returns the last digit of given integer as an English word.
//Examples: 512  "two", 1024  "four", 12309  "nine".

using System;

class lastDigit
{
    static string[] numbers = new string[] {
        "zero", "one", "two", "three", "four", "five",
        "six", "seven", "eight", "nine"
    };
    static string LastDigit(int n) 
    {
        int lastnumber = n % 10;
        return numbers[lastnumber];

    }
    static void Main()
    {
        Console.WriteLine("Give a number");
        int number = int.Parse(Console.ReadLine());
        string result = LastDigit(number);
        Console.WriteLine("Last digit is " + result);
    }
}

