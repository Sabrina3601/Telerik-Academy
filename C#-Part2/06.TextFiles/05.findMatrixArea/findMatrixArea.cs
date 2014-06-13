//Write a program that reads a text file containing a square matrix of numbers
//and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.
using System;
using System.IO;

class findMatrixArea
{
    static int[,] ReadMatrix()
    {
        StreamReader input = new StreamReader("../../matrix.txt");   
        using (input)
        {
            int n = int.Parse(input.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] numbers = input.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(numbers[j]);
                }
            }
            
            return matrix;
        }
    }

    static int getMax(int[,] matrix)
    {
        int maxSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0)-1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1)-1; col++)
            {
                int sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                if (sum>maxSum)
                {
                    maxSum = sum;
                }
            }
        }
        return maxSum;
    }

    static void Main()
    {
        Console.WriteLine("Max sum is: {0}", getMax(ReadMatrix()));
    }
}

