using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaspichan_boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int height = 6 + ((input - 3) / 2) * 3;
            for (int i = 0; i < input; i++)
            {
                Console.Write(new string('.',input-i));
                Console.Write(new string('*', 1));
                if (i>0)
                {
                    Console.Write(new string('.', (input - (input - i)) - 1));
                    Console.Write(new string('*', 1));
                    Console.Write(new string('.', (input - (input - i)) - 1));
                    Console.Write(new string('*', 1));
                    
                }
                Console.Write(new string('.', input - i));
                
               // Console.Write(new string('.', input-i));
                Console.WriteLine();

            }

            Console.WriteLine(new string('*',input*2+1));

            for (int i = 1; i <= height-input-2; i++)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', (input - i)-1));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', (input - i) - 1));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', i));
                Console.WriteLine();
            }
            Console.Write(new string('.', (((input*2+1)-input)/2)));
            Console.Write(new string('*', input));
            Console.Write(new string('.', (((input * 2 + 1) - input) / 2)));
        }
    }
}
