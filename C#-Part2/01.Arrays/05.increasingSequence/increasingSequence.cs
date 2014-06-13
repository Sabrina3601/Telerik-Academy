//Write a program that finds the maximal increasing sequence in an array.
//Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

using System;

class increasingSequence
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

        for (int i = 0; i < arrayLenght - 1; i++)
        {
            if (arrayElements[i] + 1 == arrayElements[i + 1])
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

        if (lent > bestLent)
        {
            bestLent = lent;
            bestLentElement = arrayElements[arrayLenght - 1];
        }

        int[] sequence = new int[bestLent];

        for (int i = 0; i < bestLent; i++)
        {
            sequence[i] = bestLentElement - (bestLent - (i + 1));
        }

        Console.WriteLine(string.Join(", ", sequence));
    }
}

