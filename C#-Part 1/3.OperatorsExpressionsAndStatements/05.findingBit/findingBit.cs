using System;

class findingBit
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine());
        int mask = 1<<3; // get third bit
        bool bitmatches = (number & mask) == mask;
        Console.WriteLine("third bit is  " + bitmatches);
    }
}

