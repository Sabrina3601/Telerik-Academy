//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//		Create appropriate methods.
//		Provide a simple text-based menu for the user to choose which task to solve.
//		Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;

class sloveTasks
{

    static decimal Reverse(decimal number) // method that reverse a given number
    {
        string strNumber = number.ToString();
        string reverseStrNum = "";
        for (int i = strNumber.Length-1; i >= 0; i--)
        {
            reverseStrNum += strNumber[i].ToString();
        }
        decimal reverseNumber = int.Parse(reverseStrNum);
        return reverseNumber;

    }
    static decimal Avarage(int[] sequnce)// method find avarage of a sequence
    {
        int sum = 0;
        for (int i = 0; i < sequnce.Length; i++)
        {
            sum += sequnce[i];
        }
        decimal avarageSum = (decimal)sum / (decimal)sequnce.Length;
        return avarageSum;
    }
    static decimal LinearEquation(int a, int b) // method that sloved a linear equation
    {
        decimal x = (decimal)-b / (decimal)2;
        return x;
    }
    static void Main()
    {
        Console.WriteLine("Press 0 - Exit \nPress 1 - Reverse \nPress 2 - Calculates the average of a sequence \nPress 3 - Solves a linear equation a * x + b = 0");
        string decision = Console.ReadLine();
        if (decision == "0")
        {
            return;
        }
        else if (decision == "1")
        {
            Console.WriteLine("Enter a number");
            decimal number = decimal.Parse(Console.ReadLine());
            if (number > 0)
            {
                Console.WriteLine(Reverse(number));
            }
            else
            {
                Console.WriteLine("The number must be a positive intiger");
            }          
        }
        else if (decision == "2")
        {
            Console.WriteLine("Enter a lenght of sequence");
            int lenght = int.Parse(Console.ReadLine());
            if (lenght > 0 )
            {
                Console.WriteLine("Enter a number of sequnce");
                int[] sequence = new int[lenght];
                for (int i = 0; i < sequence.Length; i++)
                {
                    sequence[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine( Avarage(sequence) ); 
            }
            else
            {
                Console.WriteLine("A lenght of sequence must be more than zero");
            }
            
        }
        else if (decision == "3")
        {
            Console.WriteLine("Enter number a of equation");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number b of equation");
            int b = int.Parse(Console.ReadLine());

            if (a!=0)
            {
                
                Console.WriteLine("X is: " + LinearEquation(a,b));
            }
            else
            {
                Console.WriteLine("A must be not equal to 0.");
            }

        }
       
        


    }
}

