using System;

class ASCII
{
    static void Main()
    {
        for (int i = 0; i < 255; i++)
        {
            char symbol = (char)i;
            Console.WriteLine("{0} = {1}", i+1, symbol);
        }
    }
}
