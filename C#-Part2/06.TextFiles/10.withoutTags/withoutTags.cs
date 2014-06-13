using System;
using System.IO;
class withoutTags
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../input.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                int start = -1;
                int end = -1;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '<')
                    {
                        start = i;
                    }
                    else if (line[i] == '>')
                    {
                        end = i;
                    }
                    if (start != -1 && end != -1)
                    {
                        line = line.Replace(line.Substring(start, end - start + 1), string.Empty);

                        start = end = i = -1;
                    }
                }
                if (string.IsNullOrWhiteSpace(line) == false)
                {
                    Console.WriteLine(line.Trim());
                }
                line = reader.ReadLine();
            }
        }
    }
}

