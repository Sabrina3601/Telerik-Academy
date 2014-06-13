using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bits
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                string binValue = Convert.ToString(num, 2);
                StringBuilder firstp = new StringBuilder();
                if (num == 0)
                {
                    firstp.Append(1111);
                    firstp.Append(1111);
                    firstp.Append(1111);
                    firstp.Append(1111);
                    firstp.Append(1111);
                    firstp.Append(1111);
                    firstp.Append(1111);
                    firstp.Append(1111);
                }
                else
                {
                    for (int j = 0; j < binValue.Length; j++)
                    {
                        if (binValue[j] == '0')
                        {

                            firstp.Append(1);
                        }
                        else
                        {
                            if (j == 0)
                            {
                                continue;
                            }
                            firstp.Append(0);
                        }
                    }
                }
                
                StringBuilder secondP = new StringBuilder();
               // int count = 0;
                for (int k = binValue.Length-1; k >= 0; k--)
                {
                    secondP.Append( binValue[k]);
                }
                //count = 0;

                //string p1 = new string(firstp);
                int newP = Convert.ToInt32(firstp.ToString(), 2);
                int secondNewP = Convert.ToInt32(secondP.ToString(), 2);

                long P = (num ^ newP) & secondNewP;
                Console.WriteLine(P);
               

               //Console.WriteLine(secondP);
            }
        }
    }
}
