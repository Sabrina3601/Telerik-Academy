//Write a program that finds the greatest of given 5 variables.
using System;
class findGreatest
{
    static void Main()
    {
        Console.WriteLine("Enter a first number");
        double numberFirst = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a second number");
        double numberSecond = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a third number");
        double numberThird = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a third number");
        double numberFourth = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter a third number");
        double numberFith = double.Parse(Console.ReadLine());
        double[] myArray = { numberFirst, numberSecond, numberThird, numberFourth, numberFith };
        int length = myArray.Length;
        double save = numberFirst;
        for (int i = 0; i < length; i++)//use for loop to find the greatest number
        { 
            if (save < myArray[i])
            {
                save = myArray[i];  
            }
        }
        Console.WriteLine("The bigest number is {0}", save);
    }
}

