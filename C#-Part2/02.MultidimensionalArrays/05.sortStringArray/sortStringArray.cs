//You are given an array of strings. 
//Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;

class sortStringArray
{
    static void Main()
    {
        string[] stringArray = { "heheheheh", "hoho", "haha", "phephephe", "ahahah", "hihihoho", "hi" };
        int[] arrayLenght = new int[stringArray.Length];

        for (int i = 0; i < stringArray.Length; i++)
        {
            arrayLenght[i] = stringArray[i].Length;//get lenght of string array
        }

        Array.Sort(arrayLenght, stringArray); // now sort them
        foreach (var element in stringArray) // and print
        {
            Console.WriteLine(element);
        }

    }
}

