using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    public class Person
    {
        private int? age;
        public string Name { get; set; }

        public int? Age
        {
            get
            {   
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.age = value;
            }          
        }

        public Person(string name, int? age)
        {
            this.Age = age;
            this.Name = name;
        }

        public Person(string name) : this(name,null)
        {
        }

        public override string ToString()
        {
            if (this.Age == null)
            {
                return String.Format("{0} has unspecified age", Name);
            }
            else
            {
                return String.Format("{0} is {1} years old.", Name, Age);
            }          
        }
    }
}
