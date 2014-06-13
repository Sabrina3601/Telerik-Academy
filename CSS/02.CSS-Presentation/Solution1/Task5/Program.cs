using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = BigInteger.Parse(Console.ReadLine());
            string binaryNum = Convert.ToString(BigInteger.Parse(num), 2);
            StringBuilder outputBnary = new StringBuilder();
            for (int i = 0; i < binaryNum.Length-3; i++)
            {

                if (binaryNum[i] == binaryNum[i+1] && binaryNum[i] == binaryNum[i+2])
                {
                    if (binaryNum[i] == '0')
                    {
                        outputBnary.Append(111);
                    }
                    else
                    {
                        outputBnary.Append(000);
                    }
                    i += 2;
                }
                else
                {
                    outputBnary.Append(binaryNum[i]);
                }

            }
            Console.WriteLine(binaryNum);
            Console.WriteLine(outputBnary.ToString());

        }
    }
}
