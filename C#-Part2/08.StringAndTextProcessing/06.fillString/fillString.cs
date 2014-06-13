//Write a program that reads from the console a string of maximum 20 characters.
//If the length of the string is less than 20, the rest of the characters should be filled with '*'.
//Print the result string into the console.

using System;
using System.Text;

class fillString
{
    static void Main()
    {
        Console.WriteLine("Enter a string of maximum 20 characters:");
        string text = Console.ReadLine();
        string newText = text.PadRight(20 - text.Length, '*');// with padleft
        Console.WriteLine(newText);

       //StringBuilder newText = new StringBuilder();//without padleft
       //for (int i = 0; i < text.Length; i++)
       //{
       //    newText.Append(text[i]);
       //}
       //int charCount = 20 - text.Length;
       //for (int i = 0; i < charCount; i++)
       //{
       //    newText.Append('*');
       //}
        
    }
}

