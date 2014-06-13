using System;

class primeNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a number <= 100");
        byte n = byte.Parse(Console.ReadLine());
        byte savePrime = 0;
        if (n <= 100)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++) //square of given number is absolutely enough. Is not necessary to check hole number
            {
                if (n % i == 0)
                {
                    savePrime++;
                }
            }
            if (savePrime == 0) //check is it prime
            {
                Console.WriteLine(n + " is prime number");
            }
            else
            {
                Console.WriteLine(n + " is not prime number");
            }
        }

        else
        {
            Console.WriteLine("The number is bigger than 100");
        }
    }
}
