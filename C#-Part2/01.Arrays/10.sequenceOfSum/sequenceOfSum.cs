//Write a program that finds in given array of integers a sequence of given sum S (if present).
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	

using System;

class sequenceOfSum
{
    static void Main()
    {
        Console.WriteLine("Give a sum S:");
        int S = int.Parse(Console.ReadLine());
        Console.WriteLine("Give the length of the array");
        int number = int.Parse(Console.ReadLine());
        int[] array = new int[number];

        for (int i = 0; i < number; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        int sum = 0;
        string sumElement = "";
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
            sumElement += array[i] + " ";
            if (sum == S)
            {
                break;
            }
            else if (sum >S)
            {
                i = i - 1;
                sum = 0;
                sumElement = "";
            }
        }
        Console.WriteLine(sumElement + " = " + S);

    }
}

