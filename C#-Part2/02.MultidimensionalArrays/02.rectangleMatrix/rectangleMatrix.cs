//Write a program that reads a rectangular matrix of size N x M
//and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class rectangleMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n,m];
        int save= 1;
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        //ganarate some number for matrix
        for (int row = 0; row < matrix.GetLength(0); row++)
		{
			for (int col = 0; col < matrix.GetLength(1); col++)
			{
			 matrix[row,col] = save;
             save++;
			}
		}

        for (int row = 0; row < matrix.GetLength(0)-2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1)-2; col++)
            {
                int sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1] +
                    matrix[row, col +2] + matrix[row+1, col+2] + matrix[row+2, col] + matrix[row+2, col+1] + matrix[row+2, col+2];

                if (sum>bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        //print matrix
        Console.WriteLine("That is your matrix");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Best platform");
        Console.WriteLine(matrix[bestRow,bestCol] + " " + matrix[bestRow,bestCol+1] + " " + matrix[bestRow,bestCol+2]);
        Console.WriteLine(matrix[bestRow +1 ,bestCol] + " " + matrix[bestRow +1 ,bestCol+1] + " " + matrix[bestRow+1,bestCol+2]);
        Console.WriteLine(matrix[bestRow + 2, bestCol] + " " + matrix[bestRow + 2, bestCol + 1] +" "+ matrix[bestRow + 2, bestCol + 2]);
        Console.WriteLine();
        Console.WriteLine("Best sum is:");
        Console.WriteLine(bestSum);
    }
}

