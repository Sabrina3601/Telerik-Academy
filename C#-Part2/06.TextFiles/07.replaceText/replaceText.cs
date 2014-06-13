//Write a program that replaces all occurrences of the substring "start"
//with the substring "finish" in a text file. 
//Ensure it will work with large files (e.g. 100 MB).
using System;
using System.IO;
class replaceText
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
               while ((line=input.ReadLine()) != null)
	           {
                    output.WriteLine(line.Replace("start", "finish")); // use .Replace
                    //output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish")); // Exercise 8
               }
            }
        }
    }
}

