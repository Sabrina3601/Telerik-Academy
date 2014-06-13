using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

// 15. Write a program that replaces in a HTML document given as string all the tags <a 
//     href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
//     <p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.
//     Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>

//     <p>Please visit [URL=http://academy.telerik.
//     com]our site[/URL] to choose a training course.
//     Also visit [URL=www.devbg.org]our forum[/URL] to
//     discuss the courses.</p>

namespace HTMLTagsReplacement
{
    class HTMLTagsReplacement
    {
        static void Main(string[] args)
        {
            string inputText = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

            string replacedOutputText = inputText.Replace(@"<a href=""", "[URL=");
            replacedOutputText = replacedOutputText.Replace(@"</a>", "[/URL]");
            replacedOutputText = replacedOutputText.Replace(@""">", "]");

            Console.WriteLine(replacedOutputText);

            // Alternative Solution:

            //string html = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
            //Console.WriteLine(Regex.Replace(html, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]"));

        }
    }
}
