using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffSiteCourse:Course
    {
        public string Town { get; set; }

        public OffSiteCourse(string name, string teacherName, IList<string> students, string town)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public OffSiteCourse(string name)
            : this(name, null, null, null)
        {
        }

        public OffSiteCourse(string name, string teacherName)
            : this(name, teacherName, null, null)
        {
        }

        public OffSiteCourse(string name, string teacherName, IList<string> students)
            : this(name, teacherName, students, null)
        {
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { ");
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.AppendFormat("; Town = {0}", this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }

    }
}
