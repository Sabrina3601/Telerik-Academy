//We are given a matrix of strings of size N x M. Sequences in the matrix 
//we define as sets of several neighbor elements located on the same line,
//column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix. 
using System;

class sequenceMatrix
{
    static void Main()
    {

        string[,] matrix = new string[,]{
            {"ha","fifi","ho","hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha","xx"},
        };

        int currentSeq = 1;
        int maxSeq = 1;
        string maxElement = "elemets";

        //check horizontal position left to right
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1)-1; j++)
            {
                if (matrix[i,j] == matrix[i,j+1])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (maxSeq< currentSeq)
                {
                    maxSeq = currentSeq;
                    maxElement = matrix[i, j];
                }
            }
            currentSeq = 1;
        }

        //chek vertical position

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0)-1; j++)
            {
                if (matrix[j,i] == matrix[j+1,i])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (maxSeq < currentSeq)
                {
                    maxSeq = currentSeq;
                    maxElement = matrix[j, i];
                }
            }
            currentSeq = 1;
        }


        //check diagonal left to right
        for (int i = 0; i < matrix.GetLength(0)-1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                
                if (matrix[i, j] == matrix[i + 1, j + 1])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (maxSeq < currentSeq)
                {
                    maxSeq = currentSeq;
                    maxElement = matrix[i, j];
                }
                if (i <= matrix.GetLength(0) - 1)
                {
                    i++;
                }

            }
            currentSeq = 1;
        }
        //check diagonal right to left
        for (int i = 0; i < matrix.GetLength(0)-1; i++)
        {
            for (int j = matrix.GetLength(1) - 1; j >1; j--)
            {
                if (matrix[i, j] == matrix[i + 1, j - 1])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (maxSeq < currentSeq)
                {
                    maxSeq = currentSeq;
                    maxElement = matrix[i, j];
                }
                if (i <= matrix.GetLength(0) - 1)
                {
                    i++;
                }
            }
            currentSeq = 1;
        }

        Console.WriteLine("Element \"{0}\" repeats {1} times!", maxElement, maxSeq);
        
    }
}

