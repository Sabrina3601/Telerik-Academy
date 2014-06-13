using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garden
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal tomato = 0.5m;
            decimal cucumber = 0.4m;
            decimal potato = 0.25m;
            decimal carrot = 0.6m;
            decimal cabbage = 0.3m;
            decimal beans = 0.4m;

            int totalArea = 250;
            decimal totalSeeds = 0m;
            for (int i = 1; i <= 11; i++)
            {
                if (i%2==0)
                {
                    //area
                    int area = int.Parse(Console.ReadLine());
                    totalArea -= area;
                }
                else
                {
                    decimal input = decimal.Parse(Console.ReadLine());
                    totalSeeds += input;
                }
            }
        }
    }
}
