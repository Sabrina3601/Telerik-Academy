using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//We are given a school. In the school there are classes of students.
//Each class has a set of teachers. Each teacher teaches a set of disciplines.
//Students have name and uniqSue class number. Classes have unique text identifier. 
//Teachers have name. Disciplines have name, number of lectures and number of exercises. 
//Both teachers and students are people. Students, classes,
//teachers and disciplines could have optional comments (free text block).
//Your task is to identify the classes (in terms of  OOP) and their attributes and operations,
//encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.

namespace _04.OOP_Principles___Part_I
{
    class Test
    {
        static void Main()
        {
            Student ivanStudent = new Student("Ivan", "5");
            ivanStudent.AddComment("Az sam Ivan");

            Student peshoStudent = new Student("Pesho", "10");
            peshoStudent.AddComment("Az sam Pesho");

            Student asenStudent = new Student("Asen", "11");
            asenStudent.AddComment("Az sam Asen");

            Discipline math = new Discipline("Math", 10,10);
            Discipline history = new Discipline("History", 5, 4);

            Teacher teacher = new Teacher("Rumqna", new List<Discipline>() { math, history });
            teacher.AddComment("Ivan and Pesho are great students");
            teacher.AddComment("I am your teacher Rumqna");

            //test comments
            teacher.ShowComment();
            Console.WriteLine();

            //test remove comment
            teacher.RemoveComment("I am your teacher Rumqna");
            teacher.ShowComment();

            //test clear all comments
            teacher.ClearAllComments();
            teacher.ShowComment();

            Class newClass = new Class(new List<Teacher>() { teacher }, new List<Student>(){ivanStudent,
                asenStudent,peshoStudent}, "432");

            School newSchool = new School(new List<Class>() { newClass });

            
        }
    }
}
