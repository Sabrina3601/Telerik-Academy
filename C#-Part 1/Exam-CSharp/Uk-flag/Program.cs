using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uk_flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n/2; i++)
            {
                Console.Write(new string('.', i));
                Console.Write(new string((char)92,1));
                Console.Write(new string('.', (n/2-i)-1));
                Console.Write(new string('|', 1));
                Console.Write(new string('.', (n / 2 - i) - 1));
                Console.Write(new string('/', 1));
                Console.Write(new string('.', i));
                Console.WriteLine();
            }
            Console.Write(new string('-', n/2));
            Console.Write(new string('*', 1));
            Console.Write(new string('-', n / 2));
            Console.WriteLine();

            for (int i = 0; i < n/2; i++)
            {
                Console.Write(new string('.', (n/2-i)-1));
                Console.Write(new string('/', 1));
                Console.Write(new string('.', i));
                Console.Write(new string('|', 1));
                Console.Write(new string('.', i));
                Console.Write(new string((char)92, 1));
                Console.Write(new string('.', (n / 2 - i) - 1));
                Console.WriteLine();
            }
        }
    }
}
