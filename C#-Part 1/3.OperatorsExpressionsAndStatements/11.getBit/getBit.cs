using System;

class getBit
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a bit position");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Your number in bit");
        string check = Convert.ToString(i, 2).PadLeft(8, '0');
        Console.WriteLine(check);

        int mask = 1 << b; // create mask
        int masket = mask & i;
        int bit = masket >> b; //now get bit value 
        Console.WriteLine("Your bit is: " + bit);
    }
}

