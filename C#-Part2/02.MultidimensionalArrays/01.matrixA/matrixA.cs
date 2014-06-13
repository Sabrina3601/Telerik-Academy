//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

using System;

class matrixA
{
    static void Main()
    {
        Console.WriteLine("Enter matrix size");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n,n];

        
        //a)
        int save = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[j, i] = save;
                save ++;
            }
        }
        //print matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        //B)
        int[,] matrixB = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i % 2 == 0)
                {
                    matrixB[j, i] = save;
                    save++;
                }
                else
                {
                    matrixB[(n - 1) - j, i] = save;
                    save++;
                }
                
            }
        }
        //print matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} ", matrixB[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        //c)
        int value = 1;
        int[,] matrixC = new int[n, n];
        int rows = n - 1;
        int cols = 0;
        int index = 1;
        //first retangle
        while (true)
        {
            if (rows == n - 1 && rows != cols)
            {
                matrixC[rows, cols] = value;
                value++;
                rows -= index;
                cols = 0;
                index++;
            }
            else if (rows != n - 1)
            {
                matrixC[rows, cols] = value;
                value++;
                rows++;
                cols++;
            }
            else if (rows == n - 1 && cols == rows)
            {
                matrixC[rows, cols] = value;
                rows = 0;
                cols = 1;
                value++;
                break;
            }
        }
        //second retangle
        index = 1;
        while (true)
        {
            if (cols == n - 1 && rows != 0)
            {
                matrixC[rows, cols] = value;
                value++;
                index++;
                cols = index;
                rows = 0;
            }
            else if (cols != n - 1)
            {
                matrixC[rows, cols] = value;
                value++;
                rows++;
                cols++;
            }
            else if (cols == n - 1 && rows == 0)
            {
                matrixC[rows, cols] = value;
                break;
            }
        }
        //print matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} ", matrixC[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        // d)*
        int[,] matrixD = new int[n, n];
        string direction = "down";
        int currentRow = 0;
        int currentCol = 0;

        for (int i = 1; i <=n*n; i++)
        {
            if (direction == "down" && (currentRow >= n || matrixD[currentRow, currentCol] != 0))
            {
                currentRow--;
                currentCol++;
                direction = "right";
            }
            else if (direction == "right" && (currentCol >= n || matrixD[currentRow, currentCol] != 0))
            {
                currentCol--;
                currentRow--;
                direction = "up";
            }
            else if (direction == "up" && (currentRow < 0 || matrixD[currentRow, currentCol] != 0))
            {
                currentRow++;
                currentCol--;
                direction = "left";
            }

            else if (direction == "left" && (currentRow < 0 || matrixD[currentRow, currentCol] != 0))
            {
                currentCol++;
                currentRow++;
                direction = "down";
            }

            matrixD[currentRow, currentCol] = i;
            if (direction == "down")
            {
                currentRow++;
            }
            else if (direction == "right")
            {
                currentCol++;
            }
            else if (direction == "up")
            {
                currentRow--;
            }
            else if (direction == "left")
            {

                currentCol--;
            }
        }
        //print matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} ", matrixD[i, j] + "  ");
            }
            Console.WriteLine();
        }

    }
    

}
