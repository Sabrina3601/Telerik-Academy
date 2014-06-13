//We are given 5 integer numbers. 
//Write a program that checks if the sum of some subset of them is 0.
//Example: 3, -2, 1, 1, 8  1+1-2=0.
using System;

class sumOfSubset
{
    static void Main()
    {
        int[] numbers = new int[5];
        Console.WriteLine("Give me five numbers to check their sum of some subset ot be 0:");
        numbers[0] = int.Parse(Console.ReadLine());
        numbers[1] = int.Parse(Console.ReadLine());
        numbers[2] = int.Parse(Console.ReadLine());
        numbers[3] = int.Parse(Console.ReadLine());
        numbers[4] = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 1; j < numbers.Length; j++)
            {
                if (j<i || j==i)
                {
                    continue;   
                }
                else if (numbers[i] + numbers[j] == 0)
                {
                    Console.WriteLine("{0} + {1} = 0", numbers[i], numbers[j]);
                }
                for (int k = 2; k < numbers.Length; k++)
                {
                    if (k<j || k==j)
                    {
                        continue;
                    }
                    else if (numbers[i] + numbers[j] + numbers[k] == 0)
                    {
                        Console.WriteLine("{0} + {1} + {2} = 0", numbers[i], numbers[j], numbers[k]);
                    }
                    for (int l = 3; l < numbers.Length; l++)
                    {
                        if (l<k || l==k)
                        {
                            continue;
                        }
                        else if (numbers[i] + numbers[j] + numbers[k] + numbers[l] == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} + {3}= 0", numbers[i], numbers[j], numbers[k], numbers[l]);
                        }
                    }
                }
            }
        }
        if (numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
        }
        else
        {
            Console.WriteLine("I can't find sum of some subset to be 0. Sorry");
        }
    }
}

