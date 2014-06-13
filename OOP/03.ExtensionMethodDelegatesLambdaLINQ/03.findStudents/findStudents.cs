using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a method that from a given array of students finds all students
//whose first name is before its last name alphabetically. Use LINQ query operators.

namespace _03.findStudents
{
    class findStudents
    {
        static void Main()
        {
            var students = new[]
            {
                new {FirstName = "Ivan", LastName = "Ivanov"},
                new {FirstName = "Georgi",  LastName = "Simeonov"},
                new {FirstName = "Ivan",  LastName = "Todorov"},
                new {FirstName = "Petyr",  LastName = "Chipev"},
            };

            var selectStudent =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student.FirstName + " " + student.LastName;


            foreach (var item in selectStudent)
	        {
		        Console.WriteLine(item);
	        }
        }      
    }
}
