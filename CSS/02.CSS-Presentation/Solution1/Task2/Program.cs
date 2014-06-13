using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int cabelNum = int.Parse(Console.ReadLine());
            int totalLenght = 0;
            int count = 0;
            for (int i = 0; i < cabelNum; i++)
            {
                int inputLenght = int.Parse(Console.ReadLine());
                string measure = Console.ReadLine();
                if (inputLenght<20 && measure == "centimeters")
                {
                    continue;
                }
                else
                {
                    if (measure == "meters")
                    {
                        totalLenght += inputLenght * 100;
                        count++;
                    }
                    else if(measure =="centimeters")
                    {
                        totalLenght += inputLenght;
                        count++;
                    }
                    else
                    {
                        continue;
                    }
                }
                
            }

            int totalLenghtWithLoses = totalLenght - (3 * (count-1));

            int studentsCable = 504;

            Console.WriteLine(totalLenghtWithLoses/studentsCable);
            Console.WriteLine(totalLenghtWithLoses % studentsCable);


        }
    }
}
