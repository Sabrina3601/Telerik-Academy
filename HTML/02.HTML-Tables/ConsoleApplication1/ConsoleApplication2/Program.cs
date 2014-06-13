using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Type some lines of text.");
            Console.WriteLine("Type 'STOP'  aftre the last line");
            Console.WriteLine();
            // missing code
            int lines = 0;
            int psv = 0;
            int ajax = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Contains("STOP"))
                {
                    break;
                }
                else
                {
                    lines++;
                    if (input.Contains("psv"))
                    {
                        psv++;
                    }
                    if (input.Contains("ajax"))
                    {
                        ajax++;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Number of lines is {0}", lines);
            Console.WriteLine("Number of lines containing psv is {0}", psv);
            Console.WriteLine("Number of lines containing ajax is {0}", ajax);

            // do tuk pishesh ti. Ttova na dolu e napisano
            Console.WriteLine();
            Console.WriteLine("press any key to stop this aapp;");
            Console.ReadKey();
        }
    }
}
