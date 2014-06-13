using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Dog:Animals
    {
        public Dog(string name, int age, string sex):base(name,age,sex)
        {      
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old {2} dog", Name, Age, Sex);
        }

        public override void SaySound()
        {
            Console.WriteLine("Bauuu");
        }
    }
}
