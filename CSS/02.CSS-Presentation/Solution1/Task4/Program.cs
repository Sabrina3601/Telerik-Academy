using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int weight = int.Parse(Console.ReadLine());

            int start = 40;    
            int count = 0;

            for (int i = 1000; i <= 9999; i++)
            {
                string num = i.ToString();
                int firstSum = 0;
                int secondSum = 0;
                int thirdSum = 0;
                for (int k = 0; k < num.Length; k++)
                {
                    firstSum += int.Parse(num[k].ToString());
                }

                for (int j = 0; j < 10; j++)
                {
                    secondSum = 0;
                    if (j == 0)
                    {
                        secondSum += 10;
                    }
                    if (j == 1)
                    {
                        secondSum += 20;
                    }
                    if (j == 2)
                    {
                        secondSum += 30;
                    }
                    if (j == 3)
                    {
                        secondSum += 50;
                    }
                    if (j == 4)
                    {
                        secondSum += 80;
                    }
                    if (j == 5)
                    {
                        secondSum += 110;
                    }
                    if (j == 6)
                    {
                        secondSum += 130;
                    }
                    if (j == 7)
                    {
                        secondSum += 160;
                    }
                    if (j == 8)
                    {
                        secondSum += 200;
                    }
                    if (j == 9)
                    {
                        secondSum += 240;
                    }
                    for (int l = 0; l < 10; l++)
                    {
                        thirdSum = 0;
                        if (l ==0)
                        {
                            thirdSum += 10;

                        }
                        if (l==1)
                        {
                            thirdSum += 20;
                        }
                        if (l == 2)
                        {
                            thirdSum += 30;
                        }
                        if (l == 3)
                        {
                            thirdSum += 50;
                        }
                        if (l == 4)
                        {
                            thirdSum += 80;
                        }
                        if (l == 5)
                        {
                            thirdSum += 110;
                        }
                        if (l == 6)
                        {
                            thirdSum += 130;
                        }
                        if (l == 7)
                        {
                            thirdSum += 160;
                        }
                        if (l == 8)
                        {
                            thirdSum += 200;
                        }
                        if (l == 9)
                        {
                            thirdSum += 240;
                        }
                        if (firstSum + secondSum + thirdSum  + start == weight)
                        {
                            count++;   
                        }
                    }
                }
              
            }
            Console.WriteLine(count);
        }
    }
}
