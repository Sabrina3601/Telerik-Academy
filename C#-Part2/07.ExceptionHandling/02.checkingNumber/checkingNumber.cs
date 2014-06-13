//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
//If an invalid number or non-number text is entered, the method should throw an exception. 
//Using this method write a program that enters 10 numbers:
			//a1, a2, … a10, such that 1 < a1 < … < a10 < 100


using System;

class CheckingNumbers
{
    static int ReadNumber(int start, int end, int number)
    {
        int n = 1;
        Console.Write("Please enter number {0}: ", number);
        n = int.Parse(Console.ReadLine());
        if (n < start || n > end)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        return n;
    }
    static void Main()
    {
        Console.WriteLine("Enter 10 numbers");
        int n = 1;
        try
        {
            for (int i = 1; i <= 10; i++)
            {
                n = ReadNumber(n, 100, i);
            }
        }
        catch (System.FormatException) // Exception if is not number
        {
            Console.WriteLine("Not an integer number.");
        }
        catch (System.OverflowException) // Exception out of intiger
        {
            Console.WriteLine("Not in the scope of integer.");
        }
        catch (System.ArgumentOutOfRangeException) // Exception input is not in rage
        {
            Console.WriteLine("The entered number is not in range."); 
        }
    }
}

