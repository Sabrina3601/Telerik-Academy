using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

// 16. Write a program that reads two dates in the format: day.month.year and calculates the 
//     number of days between them. Example:
//     Enter the first date: 27.02.2006
//     Enter the second date: 3.03.2004
//     Distance: 4 days

namespace TwoDatesDaysBetweenThem
{
    class TwoDatesDaysBetweenThem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a start date in the following format: dd.MM.yyyy.");
            string start = Console.ReadLine();
            Console.WriteLine("Please insert an end date in the following format: dd.MM.yyyy.");
            string end = Console.ReadLine();
            
            //string start = "18.06.2013";
            //string end = "03.01.2014";

            DateTime startDate = DateTime.ParseExact(start, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(end, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            double result = (endDate - startDate).TotalDays;
            Console.WriteLine(result);

            //Console.WriteLine((endDate - startDate).TotalDays);

        }
    }
}
