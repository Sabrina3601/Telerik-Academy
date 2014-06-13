using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CommonTypeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Student ivan = new Student("Ivan", "Ivanov", "Ivanov", "0000", "Sofia", "+359*********",
               "ivan@abv.com",2, Speciality.English,University.NBU,Faculties.Informatics);
            Console.WriteLine(ivan);
            Student asen = new Student("Asen", "Draganov", "Petrov", "0000", "Plovdiv", "+359*********",
                "asen@abv.com", 2, Speciality.Mathematic, University.SoftwareUniversity, Faculties.Marketing);
            Console.WriteLine();
            Console.WriteLine(asen);
            Console.WriteLine();
            Console.WriteLine("Ivan == Asen -> {0}", ivan == asen);
            Console.WriteLine("Ivancho equals ivan -> {0}", asen.Equals(ivan));
 
            Student ivan2 = ivan.Clone() as Student;
            ivan.LastName = "Ivanovski";

            Console.WriteLine("ivan == ivan2 -> {0}", ivan == ivan2);

            Console.WriteLine("Comparing ivan2 with ivan -> {0}", ivan2.CompareTo(ivan));
        }
    }
}
