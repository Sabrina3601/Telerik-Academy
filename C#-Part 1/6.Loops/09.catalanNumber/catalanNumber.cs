using System;
//Write a program to calculate the Nth Catalan number by given N.

class catalanNumber
{
    static void Main()
    {
        Console.WriteLine("Enter Nth Catalan number");
        double N = double.Parse(Console.ReadLine());
        double result = 1;
        if (N>=0)
        {
            for (double i = 1; i <= N; i++)// Divide the formula of loops
            {
                double firstPart = 2 * i;
                double firstSave = 1;
                for (double j = firstPart; j >= 1; j--)
                {
                    firstSave *= j;
                }

                double secondPart = N + 1;
                double secondSave = 1;
                for (double k = secondPart; k >= 1; k--)
                {
                    secondSave *= k;
                }

                double thirdSave = 1;
                for (double l = N; l >= 1; l--)
                {
                    thirdSave *= l;
                }
                result = firstSave / (secondSave * thirdSave); // now take result
                
            }
            Console.WriteLine("Catalan Number: " + result);
        }
    }
}

