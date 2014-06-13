//Write a program that reads two numbers N and K
//and generates all the combinations of K distinct elements from the set [1..N].
//Example:
//N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
using System;

class generateCombinations
{

    public static int[] sett;

    public static bool IsThereRepetition(int[] arr)
    {
        bool isRepeating = false;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    isRepeating = true;
                    goto Exit;
                }
            }
        }

    Exit: { };
        return isRepeating;
    }

    public static void Print(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    public static void ClearSubset(int[] arr, int index)
    {
        for (int i = 0; i <= index; i++)
        {
            arr[i] = 1;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter N :");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter K :");
        int k = int.Parse(Console.ReadLine());

        sett = new int[k];
        ClearSubset(sett, k - 1);

        int count = 1;
        int index = 1;
        while (sett[k - 1] <= n) 
        {

            for (int i = index; i <= n; i++)
            {
                sett[0] = i;

                if (IsThereRepetition(sett) == false)
                {
                    Print(sett); 
                }
            }
            index++;

            if (index == n)
            {
                break;
            }

            sett[1]++;

            for (int i = 0; i < k - 1; i++)
            {
                if (sett[i] == n + 1)
                {
                    sett[i + 1]++;
                    ClearSubset(sett, i);
                }
            }
            count++;
        }
    }
}

