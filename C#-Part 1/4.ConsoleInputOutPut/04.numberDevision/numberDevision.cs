using System;

class numberDevision
{
    static void Main()
    {
        Console.WriteLine("Enter a first number:");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        int result = 0;

        if (firstNumber>secondNumber)//check which number is bigger
        {
            for (int i = secondNumber; i <= firstNumber; i++)
            {
                if (i%5==0) //now check can be devided by 5 with 0 reminder
                {
                    result++;
                }
            }
            Console.WriteLine(result + " numbers can be devided by 5 with 0 reminder");
        }
        else
        {
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                if (i % 5 == 0)// and check againd
                {
                    result++;
                }
            }
            Console.WriteLine(result + " numbers can be devided by 5 with 0 reminder");
        }
    }
}

