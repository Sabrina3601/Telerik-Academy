//Write a program that finds how many times a substring
//is contained in a given text (perform case insensitive search).
using System;

class substringContain
{
    static void Main()
    {
        Console.WriteLine("Give a target substring:");
        string substring = Console.ReadLine().ToLower();
        string text = "We are living in an yellow submarine. "+
        "We don't have anything else. Inside the submarine is very tight. "+
        "So we are drinking all the day. We will move out of it in 5 days.".ToLower();
        int count = 0;
        for (int i = 0; i < text.Length - (substring.Length-1); i++)
        {
            if (text.Substring(i, substring.Length).ToLower() == substring.ToLower())
	        {
                count++;
	        }          
        }
        Console.WriteLine(count);
    }
}

