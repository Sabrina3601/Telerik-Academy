using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OOP_Principles___Part_I
{
    public class Teacher : People
    {
        public List<Discipline> Discpilines { get; set; }

        public Teacher(string name, List<Discipline> disciplines):base(name)
        {
            this.Discpilines = disciplines;
        }

        //add discipline
        public void AddDiscipline(Discipline discipline)
        {
            bool isItTeached = Discpilines.Count(x => x.Name == discipline.Name) == 0;
            if (!isItTeached)
            {
                Discpilines.Add(discipline);
            }          
        }

        //remove discpiline
        public void RemoveDiscipline(Discipline discipline)
        {
            Discpilines.Remove(discipline);
        }
    }
}
