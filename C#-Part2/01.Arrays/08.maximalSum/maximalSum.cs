//Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//Can you do it with only one loop (with single scan through the elements of the array)?
using System;

class maximalSum
{
    static void Main()
    {
        Console.WriteLine("Give the length of the array");
        int number = int.Parse(Console.ReadLine());
        int[] array = new int[number];
        for (int i = 0; i < number; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        int arrayLenght = array.Length;
 
        int biggestSum = array[0];
        string bigSequence = Convert.ToString(array[0]);
        int sum = array[0];

        string sequence = array[0] + " ";

        for (int j = 1; j < arrayLenght; j++)
        {
            sum += array[j];
            sequence += array[j] + " ";
            if (sum > biggestSum)
            {
                biggestSum = sum;
                bigSequence = sequence;
            }
            if (sum < 0)
            {
                sum = 0;
                sequence = "";
            }
        }
        Console.WriteLine("The biggest sum is: {0}", biggestSum);
        Console.WriteLine("The best sequence is: {0}", bigSequence);
    }
}

