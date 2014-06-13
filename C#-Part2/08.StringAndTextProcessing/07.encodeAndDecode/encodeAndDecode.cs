//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters. 
//The encoding/decoding is done by performing XOR (exclusive or)
//operation over the first letter of the string with the first of the key,
//the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;
class encodeAndDecode
{
    static void Main()
    {
        Console.WriteLine("Enter a text:");
        string text = Console.ReadLine();
        Console.WriteLine("Enter a chipher");
        string chipher = Console.ReadLine();

        StringBuilder newText = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            newText.Append((char)(text[i] ^ chipher[i % chipher.Length]));

        }
        Console.WriteLine(newText.ToString());
    }
}

