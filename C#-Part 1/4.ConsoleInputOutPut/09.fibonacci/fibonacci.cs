using System;

class fibonacci
{
    static void Main()
    {
        //By definition, the first two numbers in the Fibonacci sequence are 0 and 1, and each subsequent number is the sum of the previous two.
        ulong first = 0;
        ulong second = 1;
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine(first);
            Console.WriteLine( second);
            first = first + second;
            second = second + first;
        }
    }
}

