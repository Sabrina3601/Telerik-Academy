using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Using the extension methods OrderBy() and ThenBy() with lambda expressions
//sort the students by first name and last name in descending order. Rewrite the same with LINQ.

namespace _05.FindStudentLambdaExpression
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class findStudents
    {
        static void Main(string[] args)
        {
            List<Students> stutents = new List<Students>()
            {
                new Students {FirstName = "Ivan", LastName = "Ivanov"},
                new Students {FirstName = "Georgi",  LastName = "Simeonov"},
                new Students {FirstName = "Ivan",  LastName = "Todorov"},
                new Students {FirstName = "Petyr",  LastName = "Chipev"},
            };
            //lambda
            var SortetStudents = stutents.OrderByDescending(x=>x.FirstName).ThenByDescending(x=>x.LastName);
            foreach (var item in SortetStudents)
	        {
		        Console.WriteLine("{0} {1}", item.FirstName , item.LastName);
	        }
            Console.WriteLine();

            // Rewrite with LINQ
            var selectStudent = 
                from student in stutents
                orderby student.FirstName descending, 
                student.LastName descending
                select student;

            Console.WriteLine("Rewrite with LINQ");
            foreach (var item in selectStudent)
	        {
                Console.WriteLine("{0} {1}" , item.FirstName, item.LastName);
	        }
        }
    }
}
