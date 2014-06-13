using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    public class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public ulong Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                this.number = value;
            }
        }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = ConvertToBitsArray();
            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        private int[] ConvertToBitsArray()
        {
            int[] bits = new int[64];
            for (int i = 0; i < bits.Length; i++)
            {
                int bit = (int)((number >> i) & 1);
                bits[63 - i] = bit; //This way the array is reversed and the number 110000...00 is 00...00011
            }
            return bits;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                return false;
            }
            BitArray64 other = obj as BitArray64;
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return this.Number == other.Number;
        }

        public int this[int index]
        {
            get //Only getter - you can't change the number
            {
                if (index < 0 || index > 63)
                {
                    throw new System.IndexOutOfRangeException();
                }

                int[] bits = this.ConvertToBitsArray();
                return bits[index];
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            return !(a == b);
        }
    }
}
