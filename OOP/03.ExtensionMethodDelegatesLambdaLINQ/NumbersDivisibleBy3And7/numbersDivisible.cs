using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
//Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

namespace NumbersDivisibleBy3And7
{
    class numbersDivisible
    {
        static void Main()
        {
            int[] myArray = { 10, 20, 21, 42, 3, 5 };

            //lambda
            var result = myArray.Where(x => x % 7 == 0 && x % 3 == 0);
            foreach (var item in result)
            {
                Console.WriteLine("Numbers that are divisible by 7 and 3 are: {0}", item);
            }

            //LINQ
            var otherResult =
                from num in myArray
                where num % 3 == 0 && num % 7 == 0
                select num;

            Console.WriteLine("LINQ RESULT");
            foreach (var item in otherResult)
            {
                Console.WriteLine("Numbers that are divisible by 7 and 3 are: {0}", item);
            }
        }
    }
}
