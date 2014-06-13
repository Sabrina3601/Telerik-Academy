//Write a program that compares two char arrays lexicographically (letter by letter).
using System;

class compareChar
{
    static void Main()
    {
        Console.WriteLine("The lenght of two arrays must be equal!");
        int firstLenght = int.Parse(Console.ReadLine());
        int secondLenght = int.Parse(Console.ReadLine());
        bool isequal = true;
        if (firstLenght == secondLenght)
        {
            char[] firstChar = new char[firstLenght];
            char[] secondChar = new char[secondLenght];

            Console.WriteLine("Enter first " + firstLenght + " of char array");
            for (int i = 0; i < firstLenght; i++)
            {
                firstChar[i] = char.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter first " + secondLenght + " of char array");
            for (int i = 0; i < firstLenght; i++)
            {
                secondChar[i] = char.Parse(Console.ReadLine());
            }

            for (int i = 0; i < firstLenght; i++)
            {
                if (firstChar[i] == secondChar[i])
                {
                    isequal = true;
                    Console.WriteLine(i + " char is it equal? " + isequal);
                }
                else
                {
                    isequal = false;
                    Console.WriteLine(i + " char is it equal? " + isequal);
                }
            }
            Console.WriteLine("Are char arrays equals? " + isequal);
        }
    }
}

