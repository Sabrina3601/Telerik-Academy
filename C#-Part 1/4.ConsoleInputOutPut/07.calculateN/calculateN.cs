using System;

class calculateN
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = number; i > 0; i--)
        {
            Console.WriteLine("Enter " + i + " numbers");
            int n = int.Parse(Console.ReadLine());
           
            sum = sum + n;
           
        }
         Console.WriteLine("Sum is " + sum); //print sum
    }
}
