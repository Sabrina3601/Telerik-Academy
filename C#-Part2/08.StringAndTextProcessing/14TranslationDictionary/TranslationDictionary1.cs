using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 14. A dictionary is stored as a sequence of text lines containing words and their explanations. Write a 
//     program that enters a word and translates it by using the dictionary. Sample dictionary:
//     .NET – platform for applications from Microsoft
//     CLR – managed execution environment for .NET
//     namespace – hierarchical organization of classes

namespace TranslationDictionary1
{
    class TranslationDictionary1
    {

        private static void Main()
        {
            Console.Write("Type the word you would like to search for: ");
            string word = Console.ReadLine();
            Console.WriteLine("Here is the desired word's description:");
            Console.WriteLine("{0} => {1}", word, GetDescription(word));
        }

        private static string GetDescription(string word)
        {
            word = word.Trim();
            var dictionary = new Dictionary<string, string>();
            dictionary.Add(".NET", "platform for applications from Microsoft");
            dictionary.Add("CLR", "managed execution environment for .NET");
            dictionary.Add("namespace", "hierarchical organization of classes");
            dictionary.Add("da-be-da", "sheguvam se");

            foreach (var entry in dictionary)
            {
                if (entry.Key.ToLowerInvariant() == word.ToLowerInvariant())
                {
                    return entry.Value;
                }
            }

            return "Word not found.";
        }

    }
}
