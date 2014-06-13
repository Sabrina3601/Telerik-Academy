using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightmare
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = 0;
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '0' || input[i] == '1' || input[i] == '2' ||
                    input[i] == '3' || input[i] == '4' || input[i] == '5'||
                    input[i] == '6' || input[i] == '7' || input[i] == '8'||
                    input[i] == '9')
                {
                    if (i % 2 != 0)
                    {
                        count++;
                        sum += int.Parse(input[i].ToString());
                    }
                }
               
            }
            Console.WriteLine(count + " " + sum);
        }
    }
}
