using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //the missing code
            int sum = firstNumber + secondNumber;
            if (sum % 12 == 0 && sum % 21 == 0)
            {
                Console.WriteLine("Sum is {0}. You win the ipad", sum);
            }
            else
            {
                if (sum % 12 == 0 || sum % 21 == 0)
                {
                    Console.WriteLine("Sum is {0}. You win the apple pie",sum);
                }

                else
                {
                    Console.WriteLine("Sum is {0}. You win a bottle of coca cola",sum);
                }
            }
            ///////////////////////////////////////////////////



        }
    }
}
