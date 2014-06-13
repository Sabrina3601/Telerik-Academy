//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings.
using System;
using System.Text;
class unicodeConvert
{
    static void Main(string[] args)
    {
        Console.WriteLine("Give a text for convert");
        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            int charNumber = text[i];
            Console.Write(@"\u{0:x4}",charNumber);
        }
        Console.WriteLine();
    }
}

