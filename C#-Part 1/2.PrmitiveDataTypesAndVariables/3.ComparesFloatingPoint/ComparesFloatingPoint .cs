using System;

class ComparesFloatingPoint 
{
    static void Main()
    {
        Console.WriteLine("Please type a floating point number");
        decimal FirstValue = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Please type another floating point number");
        decimal SecondValue = decimal.Parse(Console.ReadLine());
        decimal result = Math.Abs(FirstValue - SecondValue);
        bool resultPrecission = result < 0.000001m;

        if (resultPrecission == true)
        {
            Console.WriteLine(resultPrecission + " - These numbers are equal with precision of  0.000001");
        }
        else
        {
            Console.WriteLine(resultPrecission + " - These numbers are not equal with precision of  0.000001");
        }
    }
}

