using System;
//Write a program that reads a positive integer number N (N < 20) from console and outputs in the console
//the numbers 1 ... N numbers arranged as a spiral.
class NumbersAsSpiral
{
    static void Main()
    {
        int n = 0;
        int[,] spiralMatrix;
 
        while (true)
        {
            Console.Write("Enter Number between [1 - 20]: ");
            if (int.TryParse(Console.ReadLine(), out n) && n < 20)
            {
                int counter = 0;
                spiralMatrix = new int[n, n];
                int startRow = 0;
                int endRow = (n - 1);
                int startCol = 0;
                int endCol = (n - 1);
                
                while (counter < n*n)
                {
                    // Moving to the right
                    for (int colNum = startCol; colNum <= endCol; colNum++)
                    {
                        counter++;
                        spiralMatrix[startRow, colNum] = counter;
                    }
                    startRow++;
 
                    // Moving to the bottom
                    for (int rowNum = startRow; rowNum <= endRow; rowNum++)
                    {
                        counter++;
                        spiralMatrix[rowNum, endCol] = counter;
                    }
                    endCol--;
 
                    // Moving to the left
                    for (int colNum = endCol; colNum >= startCol; colNum--)
                    {
                        counter++;
                        spiralMatrix[endRow, colNum] = counter;
                    }
                    endRow--;
 
                    // Moving to the top row
                    for (int rowNum = endRow; rowNum >= startRow; rowNum--)
                    {
                        counter++;
                        spiralMatrix[rowNum, startCol] = counter;
                    }
                    startCol++;
                }

                for (int row = 0; row <= n - 1; row++)
                {
                    for (int col = 0; col <= n - 1; col++)
                    {
                        Console.Write("{0, 4}", spiralMatrix[row, col]);
                    }
                    Console.WriteLine();
                }
                break;
            }
            else
            {
                Console.WriteLine("Wrong input!!!");
            }
        }
    }
}