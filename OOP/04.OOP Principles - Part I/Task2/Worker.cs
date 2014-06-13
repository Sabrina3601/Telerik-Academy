using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Worker : Human
    {
        public int WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string firstName, string secondName, int weekSalary, int workHoursPerDay)
            :base(firstName,secondName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            int worksHoursPerWeek = (5 * WorkHoursPerDay);
            decimal moneyPerHour = WeekSalary / worksHoursPerWeek;
            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}BGN per hour", FirstName, LastName, MoneyPerHour());
        }
    }
}
