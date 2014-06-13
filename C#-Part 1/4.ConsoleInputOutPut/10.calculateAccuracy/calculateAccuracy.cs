using System;

class calculateAccuracy
{
    static void Main(string[] args)
    {
            decimal sum = 1m;

            for (decimal i = 2m; true; i++)
            {
                if (i % 2 == 0)
                {

                    sum += 1m / i;
                }
                else
                {
                    sum -= 1m / i;
                }

                if (1m / i < 0.001m)//check with accuracy of 0.001
                {
                    Console.WriteLine(sum);
                    break;
                }
            }
    }
}
