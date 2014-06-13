//Write a program that reverses the words in given sentence.
	//Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;

class reverseSentence
{
    static void Main()
    {
        //string sentence = "C# is not C++, not PHP and not Delphi!";
        string sentence = Console.ReadLine();
        string[] sintenceSplit = sentence.Split(' ');
        string reverse = "";
        for (int i = sintenceSplit.Length-1; i >= 0; i--)
        {
            if (i == 0)
            {
                reverse += sintenceSplit[i].Replace(sentence[sentence.Length - 1], ' ');
            }
            else
            {
                reverse += sintenceSplit[i].Replace(sentence[sentence.Length - 1], ' ') + " ";
            }
            
        }
        Console.WriteLine(reverse + sentence[sentence.Length - 1]);
    }
}

