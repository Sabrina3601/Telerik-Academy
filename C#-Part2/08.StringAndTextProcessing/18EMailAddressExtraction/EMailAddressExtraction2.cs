using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

// 18. Write a program for extracting all email addresses from given text. 
//     All substrings that match the format <identifier>@<host>…<domain> should be 
//     recognized as emails.

namespace EMailAddressExtraction2
{
    class EMailAddressExtraction2
    {
        static void Main(string[] args)
        {
            // INCOMPLETE SOLUTION! Please refer to the second solution of the same task - EMailAddressExtraction1

            string inputString = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";

            foreach (var item in Regex.Matches(inputString, @"\w+@\w+\.\w+")) // This algorithm is valid for e-mail addresses of the following format only: "abv@abv.bg"
            {
                Console.WriteLine(item);
            }

            foreach (var item in Regex.Matches(inputString, @"\w+@\w+\.\w+\.\w+")) // This algorithm is valid for e-mail addresses of the following format only: "abv@abv.CO.bg"
            {
                Console.WriteLine(item);
            }

        }
    }
}
