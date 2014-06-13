//Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;

class frequentNumber
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

        int maxCounter = 0;
        int maxSelectNum = 0;
        int counter = 0;
        int selectNum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    counter++;
                    selectNum = array[i];
                    if (counter>maxCounter)
                    {
                        maxCounter = counter;
                        maxSelectNum = selectNum;
                    }  
                }  
            }
            counter = 0;
        }
        Console.WriteLine("The most number frequent number is: {0} ({1} times),", maxSelectNum, maxCounter);
    }
}

