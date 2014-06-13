using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task
{
    class People
    {
        enum Gender { ултра_Батка, Яка_Мацка };

        class Person
        {
            public Gender sex { get; set; }
            public string name { get; set; }
            public int age { get; set; }
        }
        public void CreatePerson(int id)
        {
            Person newPerson = new Person();
            newPerson.age = id;
            if (id % 2 == 0)
            {
                newPerson.name = "Батката";
                newPerson.sex = Gender.ултра_Батка;
            }
            else
            {
                newPerson.name = "Мацето";
                newPerson.sex = Gender.Яка_Мацка;
            }
        }
    }

}
