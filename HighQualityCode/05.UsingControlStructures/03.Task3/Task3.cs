using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Task3
{
    class Task3
    {
        static void Main(string[] args)
        {
            int[] array = new int[100];
            //<summary>
            //fill the array with numbers 1 to 100
            //</summary>
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            int expectedValue = int.Parse(Console.ReadLine());
            bool isValueFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        isValueFound = true;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                    i++;
                }
            }
            // More code here
            if (isValueFound)
            {
                Console.WriteLine("Value found");
            }
            else
            {
                Console.WriteLine("Value was not found");
            }

        }
    }
}
