using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Tomcat:Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, "Male")
        {      
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old {2} tomcat", Name, Age, Sex);
        }

        public override void SaySound()
        {
            Console.WriteLine("Tomcat sound");
        }
    }
}
