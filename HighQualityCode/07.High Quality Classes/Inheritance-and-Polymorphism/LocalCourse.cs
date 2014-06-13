using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse :Course
    {
        
        public string lab { get; set; }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.lab = lab;
        }

        public LocalCourse(string name)
            : this(name, null, null, null)
        {
        }

        public LocalCourse(string name, string teacherName)
            : this(name, teacherName, null, null)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students)
            : this(name, teacherName, students, null)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { ");
            result.Append(base.ToString());

            if (this.lab != null)
            {
                result.AppendFormat("; Lab = {0}", this.lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
