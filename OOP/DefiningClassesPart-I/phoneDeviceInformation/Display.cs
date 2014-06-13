using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.phoneDeviceInformation
{
    class Display
    {
        private double? size;
        private double? colors;

        public double? Size { 
            get{ return this.size; }
            set { this.size = value; }
        }

        public double? Colors {
            get{ return this.colors; }
            set { this.colors = value; }
        }

        public Display():this(null,null)
        {

        }
        public Display(double? getSize, double? getColors)
        {
            this.size = getSize;
            this.colors = getColors;
        }

        //public void Print()
        //{
        //    Console.WriteLine("Size: {0}", this.Size);
        //    Console.WriteLine("Colors: {0}", this.Colors);
        //}
    }
}
