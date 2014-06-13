//Write a program that deletes from given text file all odd lines. The result should be in the same file
using System;
using System.IO;
using System.Collections.Generic;

class deleteOddFiles
{
    static List<string> ReadEvenLines()
    {
        List<string> lines = new List<string>();

        int n = 1;
        StreamReader input = new StreamReader("../../input.txt");
        using (input)
        {
            for (string line; (line = input.ReadLine()) != null; n++) //first read and save only even lines
            {
                if (n % 2 == 0)
                {
                    lines.Add(line);
                }
            }
        }
        return lines;
    }

    static void WriteLines(List<string> lines)
    {
        StreamWriter output = new StreamWriter("../../input.txt");
        using (output)
        {
            foreach (string line in lines)
            {
                output.WriteLine(line);//print it
            }
        }
    }

    static void Main()
    {
        WriteLines(ReadEvenLines());
    }
}

