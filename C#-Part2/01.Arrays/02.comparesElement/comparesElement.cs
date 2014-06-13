//Write a program that reads two arrays from the console
//and compares them element by element
using System;

class comparesElement
{
    static void Main()
    {
        Console.WriteLine("The lenght of two arrays must be equal!");
        int firstLenght = int.Parse(Console.ReadLine());
        int secondLenght = int.Parse(Console.ReadLine());
        bool isequal;
        if (firstLenght == secondLenght)
        {
            int[] firstArray = new int[firstLenght];
            int[] secondArray = new int[secondLenght];

            Console.WriteLine("Enter first " + firstLenght + " number of array");
            for (int i = 0; i < firstLenght; i++)
            {
                firstArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter first " + secondLenght + " number of array");
            for (int i = 0; i < firstLenght; i++)
            {
                secondArray[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < firstLenght; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    isequal = true;
                    Console.WriteLine(i + " elemet is it equal?" + isequal);
                }
                else
                {
                    isequal = false;
                    Console.WriteLine(i + " elemet is it equal? " + isequal);
                }
            }
        }
    }
}

