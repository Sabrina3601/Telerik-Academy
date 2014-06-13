using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OOP_Principles___Part_I
{
    public class People: Comment
    {
        public string Name { get; set; }

        public People(string name)
        {
            this.Name = name;
        }
    }
}
