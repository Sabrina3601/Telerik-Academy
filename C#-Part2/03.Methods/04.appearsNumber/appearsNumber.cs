//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is working correctly.

using System;

class appearsNumber
{
    static int CheckAppears(int[] array, int number)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                counter++;
            }
        }
        return counter;
    }

    static void Main()
    {
        int[] array = {1,2,3,4,5,5,1,2,3,4,5,6};
        Console.WriteLine("Enter a number to check how many times appears in my array");
        int number = int.Parse(Console.ReadLine());
        int result = CheckAppears(array,number);
        Console.WriteLine(result);
    }
}

