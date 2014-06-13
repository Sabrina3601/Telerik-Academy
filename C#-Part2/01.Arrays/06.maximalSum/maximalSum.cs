//Write a program that reads two integer numbers N and K
//and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.
using System;

class maximalSum
{
    static void Main()
    {

        Console.WriteLine("Enter array of N elements.");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter array of K elements that have maximal sum.");
        int K = int.Parse(Console.ReadLine());
        int[] arrayElements = new int[N];
        string elementsOfK = "";
        string saveElements = "";
        for (int i = 0; i < N; i++)
        {
            arrayElements[i] = int.Parse(Console.ReadLine());
        }

        int sum = 0;
        int saveSum = 0;

        for (int i = 0; i < arrayElements.Length-K; i++)
        {
            for (int j = i; j < K+i; j++)
			{
                sum += arrayElements[j];
                elementsOfK += arrayElements[j] + " ";
			}
            if (sum>saveSum)
            {
                saveSum = sum;
                saveElements = elementsOfK;
                elementsOfK = "";
                sum = 0;
            }
            else
            {
                sum = 0;
                elementsOfK = "";
            }
            
        }
        //special check
        for (int i = arrayElements.Length - K; i < arrayElements.Length; i++)
        {
            sum += arrayElements[i];
            elementsOfK += arrayElements[i] + " ";
            
        }
        if (sum > saveSum)
        {
            saveSum = sum;
            saveElements = elementsOfK;
            elementsOfK = "";
            sum = 0;
        }
        Console.WriteLine("Maximal sum is " + saveSum);
        Console.WriteLine("Numbers: " + saveElements);
    }
}

