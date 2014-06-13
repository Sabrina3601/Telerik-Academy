using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4_8
{
    class Program
    {
        static void Main(string[] args)
        {
            long A = long.Parse(Console.ReadLine());
            long B = long.Parse(Console.ReadLine());
            long C = long.Parse(Console.ReadLine());

            long remainder = int.MinValue;
            long answer;
            if (B == 2)
            {
                 remainder= A % C;
            }
            if (B==4)
            {
                remainder = A + C;
            }
            if (B==8)
            {
                remainder = A * C;
            }
            if (remainder % 4 == 0)
            {
                answer = remainder / 4;
            }
            else
            {
                answer = remainder % 4;
            }
            Console.WriteLine(answer);
            Console.WriteLine(remainder);
        }
    }
}
