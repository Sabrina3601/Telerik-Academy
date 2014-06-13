using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StudentProject
{
    class Student
    {
        private Group group;
        public string FirsName {get; set;}
        public string LastName { get; set; }
        public string FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int Groups { get; set; }
        public Group Group { get; set; }

        public Student(string firstName, string lastName, string fN, string tel, 
                        string email, List<int> marks, int groups, Group group)
        {
            this.FirsName = firstName;
            this.LastName = lastName;
            this.FN = fN;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.Groups = groups;
            this.group = group;
        }
        public string GetMarks()
        {
            return string.Join(", ", this.Marks);
        }


    }
}
