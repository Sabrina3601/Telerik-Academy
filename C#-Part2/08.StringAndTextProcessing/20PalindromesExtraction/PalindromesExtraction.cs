using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

namespace PalindromesExtraction
{
    class PalindromesExtraction
    {
        static void Main(string[] args)
        {

            string inputString = Console.ReadLine();

            string[] inputStrWordsArray = inputString.Split(new char[] { ' ', '/', '.', ',', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            int n = inputStrWordsArray.Length;

            //for (int i = 0; i < n; i++) // debugging
            //{
            //    Console.Write(inputStrWordsArray[i] + "  ");
            //}
            //Console.WriteLine();

            List<string> palindromesList = new List<string>();

            for (int i = 0; i < n/2 + 1; i++) // checking up to the middle inclusive
            {
                if (inputStrWordsArray[i] == inputStrWordsArray[n - 1 - i])
                {
                    palindromesList.Add(inputStrWordsArray[i]);
                }
            }

            Console.WriteLine("Here are the pallindromes found:");
            for (int i = 0; i < palindromesList.Count; i++)
            {
                Console.WriteLine(palindromesList[i]);
            }

        }
    }
}
