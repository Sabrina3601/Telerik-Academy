using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 21. Write a program that reads a string from the console and prints all different letters in the string 
//     along with information how many times each letter is found.

namespace DifferentLetterInString
{
    class DifferentLetterInString
    {
        static void Main(string[] args)
        {

            string inputString = Console.ReadLine();
            int[] countersArray = new int['z' - 'a' + 1]; // or int[] countersArray = new int[26];

            foreach (char symbol in inputString.ToLower())
            {
                if ('a' <= symbol && symbol <= 'z')
                {
                    countersArray[symbol - 'a']++;
                }
            } 

            for (int i = 0; i < countersArray.Length; i++)
            {
                if (countersArray[i] != 0)
                {
                    Console.WriteLine("The letter {0} is found {1} time(s) in the text above.", (char)(i + 'a'), countersArray[i]);
                }
                    
            }
        }
    }
}
