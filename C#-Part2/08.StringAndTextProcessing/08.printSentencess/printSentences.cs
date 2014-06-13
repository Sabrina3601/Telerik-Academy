//Write a program that extracts from a given text all sentences containing given word.
using System;
using System.Text;


public class ExtractSentences
{
    public static void Main(string[] args)
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        Console.WriteLine("Enter a search word");
        string key = " " + Console.ReadLine() + " ";
        string[] newText = text.Split('.');
        StringBuilder print = new StringBuilder();

        for (int i = 0; i < newText.Length; i++)
        {
            if (newText[i].IndexOf(key)!=-1)
            {
                print.Append(newText[i] + ".");
            }
        }
        Console.WriteLine(print);
    }
}