using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Task 9
//Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
//Create a List<Student> with sample students. Select only the students that are from group number 2.
//Use LINQ query. Order the students by FirstName.

namespace _09.StudentProject
{
    class StudentTest
    {
        static List<Student> students = new List<Student>()
        {
            new Student("Ivan", "Ivanov", "55555503", "02876455", "ivan@abv.bg", new List<int> {3, 4, 2, 2}, 2, new Group(15, "Physics")),
            new Student("Petar", "Marinov", "4444404", "02899123", "petar@gmail.com", new List<int> {6, 5, 6, 6}, 2, new Group(13, "Mathematics")),
            new Student("Vnecislav", "Gospodinov", "3333305", "73654789", "venci@abv.bg", new List<int> {6, 5, 6}, 4, new Group(14, "History")),
            new Student("Anna", "Dimitrova", "22222206", "52999999", "anna@gmail.com", new List<int> {6, 6}, 2,new Group(22, "English"))
        };

        private static void Print(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("{0} {1}", student.FirsName, student.LastName);
            }
        }

        //with lamba
        static void StudentsGroup()
        {
            var studetsGroup =
                from student in students
                where student.Groups == 2
                orderby student.FirsName
                select student;
            Print(studetsGroup);
        }

        //Task 10
        //Implement the previous using the same query expressed with extension methods.
        static void StudentsGropByLambda()
        {
            var studentGroup = students.Where(x => x.Groups == 2).OrderBy(x=>x.FirsName);
            Print(studentGroup);
        }

        //Task 11
        //Extract all students that have email in abv.bg. Use string methods and LINQ.
        static void StudentEmail()
        {
            var studentEmail =
                from student in students
                where student.Email.Contains("abv.bg")
                select student;
                Print(studentEmail);
        }

        //Task 12
        //Extract all students with phones in Sofia. Use LINQ
        static void StudentsPhone()
        {
            var studentsPhone =
                from student in students
                where student.Tel.StartsWith("02")
                select student;
            Print(studentsPhone);
        }
        //Task 13
        //Select all students that have at least one mark Excellent (6) 
        //into a new anonymous class that has properties – FullName and Marks. Use LINQ.
        static void StudentsWithExcellentMark()
        {
            var studentsExcellentMark =
                from student in students
                where student.Marks.Contains(6)
                select new {FullName = student.FirsName +" " + student.LastName, Marks = student.GetMarks()};
            
            foreach (var item in studentsExcellentMark)
            {
                Console.WriteLine("{0} -> {1}", item.FullName, item.Marks);
            }
        }
        //Task 14
        //Write down a similar program that extracts the students with exactly  two marks "2". 
        //Use extension methods.
        static void FindStudentsWithTwoMarks()
        {
            var studentsWithExactlyTwoMarks =
               from student in students
               where student.Marks.Count(x => x == 2) == 2
               select new { FullName = student.FirsName + " " + student.LastName, Marks = student.GetMarks() };

            foreach (var item in studentsWithExactlyTwoMarks)
            {
                Console.WriteLine("{0} -> {1}", item.FullName, item.Marks);
            }
        }
        //Task15
        //Extract all Marks of the students that enrolled in 2006. 
        //(The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        static void MarkOfStudents2006()
        {
            var marksOfStudents2006 =
               from student in students
               where student.FN.EndsWith("06")
               select new { FullName = student.FirsName + " " + student.LastName, Marks = student.GetMarks() };

            foreach (var item in marksOfStudents2006)
            {
                Console.WriteLine("{0} -> {1}", item.FullName, item.Marks);
            }
        }
        //Task 16
        //* Create a class Group with properties GroupNumber and DepartmentName. 
        //Introduce a property Group in the Student class. Extract all students from "Mathematics" department. 
        //Use the Join operator.
        static void FindStudentsInMathematicsDepartment()
        {
            Group[] groups = new Group[]
            {
                new Group(15, "Mathematics"),
                new Group(11, "Medicine"),
                new Group(13, "Physics"),
                new Group(22, "Chemistry")
            };

            var result =
                from g in groups
                join s in students on g.DepartmentName equals s.Group.DepartmentName
                where g.DepartmentName == "Mathematics"
                select new { Dep = s.Group.DepartmentName, Name = s.FirsName + " " + s.LastName };

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " -> " + item.Dep);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Students in Group 2 with LINQ");
            StudentsGroup();
            Console.WriteLine("Students in Group 2 with Lambda");
            StudentsGropByLambda();
            Console.WriteLine("Students with email in abv.bg");
            StudentEmail();
            Console.WriteLine("Students phone based in Sofia");
            StudentsPhone();
            Console.WriteLine("Students with Excellent mark");
            StudentsWithExcellentMark();
            Console.WriteLine("Find students with two marks (2)");
            FindStudentsWithTwoMarks();
            Console.WriteLine("Marks of students that enrolled in 2006");
            MarkOfStudents2006();
            //Console.WriteLine("All student from Mathematic department");
            // FindStudentsInMathematicsDepartment();


        }
    }
}
