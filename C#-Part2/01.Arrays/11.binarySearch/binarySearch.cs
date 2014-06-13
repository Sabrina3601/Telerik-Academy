//Write a program that finds the index of given element in a sorted array of integers
//by using the binary search algorithm (find it in Wikipedia).

using System;

class binarySearch
{
    static void Main()
    {
        Console.WriteLine("Give the lenght of array");
        int lenghtOfArray = int.Parse(Console.ReadLine());
        int[] sortArray = new int[lenghtOfArray];

        for (int i = 0; i < sortArray.Length; i++)
        {
            sortArray[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter a search number:");
        int key = int.Parse(Console.ReadLine());

        Array.Sort(sortArray);
        int left = 0;
        int right = sortArray.Length-1;
        while (left <= right)
        {
            int middle = (left + right) / 2;
            if (sortArray[middle] == key)
            {
                Console.WriteLine(middle);
                break;
            }
            else if (sortArray[middle] > key)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
    }
}

