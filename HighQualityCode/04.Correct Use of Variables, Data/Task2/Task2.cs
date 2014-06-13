using System;

class PrintStatistic
{
    double max = 0;
    double tmp = 0;

    public void PrintMinElement(double[] arr, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (arr[i] < max)
            {
                max = arr[i];
            }
        }
        PrintStatistic(max);
    }

    public void PrintMaxElement(double[] arr, int count)
    {   
        for (int i = 0; i < count; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        PrintStatistic(max);
    }

    public void PrintAvarageElement(double[] arr, int count)
    {  
        for (int i = 0; i < count; i++)
        {
            tmp += arr[i];
        }
        PrintStatistic(tmp / count);
    }

    public void PrintStatistic(double value)
    {
        Console.WriteLine(value);
    }
}