using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Cat:Animals
    {
        public Cat(string name, int age, string sex):base(name,age,sex)
        {      
        }

        public override void SaySound()
        {
            Console.WriteLine("Mquu");
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old {2} cat", Name, Age, Sex);
        }
    }
}
