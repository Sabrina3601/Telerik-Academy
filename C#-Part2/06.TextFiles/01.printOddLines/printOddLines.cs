//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class printOddLines
{
    static void Main()
    {
        StreamReader input = new StreamReader("../../printOddLines.cs");
        using (input)
        {   
            int n = 0;
            for (string line; (line = input.ReadLine())!= null; n++)
            {
                if (n%2 == 1)
                {
                    Console.WriteLine("Line {0}: {1} ", n, line);
                }
            }
        }
    }
}

