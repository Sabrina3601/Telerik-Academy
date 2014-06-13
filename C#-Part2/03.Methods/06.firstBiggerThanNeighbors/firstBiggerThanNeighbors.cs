//Write a method that returns the index of the first element in array
//that is bigger than its neighbors, or -1, if there’s no such element.
using System;

class firstBiggerThanNeighbors
{
    static int CheckNeighbors(int[] array)
    {
        int first = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[i - 1] && array[i] > array[i + 1])
            {
                first = array[i];

                break;
            }
            else first = -1;
        }
        return first;
    }
    static void Main()
    {
        int[] array = { 1, 2, 3, 1, 6, 3, 4, 7, 8, 21, 5, 6, 1, 3 };
        int result = CheckNeighbors(array);
        if (result == -1)
        {
            Console.WriteLine("There's no such element");
        }
        else
        {
            Console.WriteLine("The first element is " + result);
        }
        
    }
}

