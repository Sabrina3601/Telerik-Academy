using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OOP_Principles___Part_I
{
    public class School
    {
        public List<Class> Classes { get; set; }

        public School(List<Class> classes)
        {
            this.Classes = classes;
        }

    }
}
