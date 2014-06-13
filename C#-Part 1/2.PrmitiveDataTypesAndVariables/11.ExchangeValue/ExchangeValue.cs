using System;

class ExchangeValue
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        int c = a;
        Console.WriteLine("a = {0} \nb = {1}", a, b);

        a = b;
        b = c;
        Console.WriteLine("a = {0} \nb = {1}", a, b);
    }
}

