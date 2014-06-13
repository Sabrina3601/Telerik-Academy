using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class TestMatrix
    {
        static void Main()
        {

            Matrix<int> arr = new Matrix<int>(5,5);

            Console.WriteLine("Sum of the two matrices");
            Console.WriteLine(arr.Col + arr.Row);
            Console.WriteLine("Substraction of the two matrices");
            Console.WriteLine(arr.Col - arr.Row);
            Console.WriteLine("Multiplication of the two matrices");
            Console.WriteLine(arr.Col * arr.Row);



        }
    }
}
