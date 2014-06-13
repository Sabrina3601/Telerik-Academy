using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactorIf
{
    class Potato
    {
        internal bool IsPeeled { get; private set; }

        internal bool IsCut { get; private set; }

        internal bool IsRotten { get; set; }

        public void Peel()
        {
            if (!this.IsRotten)
            {
                this.IsPeeled = true;
            }
            else
            {
                Console.WriteLine("this vegetable is rotten! I won't cook it");
            }
        }

        public void Cut()
        {
            if (this.IsPeeled)
            {
                this.IsCut = true;
            }
            else
            {
                Console.WriteLine("Peel before Cutting");
            }
        }

    }
}
