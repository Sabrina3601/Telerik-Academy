using System;
using System.Text;

class Copyright
{
    static void Main()
    {
        char symbol = '\u00A9';
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine("Type how many symbols you want to display.");
        int number = int.Parse(Console.ReadLine());
        for (int i = 0; i <= number; i++)
        {
            Console.Write(new string(' ', number - i));
            for (int j = 0; j < i; j++)
            {
                
                Console.Write(symbol+ " ");
            }
          
            Console.WriteLine();
        }


        // second triangle
        for (int i = 0; i <= number; i++)
        {
            for (int j = 0; j < i; j++)
            {

                Console.Write(symbol + " ");
            }

            Console.WriteLine();
        }
    }
}

