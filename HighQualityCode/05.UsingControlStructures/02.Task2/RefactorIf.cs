using System;
using System.Linq;

namespace _02.RefactorIf
{
    public class RefactorIf
    {
        internal static void Cook(Potato potato)
        {
            bool isPeeled = potato.IsPeeled;
            bool isRotten = potato.IsRotten;
            if (potato != null)
            {
                if (isPeeled && !isRotten)
                {
                    Console.WriteLine("Potato has been cooked");
                }
            }
        }

        internal static void VisitCell()
        {
            Console.WriteLine("Cell has been visited");
        }

        public static void Main()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsPeeled)
                {
                    Cook(potato);
                }
            }

            int x = 3;
            int y = 3;
            int minX = 1;
            int maxX = 5;
            int minY = 1;
            int maxY = 5;
            bool isYBetweenMinMax = minY <= y && y <= maxY;
            bool isXBetweenMinMax = minX <= x && x <= maxX;
            bool shoudVisitCell = true;
            if (isXBetweenMinMax && (isYBetweenMinMax && shoudVisitCell))
            {
                VisitCell();
            }        
        }
    }
}