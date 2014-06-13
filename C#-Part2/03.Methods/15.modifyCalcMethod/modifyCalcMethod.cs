//* Modify your last program and try to make it work for any number type, 
//not just integer (e.g. decimal, float, byte, etc.). 
//Use generic method (read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class calculateMethod
{
    static T Min<T>(params T[] sequence) // method that find a minimal of sequence
    {
        dynamic min = sequence[0];
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] < min)
            {
                min = sequence[i];
            }
        }
        return min;
    }
    static T Max<T>(params T[] sequence) // method that find a maximum of sequence
    {
        dynamic max = sequence[0];
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] > max)
            {
                max = sequence[i];
            }
        }
        return max;
    }
    static T Avarage<T>(params T[] sequence) // method that find a avarage of sequence
    {
        dynamic sum = Sum(sequence);
        dynamic avarageSum = sum / sequence.Length;
        return avarageSum;
    }

    static T Sum<T>(params T[] sequence) // method that find a sum of sequence
    {
        dynamic sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }
        return sum;
    }
    static T Product<T>(params T[] sequence) // method that find a product of sequence
    {
        dynamic product = 1;
        for (int i = 0; i < sequence.Length; i++)
        {
            product *= sequence[i];
        }
        return product;
    }
    static void Main()
    {
        Console.WriteLine("The minimum of set is: {0}", Min(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The maximum of set is: {0}", Max(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The average of set is: {0}", Avarage(2, 3));
        Console.WriteLine("The sum of set is: {0}", Sum(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The product of set is: {0}", Product(1, 2, 3, 4, -5, 6, 7));

    }
}

