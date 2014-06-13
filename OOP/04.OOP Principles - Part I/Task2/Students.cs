using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Students : Human
    {
        public int Grade { get; set; }

        public Students(string firstName, string lastName, int grade)
            : base(firstName,lastName)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2} grade", FirstName, LastName, Grade);
        }
    }
}
