using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OOP_Principles___Part_I
{
    public class Discipline : Comment
    {
        public string Name { get; set; }
        public int NumberOfLecture { get; set; }
        public int NUmberOfExcercises { get; set; }

        public Discipline(string name, int lecturesCount, int exercisesCount)
        {
            Name = name;
            NumberOfLecture = lecturesCount;
            NUmberOfExcercises = exercisesCount;
        }

    }
}
