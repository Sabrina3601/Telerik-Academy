//Write a program that deletes from a text file all words that start with the prefix "test".
//Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text.RegularExpressions;
class deletePrefix
{
    static void Main()
    {
        StreamReader input = new StreamReader("../../input.txt");
        StreamWriter output = new StreamWriter("../../output.txt");
        using (input)
        {
            using (output)
            {
                string line;
                while((line = input.ReadLine()) != null)
                {
                    output.WriteLine(Regex.Replace(line, @"\btest\w*\b", String.Empty));
                }
            }
        }
    }
}

