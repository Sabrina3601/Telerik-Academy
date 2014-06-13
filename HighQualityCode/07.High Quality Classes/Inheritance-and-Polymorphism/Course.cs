using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    class Course
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }

        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(GetStudentsAsString());
           
            result.Append(" }");
            return result.ToString();
        }    

    }
}
