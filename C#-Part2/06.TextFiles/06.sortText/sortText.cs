//Write a program that reads a text file containing a list of strings,
//sorts them and saves them to another text file.
using System;
using System.IO;
using System.Collections.Generic;

class sortText
{
    static void Main()
    {
        List<string> doc = new List<string>();
        StreamReader input = new StreamReader("../../input.txt");
        StreamWriter output = new StreamWriter("../../output.txt");
        using (input)
        {
            string line;
            while ((line = input.ReadLine()) != null)
            {
                doc.Add(line);
            }
            doc.Sort();
           
        }
        using (output)
        {
            foreach (string item in doc)
            {
                output.WriteLine(item);
            }
            
        }
    }
}

