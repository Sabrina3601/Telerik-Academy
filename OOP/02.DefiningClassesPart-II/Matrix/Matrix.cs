using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix<T> where T : IComparable<T>
    {
        private int row;
        private int col;
        private T[,] matrix;

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

        public Matrix(int row, int col)
        {
            Row = row;
            Col = col;
            matrix = new T[row, col];
        }

        public T this[int row, int col]
        {
            get
            {              
                return matrix[row, col];
            }
            set
            {
                matrix[row, col] = value;
            }
        }

        //add + operators
        public static Matrix<T> operator +(Matrix<T> leftMatrix, Matrix<T> rightMatrix)
        {
            if (leftMatrix.Row != rightMatrix.Row || leftMatrix.Col != rightMatrix.Col)
            {
                throw new FormatException("Adding (+) can't be used on matrixes with diferent dimensions");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(leftMatrix.Row, leftMatrix.Col);
                for (int i = 0; i < leftMatrix.Row; i++)
                {
                    for (int j = 0; j < leftMatrix.Col; j++)
                    {
                        result.matrix[i, j] = (dynamic)leftMatrix.matrix[i, j] + (dynamic)rightMatrix.matrix[i, j];
                    }
                }
                return result;
            }
        }

        //add Minus Mehtod
        public static Matrix<T> operator -(Matrix<T> leftMatix, Matrix<T> rightMatrix)
        {
            if (leftMatix.Col !=rightMatrix.Col || leftMatix.Row != rightMatrix.Row)
            {
                throw new FormatException("Adding (-) can't be used on matrixes with diferent dimensions");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(leftMatix.Row, rightMatrix.Col);
                for (int i = 0; i < leftMatix.Row; i++)
                {
                    for (int j = 0; j < leftMatix.Col; j++)
                    {
                        result.matrix[i, j] = (dynamic)leftMatix.matrix[i, j] - (dynamic)rightMatrix.matrix[i, j];
                    }
                }
                return result;
            }            
        }
        //add * Method
        public static Matrix<T> operator *(Matrix<T> leftMatix, Matrix<T> rightMatrix)
        {
            if (leftMatix.Col != rightMatrix.Col || leftMatix.Row != rightMatrix.Row)
            {
                throw new FormatException("Adding (-) can't be used on matrixes with diferent dimensions");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(leftMatix.Row, rightMatrix.Col);
                for (int i = 0; i < leftMatix.Row; i++)
                {
                    for (int j = 0; j < leftMatix.Col; j++)
                    {
                        result.matrix[i, j] = (dynamic)leftMatix.matrix[i, j] * (dynamic)rightMatrix.matrix[i, j];
                    }
                }
                return result;
            }
        }
    }
}
