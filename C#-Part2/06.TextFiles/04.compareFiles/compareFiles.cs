using System;
using System.IO;

class compareFiles
{
    static void Main()
    {
        int n = 0;
        StreamReader input = new StreamReader("../../input.txt");
        StreamReader secondInput = new StreamReader("../../input2.txt");
        int same = 0;
        using (input)
        {
            using (secondInput)
            {
                for (string line,secondLine; (line = input.ReadLine()) != null && (secondLine = secondInput.ReadLine()) != null; n++)
                {
                    if (line == secondLine)
                    {
                        same++;    
                    }
                }
                
            }
        }
        Console.WriteLine("Same line are: {0}", same);
        Console.WriteLine("Different line are: {0}", n - same);
    }
}

