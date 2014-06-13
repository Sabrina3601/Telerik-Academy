//Modify the solution of the previous problem to replace only whole words (not substrings).
using System;
using System.IO;
using System.Text.RegularExpressions;
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
                while ((line = input.ReadLine()) != null)
                {
                    output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish")); //use Regular Expression
                }
            }
        }
    }
}

