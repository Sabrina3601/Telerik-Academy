//You are given a text. 
//Write a program that changes the text in all regions surrounded by the tags
//<upcase> and </upcase> to uppercase. The tags cannot be nested. 
using System;

class changeTextByTags
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        int openTag = 0;
        for (int i = 0; i < text.Length-8; i++)
        {
            if (text.Substring(i, 8) == "<upcase>")
            {
                openTag = i + 8;
            }
            if (text.Substring(i, 9) == "</upcase>")
            {
                int length = i - openTag;
                string upperStr = text.Substring(openTag, length).ToUpper();
                text = text.Remove(openTag, length);
                text = text.Insert(openTag, upperStr);
                text = text.Remove(openTag - 8, 8);
                text = text.Remove(i - 8, 9);
            }
        }
        Console.WriteLine(text);
    }
}

