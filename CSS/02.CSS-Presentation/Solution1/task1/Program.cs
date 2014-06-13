using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());

            int height = h * 4;
            int width = h * 3;

            for (int i = 0; i < 5; i++)
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                if (x>=0 && x<= width && y>= 0 && y<=h)
                {
                    Console.WriteLine("inside");
                }
                else if (x>=h && x<=h+h && y>= 0 && y<=height)
                {
                    Console.WriteLine("inside");
                }
                
                else
                {
                    Console.WriteLine("outside");
                }
            }
        }
    }
}
