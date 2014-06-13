using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program to return the string with maximum length from an array of strings. Use LINQ.
namespace _17.maximumLenght
{
    class MaximumLenght
    {
        static void Main()
        {
            Console.Write("Enter string sequence length: ");
            int length = int.Parse(Console.ReadLine());

            string[] stringSequence = new string[length];
            for (int i = 0; i < length; i++)
            {
                stringSequence[i] = Console.ReadLine();
            }

            var stringWithMaximalLength = stringSequence.Aggregate((max, current) => max.Length > current.Length ? max : current);

            Console.WriteLine(stringWithMaximalLength);
        }
    }
}
