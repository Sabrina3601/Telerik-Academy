//We are given a string containing a list of forbidden words and a text containing some of these words. 
//Write a program that replaces the forbidden words with asterisks
using System;
using System.Text;

class forbiddenWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        string words = "PHP, CLR, Microsoft";
        string[] splitWord = words.Split(',');
        StringBuilder newText = new StringBuilder(text);
        for (int i = 0; i < splitWord.Length; i++)
        {
            splitWord[i] = splitWord[i].Trim();
            newText.Replace(splitWord[i], new string('*', splitWord[i].Length));
        }
        Console.WriteLine(newText);
    }
}

