using System;

namespace Methods
{
    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(
                halfPerimeter *
                (halfPerimeter - a) *
                (halfPerimeter - b) *
                (halfPerimeter - c));

            return area;
        }

        public static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("Invalid number!");
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Input can not be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Array must have at least one element!");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintNumberWithPrecisionTwo(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberMultipliedByHundredPercent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberWithAlignmentEight(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool CheckLineIsHorizontal(double x1, double x2)
        {
            bool isHorizontal = (x1 == x2);

            return isHorizontal;
        }

        public static bool CheckLineIsVertical(double y1, double y2)
        {
            bool isVertical = (y1 == y2);

            return isVertical;
        }

        public static double CalcDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberWithPrecisionTwo(1.3);
            PrintNumberMultipliedByHundredPercent(0.75);
            PrintNumberWithAlignmentEight(2.30);

            bool horizontal = CheckLineIsHorizontal(3, 3);
            bool vertical = CheckLineIsVertical(-1, 2.5);
            Console.WriteLine(CalcDistanceBetweenTwoPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);
            
            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.PersonalInfo = new PersonalInformation("17.03.1992", "Sofia");

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.PersonalInfo = new PersonalInformation("03.11.1993", "Varna", "gamer");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}