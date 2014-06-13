using System;
//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN


class factorialSum
{
    static void Main()
    {
        Console.WriteLine("Give a number for N");
        double N = double.Parse(Console.ReadLine());
        Console.WriteLine("Give me a number for K");
        double X = double.Parse(Console.ReadLine());
        double saveFactorial = 1;
        double saveX = 1;
        double sum = 0;

        for (double i = 1; i <= N; i++)
        {
            for (double j = i; j >= 1; j--)
            {   
                saveFactorial *= j;
            }
            saveX = X * saveX;
            sum += (saveFactorial / saveX);
            Console.WriteLine("{0}!/{1}^{2} = {3}! /{4}",i, X,i,saveFactorial,saveX);
            saveFactorial = 1;
        }
        Console.WriteLine(sum);
    }
}

