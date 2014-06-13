using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

// 22. Write a program that reads a string from the console and lists all different words in the string 
//     along with information how many times each word is found.

namespace DifferentWordsInString1
{
    class DifferentWordsInString1
    {
        static void Main(string[] args)
        {
            string inputString = "Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.";

            var dictionaryTable = new Dictionary<string, int>();

            foreach (Match word in Regex.Matches(inputString, @"\w+"))
            {
                dictionaryTable[word.Value] = dictionaryTable.ContainsKey(word.Value) ? dictionaryTable[word.Value] + 1 : 1;
            }

            foreach (var pair in dictionaryTable)
            {
                Console.WriteLine("The word \"{0}\" is found {1} time(s) in the text above.", pair.Key, pair.Value);         
            }

        }
    }
}
