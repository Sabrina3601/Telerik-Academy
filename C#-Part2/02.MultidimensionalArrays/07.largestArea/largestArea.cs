//Write a program that finds the largest area of equal neighbor elements
//in a rectangular matrix and prints its size. 
using System;

class largestArea
{
    static int area = 0;
    static int bestArea = 0;
    static char bestElement = 's';
    static char[,] matrix = 
    { 
        { '1', '3', '2', '2', '2', '4' }, 
        { '3', '3', '3', '2', '4', '4' }, 
        { '4', '3', '1', '2', '3', '3' }, 
        { '4', '3', '1', '3', '3', '1' }, 
        { '4', '3', '3', '3', '1', '1' } 
    };

    static void Main()
    {
        PrintMatrix(matrix);
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row,col] != 'c')
                {
                    char checkedValue = matrix[row, col];
                    findPath(row, col, checkedValue);
                    area = 0;
                }
            }
        }
        Console.WriteLine("Largest area of equal neighbor elements in matrix is {0}.", bestArea);
        Console.WriteLine("The element is: {0}.", bestElement);
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    static void findPath(int row, int col, char checkedValue)
    {
        if ((col<0)||(row<0) || (col>=matrix.GetLength(1)) || (row>= matrix.GetLength(0)))
        {
            // we are out of the matrix
            return;
        }

        //Check if we have already visited the cell.
        if (matrix[row, col] == 'c')
        {
            return;
        }
        if (matrix[row, col] != checkedValue)
        {
            //the current cell is not free
            return;
        }
        if (matrix[row, col] == checkedValue)
        {
            area++;
            if (area > bestArea)
            {
                bestArea = area;
                bestElement = checkedValue;
            }
        }
        //mark the current cell as visited
        matrix[row, col] = 'c';
        //Invoke recursion to check all directions.
        findPath(row + 1, col, checkedValue);//left
        findPath(row - 1, col, checkedValue);//up
        findPath(row, col + 1, checkedValue);//right
        findPath(row, col - 1, checkedValue);//down
    }
}

