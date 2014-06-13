//Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
//0  "Zero"
//273  "Two hundred seventy three"
//400  "Four hundred"
//501  "Five hundred and one"
//711  "Seven hundred and eleven"

using System;

class numbersToEnglishPronunciation
{
    static void Main()
    {
        string[] dg = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] tn = {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tw = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};

        Console.WriteLine("Enter a number between [0-999]");
        string number = Console.ReadLine();
        int numberLength = number.Length;
        if (numberLength == 1)
        {
            int printFirst = int.Parse(number.Substring(0, numberLength));
            Console.WriteLine(dg[printFirst]);
        }
        if (numberLength == 2)
        {
            int printFirst = int.Parse(number.Substring(0,1));
            int printSecond = int.Parse(number.Substring(1));
            if (printFirst == 1)
            {
                Console.WriteLine(tn[printSecond]);
            }
            else
            {
                Console.WriteLine(tw[printFirst] + " " +dg[printSecond]);
            }
        }
        if (numberLength == 3)
        {
            int printFirst = (int.Parse(number) / 100);
            int printSecond = (int.Parse(number) / 10) % 10;
            int printThird = (int.Parse(number) % 10);
           
            if (printSecond == 0)
            {
                Console.WriteLine(dg[printFirst] + " hunderd");
            }
            if (printSecond == 1)
            {
                Console.WriteLine(dg[printFirst] + " hunderd" + " and " + tn[printThird]);
            }
            if (printThird == 0 && printSecond != 1)
            {
                Console.WriteLine(dg[printFirst] + " hunderd" + " and " + tw[printSecond]);
            }
            if (printSecond != 0 && printThird != 0)
            {
                Console.WriteLine(dg[printFirst] + " hunderd" + " " + tw[printSecond] + " " + dg[printThird]);
            }      
        }
    }
}

