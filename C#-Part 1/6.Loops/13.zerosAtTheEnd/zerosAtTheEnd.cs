using System;
using System.Numerics;
//Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	N = 10  N! = 3628800  2
//	N = 20  N! = 2432902008176640000  4
//	Does your program work for N = 50 000?
//	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!

class zerosAtTheEnd
{
    static void Main()
    {
        Console.WriteLine("Enter a factoriel number:");
        int N = int.Parse(Console.ReadLine());
        BigInteger save = 1;
        int zeros = 0;
        int upNumber = 1;

        for (int i = N; i > 0; i--)
        {
            save *= i;      
        }
        Console.WriteLine(save);
        // the number of zeros in n! is the sum: n/5 + n/25 + n/125 + …
        for (int j = 1; j <= N; j++)
			{
                upNumber *= 5;
                zeros += N / upNumber;
			}
        Console.WriteLine("trailing zeros are " + zeros);
       
    }
}

