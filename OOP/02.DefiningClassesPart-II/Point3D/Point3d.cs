//Task1
//Create a structure Podouble3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
//Implement the ToString() to enable prdoubleing a 3D podouble

//Task2
//Add a private static read-only field to hold the start of the coordinate system – the podouble O{0, 0, 0}.
//Add a static property to return the podouble O.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class Point3d
    {
        public struct strPoint3d
        {
            private double x;
            private double y;
            private double z;
            private static readonly strPoint3d Start = new strPoint3d(0, 0, 0);

            //properties
            public double X
            {
                get { return this.x; }//getter
                set { this.x = value; }//setter
            }
            public double Y
            {
                get { return this.y; }//getter
                set { this.y = value; }//setter
            }
            public double Z
            {
                get { return this.z; }//getter
                set { this.z = value; }//setter
            }

            //constructor
            public strPoint3d(double strX, double strY, double strZ)
            {
                this.x = strX;
                this.y = strY;
                this.z = strZ;
            }

            //Implement toString()
            public override string ToString()
            {
                string print = string.Format("X = {0}; Y = {1}; Z = {2}", X,Y,Z);
                return print;                
            }
        }
    }
    
}
