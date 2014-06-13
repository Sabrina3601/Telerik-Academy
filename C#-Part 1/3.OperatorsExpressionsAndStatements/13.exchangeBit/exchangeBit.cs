using System;

class exchangeBit
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        uint n = uint.Parse(Console.ReadLine());
        string checkNumber = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine(checkNumber);
        uint maskFirst = 7 << 3 & n; //creat mask
        uint maskSecond = 7 << 24 & n;

        uint changeFirst = maskFirst << 21; // move with 21 position left or right / 21 because 24 - 3 = 21
        uint changeSecond = maskSecond >> 21;

        uint unitMask = changeFirst | changeSecond;

        n = (~(7u << 3) & n); //turns bit
        n = (~(7u << 24) & n);

        uint result = unitMask | n; //contact them
        string checkChangeNumber = Convert.ToString(result, 2).PadLeft(32, '0');
        Console.WriteLine(checkChangeNumber);
        Console.WriteLine(result);
    }
}

