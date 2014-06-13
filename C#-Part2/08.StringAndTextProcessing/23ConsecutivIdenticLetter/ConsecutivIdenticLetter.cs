using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 23. Write a program that reads a string from the console and replaces all series of 
//     consecutive identical letters with a single one. Example:
//     "aaaaabbbbbcdddeeeedssaa" => abcdedsa".

namespace ConsecutivIdenticLetter
{
    class ConsecutivIdenticLetter
    {
        static void Main(string[] args)
        {

            //StringBuilder input = new StringBuilder("aaaaabbbbbcdddeeeedssaa");

            StringBuilder input = new StringBuilder(Console.ReadLine());

            for (int i = 0, index = 0; i < input.Length - 1; i++, index++)
            {
                char currentLetter = input[i];
                while (index < input.Length - 1 && currentLetter == input[index + 1])
                {
                    input.Remove(index + 1, 1);
                }
            }
            
            string output = input.ToString();
            Console.WriteLine(output);

        }
    }
}
