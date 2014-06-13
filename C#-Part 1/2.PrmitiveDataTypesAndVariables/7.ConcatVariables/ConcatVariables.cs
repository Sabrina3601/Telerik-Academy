using System;

class ConcatVariables
{
    static void Main()
    {
        string hellow = "Hellow";
        string world = "World";
        object concat = hellow + " " + world;
        string concatValue = (string)concat;
        Console.WriteLine(concatValue);
    }
}

