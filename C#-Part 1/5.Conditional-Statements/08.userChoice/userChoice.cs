//Write a program that, depending on the user's choice
//inputs int, double or string variable. 
//If the variable is integer or double, increases it with 1. 
//If the variable is string, appends "*" at its end. 
//The program must show the value of that variable as a console output.
//Use switch statement.
using System;

class userChoice
{
    static void Main()
    {
        // use switch statementes and ask the user's what kind to be input information
        Console.WriteLine("Press 1 for int, 2 for double and 3 for string:");
        byte choice = byte.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter intiger");
                int valueInt = int.Parse(Console.ReadLine());
                int result = valueInt + 1;
                Console.WriteLine(result);
                break;
            case 2:
                Console.WriteLine("Enter real number");
                double valueDouble = double.Parse(Console.ReadLine());
                double resultDouble = valueDouble + 1;
                Console.WriteLine(resultDouble);
                break;
            case 3:
                Console.WriteLine("Enter string");
                string valueString = Console.ReadLine();
                string resultString = valueString + "*";
                Console.WriteLine(resultString);
                break;
            default:
                Console.WriteLine("Sorry can't running the program");
                break;
        }
    }
}
