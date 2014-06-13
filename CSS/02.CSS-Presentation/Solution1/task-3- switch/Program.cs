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
                int sum = 0;
                int total = 0;
                for (int k = 0; k < num.Length; k++)
                {
                    total += int.Parse(num[k].ToString());
                }

                for (int j = 0; j < 10; j++)
                {
                    sum = 0;
                    switch (j)
                    {
                        case 0:
                            sum += 10;
                            break;
                        case 1:
                            sum += 20;
                            break;
                        case 2:
                            sum += 30;
                            break;
                        case 3:
                            sum += 50;
                            break;
                        case 4:
                            sum += 80;
                            break;
                        case 5:
                            sum += 110;
                            break;
                        case 6:
                            sum += 130;
                            break;
                        case 7:
                            sum += 160;
                            break;
                        case 8:
                            sum += 200;
                            break;
                        case 9:
                            sum += 240;
                            break;
                        default:
                            break;
                    }
                    for (int l = 0; l < 10; l++)
                    {
                        switch (l)
                        {
                            case 0:
                                sum += 10;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 10;
                                break;
                            case 1:
                                sum += 20;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 20;
                                break;
                            case 2:
                                sum += 30;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 30;
                                break;
                            case 3:
                                sum += 50;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 50;
                                break;
                            case 4:
                                sum += 80;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 80;
                                break;
                            case 5:
                                sum += 110;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 110;
                                break;
                            case 6:
                                sum += 130;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 130;
                                break;
                            case 7:
                                sum += 160;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 160;
                                break;
                            case 8:
                                sum += 200;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else sum -= 200;
                                break;
                            case 9:
                                sum += 240;
                                if (weight == (sum + start + total))
                                {
                                    count++;
                                    sum = 0;
                                }
                                else
                                {
                                    sum -= 240;
                                }

                                break;
                            default:
                                break;
                        }

                    }

                }

            }
            Console.WriteLine(count);
        }
    }
}
