//Sorting an array means to arrange its elements in increasing order.
//Write a program to sort an array. Use the "selection sort" algorithm:
//Find the smallest element, move it at the first position, 
//find the smallest from the rest, move it at the second position, etc.
using System;

class increasingOrder
{
    static void Main()
    {
        Console.WriteLine("Give the length of the array");
        int number = int.Parse(Console.ReadLine());
        int[] elements = new int[number];
        int now = 0;
        for (int i = 0; i < number; i++)
        {
            elements[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < elements.Length; i++)
        {
            for (int j = i+1; j < elements.Length; j++)
            {
                if (elements[i] > elements[j])
                {
                    now = elements[i];
                    elements[i] = elements[j];
                    elements[j] = now;
                }
            }
            
        }
        Console.WriteLine(string.Join(", ", elements));
    }
}

