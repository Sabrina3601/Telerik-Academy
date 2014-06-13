using System;
//Write a program that calculates N!/K! for given N and K (1<K<N).

class factorialDevision
{
    static void Main()
    {
        Console.WriteLine("Give a number for N");
        uint N = uint.Parse(Console.ReadLine());
        Console.WriteLine("Give me a number for K");
        uint K = uint.Parse(Console.ReadLine());
        uint nResult = 1;
        uint kResult = 1;
        uint result;
        if ( K<N && K>1 )
        {
            for (uint i = N; i > 0; i--)//Loop for N!
            {
                nResult *= i;
            }
            for (uint i = K; i > 0; i--)//Loop for K!
            {
                kResult *= i;
            }
            result = nResult / kResult; //save result
            Console.WriteLine("N!/K! = {0}", result  );
        }
        else
        {
            Console.WriteLine("Sorry check your numbers 1<K<N ");
        }
    }
}

