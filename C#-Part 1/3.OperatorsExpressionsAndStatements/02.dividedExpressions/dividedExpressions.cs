using System;

class dividedExpressions
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        int getNumber = int.Parse(Console.ReadLine());
        if (getNumber % 35 == 0) // 7 * 5 = 35 
        {
            Console.WriteLine(getNumber + " can be divided by 7 and 5 in the same time");
        }
        else
        {
            Console.WriteLine(getNumber + " can't be divided by 7 and 5 in the same time");
        }
    }
}
