using System;

class modifiesValue
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a bit 0 or 1");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a position");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Your number in bit");

        if (v == 0)
        {
            int mask = ~(1 << p); //turn bits
            int result = n & mask;// put 0 on position p
            Console.WriteLine(result);
        }
        else
        {
            int secoundMask = 1 << p;
            int secoundResult = n | secoundMask; //put 1 on position p

            Console.WriteLine(secoundResult);
        }
    }
}

