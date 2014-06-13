//Write a method that checks if the element at given position in given array of integers
//is bigger than its two neighbors (when such exist).

using System;

class biggerThanNeighbors
{

    static bool CheckNeighbors(int[] array, int position)
    {
        bool check;
        if (array[position]!= array.Length && array[position] != 0)
        {
            if (array[position] > array[position-1] && array[position] > array[position+1])
            {
                Console.WriteLine("Element is bigger than neighbors");
                check = true;
                return check;
            }
            else
            {
                Console.WriteLine("Element is not bigger than neighbors");
                check = false;
                return check;
            }
        }
        else
        {
            Console.WriteLine("No exist neghbors.");
            check = false;
            return check;
        }
    }
    static void Main()
    {
        int[] array = { 1,2,3,1,6,3,4,7,8,21,5,6,1,3};
        Console.WriteLine("Give a position");
        int position = int.Parse(Console.ReadLine());
        bool result = CheckNeighbors(array, position);
        Console.WriteLine("Answer is " + result);
    }
}

