//Write a program that concatenates two text files into another text file
using System;
using System.IO;
using System.Text;

class Program
{
    static void WriteToFile(StreamWriter output, string file)
    {
        StreamReader input = new StreamReader(file);
        using (input)
        {
            string line;
            while ((line = input.ReadLine()) != null)
            {
                output.WriteLine(line);
            }
        }
    }

    static void Main()
    {
        string[] files = { "../../input.txt", "../../input2.txt" };
        StreamWriter output = new StreamWriter("../../output.txt");
        using (output)
        {
            foreach (string file in files)
            {
                WriteToFile(output, file);
            }
        }      
    }
}



