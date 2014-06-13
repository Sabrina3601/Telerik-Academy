using System;
//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

class factorialFormula
{
    static void Main()
    {
        Console.WriteLine("Give a number for N");
        uint N = uint.Parse(Console.ReadLine());
        Console.WriteLine("Give me a number for K");
        uint K = uint.Parse(Console.ReadLine());
        uint nResult = 1;
        uint kResult = 1;
        uint secondFormula = K - N;
        uint secondFormulaResult = 1;
        uint result;
        if (N < K && N > 1)
        {
            for (uint i = N; i > 0; i--)//Loop for N!
            {
                nResult *= i;
            }
            for (uint i = K; i > 0; i--)//Loop for K!
            {
                kResult *= i;
            }
            for (uint i = secondFormula; i > 0; i--)//Loop for K-N!
            {
                secondFormulaResult *= i;
            }
            result = (nResult * kResult)/secondFormulaResult; //save result
            Console.WriteLine("N!*K! / (K-N)! = {0}", result);
        }
        else
        {
            Console.WriteLine("Sorry check your numbers 1<N<K ");
        }
    }
}

