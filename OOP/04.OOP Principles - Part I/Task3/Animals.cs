using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Animals:ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public Animals(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public abstract void SaySound();
        
        public static decimal AvarageAge(Animals[] animals)
        {
            decimal age = 0m;
            foreach (var catsAge in animals)
            {
                age += catsAge.Age;
            }
            age = age / animals.Count();
            return age;
        }
    }
}
