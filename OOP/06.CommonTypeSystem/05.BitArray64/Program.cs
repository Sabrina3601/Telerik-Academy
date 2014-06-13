using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Define a class BitArray64 to hold 64 bit values inside an ulong value.
//Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
namespace _05.BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 number = new BitArray64(222l);
            BitArray64 otherNumber = new BitArray64(2220l);
            Console.WriteLine("Bits of the number {0}", number.Number);
            foreach (var bit in number)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Bit at position 60 is {0}", number[60]);
            Console.WriteLine("Hash code of {0} is {1}", number.Number, number.GetHashCode());

            Console.WriteLine("number == otherNumber -> {0}", number == otherNumber);
            Console.WriteLine("number != otherNumber -> {0}", number != otherNumber);
            Console.WriteLine("number equals otherNumber -> {0}", number.Equals(otherNumber));
        }
    }
}
