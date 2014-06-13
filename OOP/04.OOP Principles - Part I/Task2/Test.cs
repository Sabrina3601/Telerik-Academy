using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Define abstract class Human with first name and last name. 
//Define new class Student which is derived from Human and has new field – grade. 
//Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
//that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy. 
//Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
//Initialize a list of 10 workers and sort them by money per hour in descending order.
//Merge the lists and sort them by first name and last name.

namespace Task2
{
    class Test
    {

        static void InitializeStudents()
        {
            ListOfStudents = new List<Students>();
            //add 10 students
            ListOfStudents.Add(new Students("Ivan", "Ivanov", 9));
            ListOfStudents.Add(new Students("Ivan", "Zankov", 1));
            ListOfStudents.Add(new Students("Svetoslav", "Iliev", 2));
            ListOfStudents.Add(new Students("Pavel", "Donchev", 5));
            ListOfStudents.Add(new Students("Krum", "Gerorgiev", 6));
            ListOfStudents.Add(new Students("Zahari", "Baharov", 7));
            ListOfStudents.Add(new Students("Geno", "Spasov", 8));
            ListOfStudents.Add(new Students("Borislav", "Bliznashki", 9));
            ListOfStudents.Add(new Students("Konstantin", "Hadjiev", 9));
            ListOfStudents.Add(new Students("Viktor", "Pavlov", 9));
        }

        static void InitializeWorkers()
        {
            //add 10 workers
            ListOfWorkers = new List<Worker>();
            ListOfWorkers.Add(new Worker("Ivan", "Ivanov", 500, 5));
            ListOfWorkers.Add(new Worker("Ivan", "Zankov", 300, 8));
            ListOfWorkers.Add(new Worker("Svetoslav", "Iliev", 100, 2));
            ListOfWorkers.Add(new Worker("Pavel", "Donchev", 100, 5));
            ListOfWorkers.Add(new Worker("Krum", "Gerorgiev", 200, 6));
            ListOfWorkers.Add(new Worker("Zahari", "Baharov", 500, 7));
            ListOfWorkers.Add(new Worker("Geno", "Spasov", 180, 12));
            ListOfWorkers.Add(new Worker("Borislav", "Bliznashki", 1000, 9));
            ListOfWorkers.Add(new Worker("Konstantin", "Hadjiev", 2000, 9));
            ListOfWorkers.Add(new Worker("Viktor", "Pavlov", 3000, 7));
        }

        static List<Worker> ListOfWorkers;
        static List<Students> ListOfStudents;
        static void Main(string[] args)
        {

            Console.WriteLine("Students");
            InitializeStudents();
            var sortStudents =
                from students in ListOfStudents
                orderby students.Grade
                select students;

            foreach (var students in sortStudents)
            {
                Console.WriteLine(students.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Workers");
            InitializeWorkers();

            //order workers
            var sortWorkers =
                from workers in ListOfWorkers
                orderby workers.MoneyPerHour()
                select workers;

            //print workers
            foreach (var workers in sortWorkers)
            {
                Console.WriteLine(workers);
            }

        }
    }
}
