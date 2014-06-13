using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OOP_Principles___Part_I
{
    public class Class : Comment
    {
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students {get;set;}
        public string ClassId { get; set; }

        public Class(List<Teacher> teachers, List<Student> students, string classId)
        {
            this.Teachers = teachers;
            this.Students = students;
            this.ClassId = classId;
        }

        //add teacher
        public void AddTeacher(Teacher teaher)
        {
            bool isInClass = Teachers.Contains(teaher);
            if (!isInClass)
            {
                Teachers.Add(teaher);
            }
            else
            {
                Console.WriteLine("This teacher already teaches in this class");
            }
        }
        //add Student
        public void AddStudent(Student student)
        {
            bool isInClass = Students.Count(x=> x.ClassNum == student.ClassNum) == 0;
            if (!isInClass)
            {
                Students.Add(student);
            }
            else
            {
                Console.WriteLine("This student already teaches in this class");
            }
        }

        //remove Student
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        
        //remove Teacher
        public void RemoveStudent(Teacher teacher)
        {
            Teachers.Remove(teacher);
        }
    }
}
