using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

// 17. Write a program that reads a dateAndHour and time given in the format: day.month.year 
//     hour:minute:second and prints the dateAndHour and time after 6 hours and 30 minutes (in the same 
//     format) along with the day of week in Bulgarian.

namespace DateAndTimePrint
{
    class DateAndTimePrint
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a date and an hour in the follwing format: dd.MM.yyyy HH:mm:ss.");
            string inputString = Console.ReadLine();
            
            //string inputString = "08.06.2013 21:00:00";

            DateTime dateAndHour = DateTime.ParseExact(inputString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            dateAndHour = dateAndHour.AddHours(6.5);

            Console.WriteLine("{0} {1}", dateAndHour.ToString("dddd", new CultureInfo("bg-BG")), dateAndHour);

        }
    }
}
