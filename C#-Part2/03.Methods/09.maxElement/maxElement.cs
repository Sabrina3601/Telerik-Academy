//Write a method that return the maximal element in a portion of array 
//of integers starting at given index. 
//Using it write another method that sorts an array in ascending / descending order.

using System;

class maxElement
{
    static int MaxElement(int[] array, int index)
    {
        int max = 0;
        if (index < array.Length)
        {
            for (int i = index; i < array.Length; i++)
            {
                if (max<array[i])
                {
                    max = array[i];
                }
            }
        }
        return max;
        
    }
    static void Main()
    {
        int[] arrays = new int[] {1,23,15,5,2,4,5,4,1,1};
        int index = int.Parse(Console.ReadLine());

        Console.WriteLine(MaxElement(arrays, index));
    }
}

