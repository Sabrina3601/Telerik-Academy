using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

namespace _04.findMoreStudents
{
    class findStudents
    {
        static void Main()
        {
            var students = new[]
            {
                new {FirstName = "Ivan", LastName = "Ivanov" , Age = 31},
                new {FirstName = "Georgi",  LastName = "Simeonov", Age = 19},
                new {FirstName = "Ivan",  LastName = "Todorov", Age = 22},
                new {FirstName = "Petyr",  LastName = "Chipev", Age = 55},
            };

            var sortetStudent =
                from student in students
                where (student.Age >= 18 && student.Age <= 22)
                select student.FirstName + " " + student.LastName + " - age: " + student.Age;

            foreach (var item in sortetStudent)
            {
                Console.WriteLine(item);
            }

        }
    }
}
