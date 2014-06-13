using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Kitten:Cat
    {
        public Kitten(string name, int age)
            :base(name,age,"Female")
        {      
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old {2} kitten", Name, Age, Sex);
        }

        public override void SaySound()
        {
            Console.WriteLine("Kitten saund.");
        }
    }
}
