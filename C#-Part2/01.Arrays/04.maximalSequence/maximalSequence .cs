//Write a program that finds the maximal sequence of equal elements in an array.
//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
using System;

class Program
{
    static void Main()
    {
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] arrayElements = new int[arrayLenght];

        int lent = 1;
        int bestLent = 0;
        int bestLentElement = 0;

        for (int i = 0; i < arrayLenght; i++)
        {
            arrayElements[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < arrayLenght-1; i++)
        {
            if (arrayElements[i] == arrayElements[i+1])
            {
                lent++;
                
            }
            else
            {
                if (lent > bestLent)
                {
                    bestLent = lent;
                    bestLentElement = arrayElements[i];    
                }
                lent = 1;
            }
        }

        if (lent>bestLent)
        {
            bestLent = lent;
            bestLentElement = arrayElements[arrayLenght-1];
        }

        int[] sequence = new int[bestLent];

        for (int i = 0; i < sequence.Length; i++)
		{
			 sequence[i] = bestLentElement;
		}

        Console.WriteLine(string.Join(", ", sequence ));
       
    }
}

    