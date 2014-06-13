using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

// 24. Write a program that reads a list of wordsArray, separated by spaces and prints the list in an alphabetical order.

namespace WordsStringToSortedList
{
    class WordsStringToSortedList
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please insert a sentence.");
            string input = Console.ReadLine();

            string[] inputWordsArray = input.Split(' ');

            Array.Sort(inputWordsArray);

            for (int i = 0; i < inputWordsArray.Length; i++)
            {
                Console.WriteLine(inputWordsArray[i]);
            }

            // Alternative solution:

            //string inputString = "Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.";

            //var wordsArray = new List<string>();

            //foreach (Match word in Regex.Matches(inputString, @"\w+"))
            //{
            //    wordsArray.Add(word.Value);
            //}
 
            //wordsArray.Sort();

            //foreach (string word in wordsArray)
            //{
            //    Console.WriteLine(word);
            //}

        }
    }
}
