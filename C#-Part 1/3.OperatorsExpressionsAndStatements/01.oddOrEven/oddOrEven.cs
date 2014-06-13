using System;

class oddOrEven
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        int getNumber = int.Parse(Console.ReadLine());
        if (getNumber == 0)
        {
            Console.WriteLine(getNumber + " is even"); //check number is even
        }
        else
        {
            Console.WriteLine(getNumber + " is odd"); //check number is odd
        }
    }
}

