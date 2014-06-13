using System;

class NullableVariables
{
    static void Main()
    {
        int? a = null;
        double? b = null;
        Console.WriteLine("value a = {0}" + "\n" + "value b = {1}", a, b);

        a = 5;
        b = 4.123121;
        Console.WriteLine("value a = {0}"  + "\n" + "value b = {1}", a, b);
    }
}
