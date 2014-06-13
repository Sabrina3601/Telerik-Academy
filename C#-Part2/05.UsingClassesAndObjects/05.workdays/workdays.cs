//Write a method that calculates the number of workdays between today and given date,
//passed as parameter. Consider that workdays are all days from Monday to Friday 
//except a fixed list of public holidays specified preliminary as array.
using System;

class workdays
{
    static int CheckWorkingDates(DateTime now, DateTime final, DateTime[] holiday)
    {
        int lengthDays = (final - now).Days;
        //DateTime startDay = DateTime.Today;
        int dayCount = 0;
        bool isHoliday = false;
        for (int i = 0; i <= lengthDays; i++)
		{
	        now =  now.AddDays(i);
            if (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday )
            {
                for (int j = 0; j < holiday.Length; j++)
			    {
			        if (now != holiday[j])
	                {
                        isHoliday = false;
	                }
                    else
	                {
                        isHoliday = true;
	                }
			    }
                if (isHoliday == false)
                {
                    dayCount++;
                }
                
            }
	   
        }
		return dayCount;
    }
    static void Main()
    {
        DateTime[] holidays =
        {
            new DateTime(2014, 1, 1),
            new DateTime(2014, 2, 2),
            new DateTime(2014, 3, 3),
            new DateTime(2014, 4, 4),
            new DateTime(2014, 1, 18)
        };

        DateTime now = DateTime.Today;
        Console.Write("Enter final date <YYYY-MM-DD>: ");
        DateTime final = DateTime.Parse(Console.ReadLine());
        
        Console.WriteLine(CheckWorkingDates(now, final, holidays));
    }
}

