using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder cards = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
               cards.Append(Console.ReadLine());   
               
            }
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[0] == cards[i])
                {
                    a++;
                }
                if (cards[1] == cards[i])
                {
                    b++;
                }
                if (cards[2] == cards[i])
                {
                    c++;
                }
                if (cards[3] == cards[i])
                {
                    d++;
                }
                if (cards[4] == cards[i])
                {
                    e++;
                }
            }

        }
    }
}
