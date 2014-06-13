using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = 7;

            string alpha = Console.ReadLine();
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            int index = 0;
            int asd = height % width;
            for (int x = 0; x < height/width; x++)
            {
                
            

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i].ToString() == alpha)
                {
                    index = i;
                }
            }

            for (int i = 0; i < width / 2; i++)
            {
                if (i > 0)
                {
                    Console.Write(new string('.', (width / 2) - i));

                    if (i == 1)
                    {
                        for (int k = 1; k <= 3; k++)
                        {
                            if (k + index > 6)
                            {

                                index = 0;
                                Console.Write(alphabet[index]);
                            }
                            else
                            {
                                Console.Write(alphabet[index + k]);

                            }
                            if (k == 3)
                            {
                                index = k + 2;
                            }

                        }
                    }
                    else
                    {
                        for (int k = 1; k <= 5; k++)
                        {
                            if (index > 6)
                            {

                                index = 0;
                                Console.Write(alphabet[index]);
                                index++;

                            }
                            else
                            {
                                Console.Write(alphabet[index]);
                                index++;

                            }
                        }

                    }

                    Console.Write(new string('.', (width / 2) - i));

                    Console.WriteLine();



                }
                else
                {
                    Console.Write(new string('.', width / 2));
                    Console.Write(alpha);
                    Console.Write(new string('.', width / 2));
                    Console.WriteLine();
                }
            }

            // Console.WriteLine();
            for (int b = 0; b < width; b++)
            {
                if (index > 6)
                {

                    index = 0;
                    Console.Write(alphabet[index]);
                    index++;

                }
                else
                {
                    Console.Write(alphabet[index]);
                    index++;

                }
            }
            Console.WriteLine();
            Console.Write(new string('.', 1));
            

                for (int j = 0; j < 5; j++)
                {
                    if (index > 6)
                    {

                        index = 0;
                        Console.Write(alphabet[index]);
                        index++;

                    }
                    else
                    {
                        Console.Write(alphabet[index]);
                        index++;

                    }
                }
                Console.Write(new string('.', 1));
                //Console.WriteLine();
                Console.WriteLine();
                Console.Write(new string('.', 2));
                for (int j = 0; j < 3; j++)
                {
                    if (index > 6)
                    {

                        index = 0;
                        Console.Write(alphabet[index]);
                        index++;

                    }
                    else
                    {
                        Console.Write(alphabet[index]);
                        index++;

                    }
                }
                
                Console.Write(new string('.', 2));
                Console.WriteLine();
                Console.Write(new string('.', width/2));
                Console.Write(alphabet[index]);
                index++;
                Console.Write(new string('.', width / 2));
                Console.WriteLine();
            }
        }
    }
}
