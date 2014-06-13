using System;

class findBitPosition
{
    static void Main()
    {
        Console.WriteLine("give a number");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine("which bit do you want to get");
        int p = int.Parse(Console.ReadLine());
        string bitNumber = Convert.ToString(v, 2).PadLeft(32, '0');
        Console.WriteLine("your number in bit " + bitNumber);

        int mask = 1 << p;
        int masket = v & mask; //get bit
        int bit = masket >> p;
        bool check = bit == 1; //now check the value
        Console.WriteLine("it's " + check);
    }
}
