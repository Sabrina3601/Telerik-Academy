using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bat_Goiko_Tower
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                Console.Write(new string('.',input -i -1));
                Console.Write(new string('/', 1));
                if (i>0)
                {
                    if (i== 1 || i == 3 || i==6 || i==10|| i== 15|| i== 21 || i==28 || i==36 )
                    {
                        Console.Write(new string('-', (input * 2) - ((input - i)*2)));
                    }
                    else
                    {
                        Console.Write(new string('.', (input * 2) - ((input - i) * 2)));
                    }
                }
                Console.Write(new string((char)92,1));
                Console.Write(new string('.',input -i -1));
                Console.WriteLine();
            }

        }
    }
}
