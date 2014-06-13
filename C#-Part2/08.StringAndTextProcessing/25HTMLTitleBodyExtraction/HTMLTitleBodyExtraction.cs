using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

// 25. Write a program that extracts from given HTML file its title (if available), and its body text without 
//     the HTML tags. Example:
//     <html>
//     <head><title>News</title></head>
//     <body><p><a href="http://academy.telerik.com">Telerik
//     Academy</a>aims to provide free real-world practical
//     training for young people who want to turn into
//     skillful .NET software engineers.</p></body>
//     </html>

namespace HTMLTitleBodyExtraction
{
    class HTMLTitleBodyExtraction
    {
        static void Main(string[] args)
        {

            StreamReader reader = new StreamReader(@".......\HW8StringsAndTextProcessing\25HTMLTitleBodyExtraction\bin\Debug\preface.html");

            using (reader)
            {
                string line = string.Empty;
                MatchCollection matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");

                while ((line = reader.ReadLine()) != null)
                {
                    matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");

                    foreach (var word in matchProtocolAndSiteName)
                    {
                        Console.WriteLine(word);
                    }
                }

            }

            // Alternative Solution:

            //string inputString = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">TelerikAcademy</a>aims to provide free real-world practicaltraining for young people who want to turn into skillful .NET software engineers.</p></body></html>";

            //foreach (Match text in Regex.Matches(inputString, "(?<=>).*?(?=<)"))
            //{
            //    if (!String.IsNullOrWhiteSpace(text.Value))
            //    {
            //        Console.WriteLine(text);               
            //    }
            //}

        }
    }
}
