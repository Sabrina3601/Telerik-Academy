//Write a program to check if in a given expression the brackets are put correctly.

using System;

class checkExpression
{
    static void Main()
    {
        Console.WriteLine("Give a expression");
        string expression = Console.ReadLine();
        int open = 0;
        int close = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                if (open == 0)
                {
                    open++;
                }
                else
                {
                    open--;
                }
            }
            else if (expression[i] == ')')
            {

                if (close == 0)
                {
                    close++;
                }
                else
                {
                    close--;
                }
            }
        }

        if (close == 0 && open == 0)
        {
            Console.WriteLine("Math Expression is currect");
        }
        else
        {
            Console.WriteLine("Math Expression is not currect");
        }
    }
}

