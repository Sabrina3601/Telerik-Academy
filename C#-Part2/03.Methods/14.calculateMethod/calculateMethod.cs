//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//Use variable number of arguments.


using System;

class calculateMethod
{
    static int Min(params int[] sequence) // method that find a minimal of sequence
    {
        int min = int.MaxValue;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] < min)
            {
                min = sequence[i];
            }
        }
        return min;
    }
    static int Max(params int[] sequence) // method that find a maximum of sequence
    {
        int max = int.MinValue;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] > max)
            {
                max = sequence[i];
            }
        }
        return max;
    }
    static decimal Avarage(params int[] sequence) // method that find a avarage of sequence
    {
        int sum = Sum(sequence);
        decimal avarageSum = (decimal)sum / (decimal)sequence.Length;
        return avarageSum;
    }

    static int Sum(params int[] sequence) // method that find a sum of sequence
    {
        int sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }
        return sum;
    }
    static int Product(params int[] sequence) // method that find a product of sequence
    {
        int product = 1;
        for (int i = 0; i < sequence.Length; i++)
        {
            product *= sequence[i];
        }
        return product;
    }
    static void Main()
    {
        Console.WriteLine("Enter a lenght of sequence");
        int lenght = int.Parse(Console.ReadLine());
        int[] sequence = new int[lenght];
        for (int i = 0; i < lenght; i++)
        {
            sequence[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Min: " + Min(sequence));
        Console.WriteLine("Max: " + Max(sequence));
        Console.WriteLine("Avarage: " + Avarage(sequence));
        Console.WriteLine("Sum: " + Sum(sequence));
        Console.WriteLine("Product: " + Product(sequence));
        
    }
}
