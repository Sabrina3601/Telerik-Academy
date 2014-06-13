using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

// 19. Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display
//     them in the standard date format for Canada.

namespace DatesExtractionFromText
{
    class DatesExtractionFromText
    {
        static void Main(string[] args)
        {

            string inputString = "any text in here ...   04.08.2013, 06.06.2010, invalid date - 33.09.2008";
            DateTime date;
            string outputDate = string.Empty;

            foreach (Match item in Regex.Matches(inputString, @"\b\d{2}.\d{2}.\d{4}\b"))
            {
                if (DateTime.TryParseExact(item.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    outputDate = date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern);
                    Console.WriteLine(outputDate);
                }
            }
        }
    }
}
