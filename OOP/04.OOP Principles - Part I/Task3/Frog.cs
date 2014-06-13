using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Frog:Animals
    {
        public Frog(string name, int age, string sex):base(name,age,sex)
        {      
        }

        public override void SaySound()
        {
            Console.WriteLine("Kvak");
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old {2} frog", Name, Age, Sex);
        }
    }
}
