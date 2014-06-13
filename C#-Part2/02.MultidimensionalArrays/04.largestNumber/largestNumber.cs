//Write a program, that reads from the console an array of N integers and an integer K,
//sorts the array and using the method Array.BinSearch()
//finds the largest number in the array which is ≤ K. 

using System;

class largestNumber
{
    static void Main()
    {
        Console.WriteLine("Enter the elements of array");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number K");
        int k = int.Parse(Console.ReadLine());
        int[] arrayN = new int[n];

        Console.WriteLine("fill the array");
        for (int i = 0; i < n; i++)
        {
            arrayN[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arrayN);//sort array

        int element = Array.BinarySearch(arrayN, k);// use binarySearch() if elements is <0 = Element not found

        while (element < 0)
        {
            if (k<arrayN[0])
            {
                break;
            }
            k--;
            element = Array.BinarySearch(arrayN, k);
        }

        if (element<0)
        {
            Console.WriteLine("Can't find the lagest number");
        }
        else
        {
            Console.WriteLine("The largest number which is <= K is: {0}", arrayN[element]);
        }
    }
}

