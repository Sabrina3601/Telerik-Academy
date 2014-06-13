using System;

class UseQuotations
{
    static void Main()
    {
        string a = @"The ""use"" of quotations causes difficulties.";
        string b = "The \"use\" of quotations causes difficulties.";
        string c = "The use of quotations causes difficulties.";

        Console.WriteLine(a + "\n" + b + "\n" + c);
    }
}

