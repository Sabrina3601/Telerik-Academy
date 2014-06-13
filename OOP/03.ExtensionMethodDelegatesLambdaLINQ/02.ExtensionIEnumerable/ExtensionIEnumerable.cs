using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
//sum, product, min, max, average.

namespace _02.ExtensionIEnumerable
{
    public static class IEnumerableFunctionality
    {
        public static T Sum<T>(this IEnumerable<T> arr)
        {
            dynamic sum = 0;
            foreach (var item in arr)
            {
                sum += (dynamic)item;
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> arr)
        {
            dynamic product = 1;
            foreach (var item in arr)
            {
                product *= (dynamic)item;
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> arr)
        {
            dynamic min = int.MaxValue;
            foreach (var item in arr)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;        
        }

        public static T Max<T>(this IEnumerable<T> arr)
        {
            dynamic max = int.MinValue;
            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;   
        }

        public static T Avarage<T>(this IEnumerable<T> arr)
        {
            dynamic avarage = 0;
            foreach (var item in arr)
            {
                avarage += item;
            }
            avarage = avarage / arr.Count();
            return avarage;
        }
    }

    class IEnumerableFunctionalityTest
    {
        static void Main()
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Sum of elements: {0}", elements.Sum<int>());
            Console.WriteLine("Product of elements: {0}", elements.Product<int>());
            Console.WriteLine("Min element: {0}", elements.Min<int>());
            Console.WriteLine("Max element: {0}", elements.Max<int>());
            Console.WriteLine("Avarage of elements: {0}", elements.Avarage<int>());
        }
    }
}
