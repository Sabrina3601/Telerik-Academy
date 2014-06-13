using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OOP_Principles___Part_I
{
    public class Student : People
    {
        public string ClassNum { get; set; }

        public Student(string name, string classNum): base(name)
        {
            this.ClassNum = classNum;
        }

    }
}
