//Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;

class whichDay
{
    static void Main()
    {
        DateTime date = DateTime.Now;
        var day = date.DayOfWeek;
        Console.WriteLine("Today is: {0}",day);
    }
}

