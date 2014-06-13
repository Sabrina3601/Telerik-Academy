//Sort 3 real values in descending order using nested if statements.
using System;

class descendingValues
{
    static void Main()
    {
        Console.WriteLine("Enter a first number");
        double numberFirst = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a second number");
        double numberSecond = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a third number");
        double numberThird = double.Parse(Console.ReadLine());
        // use if statements to order numbers
        if (numberFirst > numberSecond && numberFirst > numberThird)
        {
            if (numberSecond> numberThird)
            {
                Console.WriteLine(numberFirst + " " + numberSecond + " " + numberThird );
            }
            else
            {
                Console.WriteLine(numberFirst + " " + numberThird + " " + numberSecond);
            }
        }
        else if (numberSecond > numberFirst && numberSecond > numberThird)
        {
            if (numberFirst > numberThird)
            {
                Console.WriteLine(numberSecond + " " + numberFirst + " " + numberThird);
            }
            else
            {
                Console.WriteLine(numberSecond + " " + numberThird + " " + numberFirst);
            }
        }
        else if (numberThird > numberFirst && numberThird > numberSecond)
        {
            if (numberFirst > numberSecond)
            {
                Console.WriteLine(numberThird + " " + numberFirst + " " + numberSecond);
            }
            else
            {
                Console.WriteLine(numberThird + " " + numberSecond + " " + numberFirst);
            }
        }
    }
}

