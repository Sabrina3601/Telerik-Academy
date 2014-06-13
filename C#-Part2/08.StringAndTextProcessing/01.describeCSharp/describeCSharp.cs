//Describe the strings in C#. What is typical for the string data type? 
//Describe the most important methods of the String class.
using System;

class describeCSharp
{
    static void Main()
    {
        Console.WriteLine("Strings are sequences of characters.\n"  + 
        "String objects contain an immutable (read-only) sequence of characters.\nMost important method are:\n" +
        "Compare() - compare to char elemets\n" +
        "Substring() - get element by given start index and lenght of element \n" + 
        "Split() - split a given separator\n"+
        "IndexOf() - get a index of element");
    }
}

