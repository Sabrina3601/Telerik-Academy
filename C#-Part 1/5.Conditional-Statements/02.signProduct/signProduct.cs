//Write a program that shows the sign (+ or -) of the product of three real numbers
//without calculating it. Use a sequence of if statements.

using System;

class signProduct
{
    static void Main()
    {
        Console.WriteLine("Enter a first number");
        double numberFirst = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a second number");
        double numberSecond = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a third number");
        double numberThird = double.Parse(Console.ReadLine());

        int caunter = 0;
        if (numberFirst < 0)//find how numbers has sign -
        {
            caunter++;
        }
        if (numberSecond < 0)
        {
            caunter++;
        }
        if (numberThird < 0)
        {
            caunter++;
        }
        if ((numberFirst != 0) && (numberSecond != 0) && (numberThird != 0))
        {
            if (caunter % 2 == 0) //if counter is even number the sign is + 
            {
                Console.WriteLine("The sign is + ");
            }
            else
            {
                Console.WriteLine("The sign is -");
            }
        }
        else
        {
            Console.WriteLine("The result is 0");
        }

    }
}
